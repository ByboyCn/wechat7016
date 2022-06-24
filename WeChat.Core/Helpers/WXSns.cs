using System;
using System.Text;

namespace WeChat.Core
{
    /// <summary>
    /// 微信朋友圈辅助
    /// </summary>
    public static class WXSns
    {
        /// <summary>
        /// 微信朋友圈媒体
        /// </summary>
        public sealed class WXSnsMedia
        {
            /// <summary>
            /// 数据链接
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// 图片链接
            /// </summary>
            public string ImageUrl { get; set; }
            /// <summary>
            /// 高度
            /// </summary> 
            public decimal Width { get; set; } = 300;
            /// <summary>
            /// 宽度
            /// </summary>
            public decimal Height { get; set; } = 300;
            /// <summary>
            /// 总大小
            /// </summary>
            public decimal TotalSize { get; set; }
        }
        /// <summary>
        /// 构建文本模板
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="content">文本内容</param>
        public static string BuildTemplate(string username, string content)
        {
            var time = DateTime.UtcNow.ToTimeStamp();
            var result = new StringBuilder();
            result.Append($"<TimelineObject>");
            result.Append($"    <id>0</id>");
            result.Append($"    <username>{username}</username>");
            result.Append($"    <createTime>{time}</createTime>");
            result.Append($"    <contentDesc>{content}</contentDesc>");
            result.Append($"    <contentDescShowType>0</contentDescShowType>");
            result.Append($"    <contentDescScene>3</contentDescScene>");
            result.Append($"    <private>0</private>");
            result.Append($"    <sightFolded>0</sightFolded>");
            result.Append($"    <showFlag>0</showFlag>");
            result.Append($"    <appInfo>");
            result.Append($"        <id></id>");
            result.Append($"        <version></version>");
            result.Append($"        <appName></appName>");
            result.Append($"        <installUrl></installUrl>");
            result.Append($"        <fromUrl></fromUrl>");
            result.Append($"        <isForceUpdate>0</isForceUpdate>");
            result.Append($"    </appInfo>");
            result.Append($"    <sourceUserName></sourceUserName>");
            result.Append($"    <sourceNickName></sourceNickName>");
            result.Append($"    <statisticsData></statisticsData>");
            result.Append($"    <statExtStr></statExtStr>");
            result.Append($"    <ContentObject>");
            result.Append($"        <contentStyle>2</contentStyle>");
            result.Append($"        <title></title>");
            result.Append($"        <description></description>");
            result.Append($"        <mediaList></mediaList>");
            result.Append($"    </ContentObject>");
            result.Append($"</TimelineObject>");
            return result.ToString();
        }
        /// <summary>
        /// 构建文本模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="content_url"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildTemplate(string username, string content, string title, string content_url, string description)
        {
            var time = DateTime.UtcNow.ToTimeStamp();
            var result = new StringBuilder();
            result.Append($"<TimelineObject>");
            result.Append($"    <id>0</id>");
            result.Append($"    <username>{username}</username>");
            result.Append($"    <createTime>{time}</createTime>");
            result.Append($"    <contentDesc>{content}</contentDesc>");
            result.Append($"    <contentDescShowType>0</contentDescShowType>");
            result.Append($"    <contentDescScene>3</contentDescScene>");
            result.Append($"    <private>0</private>");
            result.Append($"    <sightFolded>0</sightFolded>");
            result.Append($"    <showFlag>0</showFlag>");
            result.Append($"    <appInfo>");
            result.Append($"        <id></id>");
            result.Append($"        <version></version>");
            result.Append($"        <appName></appName>");
            result.Append($"        <installUrl></installUrl>");
            result.Append($"        <fromUrl></fromUrl>");
            result.Append($"        <isForceUpdate>0</isForceUpdate>");
            result.Append($"    </appInfo>");
            result.Append($"    <sourceUserName></sourceUserName>");
            result.Append($"    <sourceNickName></sourceNickName>");
            result.Append($"    <statisticsData></statisticsData>");
            result.Append($"    <statExtStr></statExtStr>");
            result.Append($"    <ContentObject>");
            result.Append($"        <contentStyle>2</contentStyle>");
            result.Append($"        <title>{title}</title>");
            result.Append($"        <description>{description}</description>");
            result.Append($"        <mediaList></mediaList>");
            result.Append($"        <contentUrl>{content_url}</contentUrl>");
            result.Append($"    </ContentObject>");
            result.Append($"    <actionInfo>");
            result.Append($"        <appMsg>");
            result.Append($"            <messageAction></messageAction>");
            result.Append($"        </appMsg>");
            result.Append($"    </actionInfo>");
            result.Append($"    <location city=\"\" poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"1\"></location>");
            result.Append($"    <publicUserName></publicUserName>");
            result.Append($"</TimelineObject>");
            return result.ToString();
        }
        /// <summary>
        /// 构建链接模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="contentUrl"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildLinkTemplate(string username, string content, WXSnsMedia[] medias, string title, string contentUrl, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>2</type><title></title><description></description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>3</contentStyle><contentSubStyle>0</contentSubStyle><title>{title}</title><description>{description}</description><contentUrl>{contentUrl}</contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><statExtStr></statExtStr><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName>gh_a45e6bdccb14</publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
        /// <summary>
        /// 构建视频模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="contentUrl"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildVideoTemplate(string username, string content, WXSnsMedia[] medias, string title, string contentUrl, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>6</type><title>{content}</title><description>{content}</description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>15</contentStyle><contentSubStyle>0</contentSubStyle><title>{title}</title><description>{description}</description><contentUrl>{contentUrl}</contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName></publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
        /// <summary>
        /// 构建图片模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="contentUrl"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildImageTemplate(string username, string content, WXSnsMedia[] medias, string title, string contentUrl, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>2</type><title></title><description></description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>1</contentStyle><contentSubStyle>0</contentSubStyle><title>{title}</title><description>{description}</description><contentUrl></contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName></publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
        /// <summary>
        /// 构建图片模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="content_url"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildImageTemplate3(string username, string content, WXSnsMedia[] medias, string title, string content_url, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>3</type><title></title><description></description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>1</contentStyle><contentSubStyle>0</contentSubStyle><title></title><description></description><contentUrl></contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName></publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
        /// <summary>
        /// 构建图片模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="content_url"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildImageTemplate4(string username, string content, WXSnsMedia[] medias, string title, string content_url, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>2</type><title></title><description></description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>1</contentStyle><contentSubStyle>0</contentSubStyle><title></title><description></description><contentUrl></contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName></publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
        /// <summary>
        /// 构建图片模板
        /// </summary>
        /// <param name="username"></param>
        /// <param name="content"></param>
        /// <param name="medias"></param>
        /// <param name="title"></param>
        /// <param name="content_url"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string BuildImageTemplate5(string username, string content, WXSnsMedia[] medias, string title, string content_url, string description)
        {
            StringBuilder sb = new StringBuilder();
            if (medias != null && medias.Length > 0)
            {
                foreach (var item in medias)
                {
                    sb.Append($"<media><id>1</id><type>2</type><title></title><description></description><private>0</private><url type=\"1\">{item.ImageUrl}</url><thumb type=\"1\">{item.ImageUrl}</thumb><size height=\"{item.Height}\" width=\"{item.Width}\" totalSize=\"{item.TotalSize}\"></size></media>");
                }
            }
            string template = $"<TimelineObject><id>1</id><username>{username}</username><createTime>1</createTime><contentDescShowType>0</contentDescShowType><contentDescScene>0</contentDescScene><private>0</private><contentDesc>{content}</contentDesc><contentattr>0</contentattr><sourceUserName></sourceUserName><sourceNickName></sourceNickName><statisticsData></statisticsData><weappInfo><appUserName></appUserName><pagePath></pagePath></weappInfo><canvasInfoXml></canvasInfoXml><ContentObject><contentStyle>1</contentStyle><contentSubStyle>0</contentSubStyle><title></title><description></description><contentUrl></contentUrl><mediaList>{sb}</mediaList></ContentObject><actionInfo><appMsg><mediaTagName></mediaTagName><messageExt></messageExt><messageAction></messageAction></appMsg></actionInfo><appInfo><id></id></appInfo><location poiClassifyId=\"\" poiName=\"\" poiAddress=\"\" poiClassifyType=\"0\" city=\"\"></location><publicUserName></publicUserName><streamvideo><streamvideourl></streamvideourl><streamvideothumburl></streamvideothumburl><streamvideoweburl></streamvideoweburl></streamvideo></TimelineObject>";
            return template;
        }
    }
}
