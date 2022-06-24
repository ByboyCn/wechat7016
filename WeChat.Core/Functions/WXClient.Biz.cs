using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 搜索公众号
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Protocol.Protos.V2.SearchContactResponse> WXSearchBiz(string username);
        /// <summary>
        /// 关注公众号
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<VerifyUserResponese> WXForkBizAccount(string username);
        /// <summary>
        /// 操作公众号菜单
        /// </summary>
        /// <param name="username">公众号ID,例如"weixin"</param>
        /// <param name="menuId">菜单ID,例如"2672637330"</param>
        /// <param name="menuKey">菜单Key,例如"rselfmenu_2_0"</param>
        /// <returns></returns>
        /// <returns></returns>
        Task<ClickCommandResponse> WXClickBizMenu(string username, string menuId, string menuKey);
        /// <summary>
        /// 阅读公众号文章
        /// </summary>
        /// <param name="url">文章url,格式：https://mp.weixin.qq.com/s/xxxxx </param>
        /// <returns></returns>
        Task<string> WXReadBizArticle(string url);
        /// <summary>
        /// 点赞公众号文章
        /// </summary>
        /// <param name="url">文章url,格式：https://mp.weixin.qq.com/s/xxxxx </param>
        /// <returns></returns>
        Task<string> WXLikeBizArticle(string url);
    }

    public partial class WXApp
    {
        /// <summary>
        /// 搜索公众号
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual async Task<Protocol.Protos.V2.SearchContactResponse> WXSearchBiz(string username)
        {
            return await Request<Protocol.Protos.V2.SearchContactResponse>(new Protocol.Protos.V2.SearchContactRequest()
            {
                baseRequest = new Protocol.Protos.V2.BaseRequest
                {
                    clientVersion = _Environment.Terminal.GetWeChatVersion(),
                    devicelId = _Environment.WeChatDataId.ToByteArray(16, 2),
                    osType = _Environment.WeChatOsType,
                    sessionKey = _Cache.SessionKey,
                    scene = _Cache.Scene,
                    uin = _Cache.Uin
                },
                searchScene = 2,
                opCode = 0,
                fromScene = 1,
                userName = new SKBuiltinString { @string = username }
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_searchcontact);
        }

        /// <summary>
        /// 关注公众号
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        public virtual async Task<VerifyUserResponese> WXForkBizAccount(string username)
        {
            return await WXVerifyUser(1, username, "", 0, "", "");
        }

        /// <summary>
        /// 操作公众号菜单
        /// </summary>
        /// <param name="username">公众号ID,例如"weixin"</param>
        /// <param name="menuId">菜单ID,例如"2672637330"</param>
        /// <param name="menuKey">菜单Key,例如"rselfmenu_2_0"</param>
        /// <returns></returns>
        public virtual async Task<ClickCommandResponse> WXClickBizMenu(string username, string menuId, string menuKey)
        {
            return await Request<ClickCommandResponse>(new ClickCommandRequest()
            {
                BaseRequest = new Protocol.Protos.BaseRequest
                {
                    ClientVersion = _Environment.Terminal.GetWeChatVersion(),
                    DeviceID = _Environment.WeChatDataId.ToByteArray(16, 2),
                    DeviceType = _Environment.WeChatOsType.ToBytes(),
                    SessionKey = _Cache.SessionKey,
                    Scene = (uint)(_Cache.Scene),
                    Uin = _Cache.Uin
                },
                BizUserName = username,
                ClickInfo = $"#bizmenu#<info><id>{menuId}</id><key>{menuKey}</key><status>menu_click</status><content></content></info>",
                ClickType = 1
            }.SerializeToProtoBuf(), WXCGIUrl.micromsg_bin_clickcommand);
        }

        /// <summary>
        /// 阅读公众号文章
        /// </summary>
        /// <param name="url">文章url,格式：https://mp.weixin.qq.com/s/huEvG2RZ_l_HEykJAfIN0w </param>
        /// <returns></returns>
        public virtual async Task<string> WXReadBizArticle(string url)
        {
            var a8key = await WXGetA8Key(url);
            var full = a8key?.FullURL;
            if (full.IsEmpty())
            {
                return "A8Key授权失败";
            }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = full,
                Method = "GET"
            };
            a8key.HttpHeader?.ForEach(h => item.Header.Add(h.Key, h.Value));
            HttpResult result1 = http.GetHtml(item);
            var responseUri = new Uri(result1.ResponseUri);
            var content = result1.Html;
            var query = responseUri.GetQueryParams();

            var reg = new Regex("malluin=(.+);"); var match = reg.Match(result1.Header["Set-Cookie"]);
            string malluin = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("mallkey=(.+);"); match = reg.Match(result1.Header["Set-Cookie"]);
            string mallkey = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("wxtokenkey=(.+);"); match = reg.Match(result1.Header["Set-Cookie"]);
            string wxtokenkey = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("var devicetype = \"(.+)\""); match = reg.Match(content);
            string device_type = match.Groups[1].Value;

            reg = new Regex("window.appmsg_token = \"(.+)\";"); match = reg.Match(content);
            string appmsg_token = match.Groups[1].Value;

            reg = new Regex("var appmsg_type = \"(.+)\""); match = reg.Match(content);
            string appmsg_type = match.Groups[1].Value;

            reg = new Regex("var msg_title = '(.+)'"); match = reg.Match(content);
            string msg_title = match.Groups[1].Value;

            reg = new Regex("var nickname = \"(.+)\";"); match = reg.Match(content);
            string nickname = match.Groups[1].Value;

            reg = new Regex("var ct = \"(.+)\""); match = reg.Match(content);
            string ct = match.Groups[1].Value;

            reg = new Regex("var comment_id = \"(.+)\""); match = reg.Match(content);
            string comment_id = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

            reg = new Regex("var msg_daily_idx = \"(.+)\""); match = reg.Match(content);
            string msg_daily_idx = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

            reg = new Regex("var req_id = '(.+)'"); match = reg.Match(content);
            string req_id = match.Groups[1].Value;

            var post_url = $"{responseUri.Scheme}://{responseUri.Host}/mp/getappmsgext?f=json&mock=&uin={malluin.UrlEncode()}&key={mallkey}&pass_ticket={query["pass_ticket"]}&wxtoken={wxtokenkey}&devicetype={device_type.UrlEncode()}&clientversion={query["version"]}&__biz={query["__biz"]}&appmsg_token={appmsg_token}&x5=0&f=json";
            var post_dat = $"r=0.{DateTime.Now.Ticks}&__biz={query["__biz"]}&appmsg_type={appmsg_type}&mid={query["mid"]}&sn={query["sn"]}&idx={query["idx"]}&scene=&title={msg_title.UrlEncode()}&ct={ct}&abtest_cookie=&devicetype={query["devicetype"]}&version={query["version"]}&is_need_ticket=0&is_need_ad=0&comment_id={comment_id}&is_need_reward=0&both_ad=0&reward_uin_count=0&send_time=&msg_daily_idx={msg_daily_idx}&is_original=0&is_only_read=1&req_id={req_id}&pass_ticket={query["pass_ticket"]}&is_temp_url=0&item_show_type=0&tmp_version=1&more_read_type=0&appmsg_like_type=2&related_video_sn=&vid=";
            item = new HttpItem()
            {
                URL = post_url,
                Method = "POST",
                PostDataType = PostDataType.Byte,
                PostdataByte = post_dat.ToBytes(),
                Cookie = result1.Cookie,
                Referer = full
            };
            a8key.HttpHeader?.ForEach(h => item.Header.Add(h.Key, h.Value));
            item.Header.Add("Origin", $"{responseUri.Scheme}://{responseUri.Host}");
            HttpResult result2 = http.GetHtml(item);
            content = result2.Html;
            var json = JObject.Parse(content);
            return new { Title = msg_title, Author = nickname, Result = json }.ToJson();
        }

        /// <summary>
        /// 点赞公众号文章
        /// </summary>
        /// <param name="url">文章url,格式：https://mp.weixin.qq.com/s/huEvG2RZ_l_HEykJAfIN0w </param>
        /// <returns></returns>
        public virtual async Task<string> WXLikeBizArticle(string url)
        {
            var a8key = await WXGetA8Key(url);
            var full = a8key?.FullURL;
            if (full.IsEmpty())
            {
                return "A8Key授权失败";
            }
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = full,
                Method = "GET"
            };
            a8key.HttpHeader?.ForEach(h => item.Header.Add(h.Key, h.Value));
            HttpResult result1 = http.GetHtml(item);
            var responseUri = new Uri(result1.ResponseUri);
            var content = result1.Html;
            var query = responseUri.GetQueryParams();

            var reg = new Regex("malluin=(.+);"); var match = reg.Match(result1.Header["Set-Cookie"]);
            string malluin = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("mallkey=(.+);"); match = reg.Match(result1.Header["Set-Cookie"]);
            string mallkey = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("wxtokenkey=(.+);"); match = reg.Match(result1.Header["Set-Cookie"]);
            string wxtokenkey = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

            reg = new Regex("var devicetype = \"(.+)\""); match = reg.Match(content);
            string device_type = match.Groups[1].Value;

            reg = new Regex("window.appmsg_token = \"(.+)\";"); match = reg.Match(content);
            string appmsg_token = match.Groups[1].Value;

            reg = new Regex("var appmsg_type = \"(.+)\""); match = reg.Match(content);
            string appmsg_type = match.Groups[1].Value;

            reg = new Regex("var msg_title = '(.+)'"); match = reg.Match(content);
            string msg_title = match.Groups[1].Value;

            reg = new Regex("var nickname = \"(.+)\";"); match = reg.Match(content);
            string nickname = match.Groups[1].Value;

            reg = new Regex("var ct = \"(.+)\""); match = reg.Match(content);
            string ct = match.Groups[1].Value;

            reg = new Regex("var comment_id = \"(.+)\""); match = reg.Match(content);
            string comment_id = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

            reg = new Regex("var msg_daily_idx = \"(.+)\""); match = reg.Match(content);
            string msg_daily_idx = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

            reg = new Regex("var req_id = '(.+)'"); match = reg.Match(content);
            string req_id = match.Groups[1].Value;

            reg = new Regex("var appmsgid = '(.*)' \\|\\| '(.*)'\\|\\| \"(.*)\""); match = reg.Match(content);
            string appmsgid = "";
            if (match.Groups.Count >= 2 && !string.IsNullOrEmpty(match.Groups[1].Value)) { appmsgid = match.Groups[1].Value; }
            if (match.Groups.Count >= 3 && !string.IsNullOrEmpty(match.Groups[2].Value)) { appmsgid = match.Groups[2].Value; }
            if (match.Groups.Count >= 4 && !string.IsNullOrEmpty(match.Groups[3].Value)) { appmsgid = match.Groups[3].Value; }
            if (appmsgid.IsEmpty())
            {
                appmsgid = query["mid"]?.ToString();
            }
            var post_url = $"{responseUri.Scheme}://{responseUri.Host}/mp/appmsg_like?__biz={query["__biz"]}&mid={query["mid"]}&idx={query["idx"]}&like=1&f=json&appmsgid={appmsgid}&itemidx={query["idx"]}&uin={malluin.UrlEncode()}&key={mallkey}&pass_ticket={query["pass_ticket"]}&wxtoken={wxtokenkey}&devicetype={query["devicetype"]}&clientversion={query["version"]}&__biz={query["__biz"]?.ToString().UrlEncode()}&appmsg_token={appmsg_token}&x5=0&f=json";
            var post_dat = $"is_temp_url=0&scene=126&subscene=&appmsg_like_type=1&item_show_type=0&client_version={query["version"]}&comment=&prompted=1&style=1&action_type=1&passparam=&request_id={DateTime.Now.ToTimeStamp()}&devicetype={query["devicetype"]}";
            item = new HttpItem()
            {
                URL = post_url,
                Method = "POST",
                PostDataType = PostDataType.Byte,
                PostdataByte = post_dat.ToBytes(),
                Cookie = result1.Cookie,
                Referer = full
            };
            a8key.HttpHeader?.ForEach(h => item.Header.Add(h.Key, h.Value));
            item.Header.Add("Origin", $"{responseUri.Scheme}://{responseUri.Host}");
            return http.GetHtml(item)?.Html;
        }
    }
}
