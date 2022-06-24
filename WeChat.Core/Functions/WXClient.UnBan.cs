using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeChat.Core.Libraries.Dev;
using WeChat.Core.Protocol;
using WeChat.Core.Protocol.Protos;
using WeChat.Core.Protocol.Protos.V2;

namespace WeChat.Core
{
    public partial interface IWXApp
    {
        /// <summary>
        /// 封号开启临时登录/强开
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="force">是否强开</param>
        /// <returns></returns>
        Task<object> WXUnBanTempLogin(string username, string password, bool force = false);
        /// <summary>
        /// 滑块识别
        /// </summary>
        /// <param name="aid">滑块场景</param>
        /// <param name="proxyIp">代理IP</param>
        /// <returns></returns>
        Task<SliderResponse> WXSliderOCR(string aid = "2000000008", string proxyIp = "");
    }

    public partial class WXApp
    {
        /// <summary>
        /// 封号开启临时登录/强开
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="force">是否强开</param>
        /// <returns></returns>
        public virtual async Task<object> WXUnBanTempLogin(string username, string password, bool force = false)
        {
            var LoginResponse = await WXSecManualAuth(WXLoginChannel.Normal, username, password);
            if (LoginResponse == null)
            {
                return $"开启临时登录失败[数据异常请重试]";
            }
            if (LoginResponse?.baseResponse?.ret == RetConst.MM_ERR_BLOCK_BY_SPAM)
            {
                if (string.IsNullOrEmpty(Status.Url))
                {
                    return $"开启临时登录失败[状态异常][{Status.Message}]";
                }
                string url = Status.Url;
                string cookie = string.Empty;
                TempLoginResponse result = new TempLoginResponse();

                #region 第一步
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                };
                if ((Linker?.Proxy.Enable ?? false))
                {
                    item.ProxyIp = Linker.Proxy.ToStrProxy();
                }
                HttpResult httpResult1 = http.GetHtml(item);
                if (httpResult1.StatusCode != HttpStatusCode.OK)
                {
                    return $"开启临时登录失败[网络异常{httpResult1.StatusCode}-1]";
                }
                cookie = httpResult1.Cookie;
                #endregion

                #region 第二步
                url = $"https://shminorshort.weixin.qq.com/security/unban?t=self_deblock/w_acct&wechat_real_lang=zh_CN&ticket={Status.Ticket.UrlEncode()}&step=start&dev={Dev.GetDevStr()}";//{Dev.GetDevStr()}
                item = new HttpItem()
                {
                    URL = url,
                    Accept = "application/json",
                    Referer = Status.Url,
                    ResultCookieType = ResultCookieType.CookieContainer,
                    CookieContainer = new CookieContainer()
                };
                item.CookieContainer.SetCookies(new Uri(item.URL), cookie);
                item.Header.Add("X-Requested-With", "XMLHttpRequest");
                if ((Linker?.Proxy.Enable ?? false))
                {
                    item.ProxyIp = Linker.Proxy.ToStrProxy();
                }
                HttpResult httpResult2 = http.GetHtml(item);
                if (httpResult2.StatusCode != HttpStatusCode.OK)
                {
                    return $"开启临时登录失败[网络异常{httpResult2.StatusCode}-2]";
                }
                if (httpResult2?.CookieCollection?.Count > 0)
                {
                    cookie += ",";
                    cookie += WXHttpHelper.CookieCollectionToStrCookie(httpResult2?.CookieCollection).Replace(';', ',');
                }
                var state = (httpResult2?.Html ?? "").ToJObject<GetUnBanResponse>();
                //System.Diagnostics.Debug.WriteLine($"当前登录信息：{state.ToJson()}");
                if (state == null)
                {
                    return $"开启临时登录失败[返回数据解析失败]";
                }
                if (state.ret == -1)
                {
                    return "可以登录，无需开启临时登录[-1]";
                }
                else if (state.ret == -2)
                {
                    return $"开启临时登录失败[系统错误{state.ret}]";
                }
                else if (state.banreason.Contains("查询失败"))
                {
                    return $"开启临时登录失败[当前状态不支持{state.ret}]";
                }
                //else if (state.ret == -21 || state.ret == 14)
                //{
                //    return $"开启临时登录失败[当前状态不支持{state.ret}]";
                //}
                #endregion

                #region 第三步
                var slider = await WXSliderOCR();
                slider.Ticket = slider.Ticket.UrlEncode();
                slider.RandStr = slider.RandStr.UrlEncode();
                url = $"https://shminorshort.weixin.qq.com/security/unban?protect=&wechat_real_lang=zh_CN&t=self_deblock/w_tcaptcha_ret&next=getMoney&ret=0&ticket={slider.Ticket}&randstr={slider.RandStr}&step=verifycode&?protect=&wechat_real_lang=zh_CN&t=self_deblock/w_tcaptcha_ret&next=getMoney&ret=0&ticket={slider.Ticket}&randstr={slider.RandStr}&scene=money";
                string uin = new Regex(@"wxsrcrusehash=(.*?);").Match(cookie).Groups[1].Value;
                uin = uin.UrlDecode();
                item = new HttpItem()
                {
                    URL = url,
                    Accept = "application/json",
                    Referer = $"https://shminorshort.weixin.qq.com/security/readtemplate?protect=&wechat_real_lang=zh_CN&t=self_deblock/w_tcaptcha_ret&next=getMoney&ret=0&ticket={slider.Ticket}&randstr={slider.RandStr}",
                    ResultCookieType = ResultCookieType.CookieContainer,
                    CookieContainer = new CookieContainer()
                };
                item.CookieContainer.SetCookies(new Uri(item.URL), cookie);
                item.Header.Add("X-Requested-With", "XMLHttpRequest");
                item.Header.Add("X-WECHAT-UIN", uin);
                if ((Linker?.Proxy.Enable ?? false))
                {
                    item.ProxyIp = Linker.Proxy.ToStrProxy();
                }
                HttpResult httpResult3 = http.GetHtml(item);
                if (httpResult3.StatusCode != HttpStatusCode.OK)
                {
                    return $"开启临时登录失败[网络异常{httpResult3.StatusCode}-3]";
                }
                if (httpResult3?.CookieCollection?.Count > 0)
                {
                    cookie += ",";
                    cookie += WXHttpHelper.CookieCollectionToStrCookie(httpResult3?.CookieCollection).Replace(';', ',');
                }
                #endregion

                #region 第四步
                url = $"https://shminorshort.weixin.qq.com/security/unban?protect=&wechat_real_lang=zh_CN&t=self_deblock/w_tcaptcha_ret&next=getMoney&ret=0&ticket={slider.Ticket}&randstr={slider.RandStr}&step=moneytransfer";
                for (int i = 0; i < 5; i++)
                {
                    item = new HttpItem()
                    {
                        URL = url,
                        Accept = "application/json",
                        Referer = $"https://shminorshort.weixin.qq.com/security/readtemplate?protect=&wechat_real_lang=zh_CN&t=self_deblock/w_tcaptcha_ret&next=getMoney&ret=0&ticket={slider.Ticket}&randstr={slider.RandStr}",
                        ResultCookieType = ResultCookieType.CookieContainer,
                        CookieContainer = new CookieContainer()
                    };
                    item.CookieContainer.SetCookies(new Uri(item.URL), cookie);
                    item.Header.Add("X-Requested-With", "XMLHttpRequest");
                    item.Header.Add("X-WECHAT-UIN", uin);
                    if ((Linker?.Proxy.Enable ?? false))
                    {
                        item.ProxyIp = Linker.Proxy.ToStrProxy();
                    }
                    HttpResult httpResult4 = http.GetHtml(item);
                    if (httpResult4.StatusCode != HttpStatusCode.OK)
                    {
                        return $"开启临时登录失败[网络异常{httpResult4.StatusCode}-4]";
                    }
                    result = (httpResult4?.Html ?? "").ToJObject<TempLoginResponse>();
                    if (result.ret == 0)
                    {
                        return "开启临时登录成功";
                    }
                    else if (result.ret == -39)
                    {
                        return $"开启临时登录失败[{result?.resultData?.desc}]";
                    }
                    else if (result.ret == -41)
                    {
                        return $"开启临时登录失败[保护期][{result?.resultData?.title?.Between("需要在", "后才能申请")}后才能申请临时登录]";
                    }
                    else
                    {
                        if (!force)
                        {
                            return $"开启临时登录失败[{result.resultData.desc}][{result.introtype}/{result.ret}]";
                        }
                    }
                    System.Diagnostics.Debug.WriteLine($"第{i + 1}次强开结果：{result.ToJson()}");
                }
                #endregion
                return $"开启临时登录失败[{result.resultData.desc}][{result.introtype}/{result.ret}]";
            }
            else
            {
                if (Status.Code == 1)
                {
                    return $"可以登录，无需开启临时登录[{Status.Code}]";
                }
                return $"{Status.Message}[{Status.Code}]";
            }
        }

        /// <summary>
        /// 滑块识别
        /// </summary>
        /// <param name="aid">滑块场景</param>
        /// <param name="proxyIp">代理IP</param>
        /// <returns></returns>
        public virtual async Task<SliderResponse> WXSliderOCR(string aid = "2000000008", string proxyIp = "")
        {
            SliderResponse result = new SliderResponse();
            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        WXSliderOcr.TrySliderOCR(aid, out result);
                        if (result.Status == 0)
                        {
                            break;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                result.Status = -3;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
