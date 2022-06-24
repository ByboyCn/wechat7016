using System;

namespace WeChat.Core.Protocol.Protos
{
    public class TempLoginResponse
    {
        public int introtype { get; set; } = 999;
        public int ret { get; set; } = 999;
        public Resultdata resultData { get; set; } = new Resultdata();
    }

    public class SliderResponse
    {
        /// <summary>
        /// 0成功,50失败,9过期,202异常,-1未知
        /// </summary>
        public int Status { get; set; } = -1;
        public string Message { get; set; } = "";
        public string RandStr { get; set; } = "";
        public string Ticket { get; set; } = "";
    }

    public class GetUnBanResponse
    {
        public string username { get; set; } = "";
        public string bantype { get; set; } = "";
        public string banreason { get; set; } = "查询失败";
        public int fortune { get; set; }
        public string sectips { get; set; } = "";
        public int showkf { get; set; }
        public int ret { get; set; } = 999;
        public Resultdata resultData { get; set; } = new Resultdata();
    }


    public class GetVerifyWayResponse
    {
        public string cc { get; set; } = "";
        public string mobile { get; set; } = "";

        public String qrcodeticket { get; set; } = "";
        public string friendhelpticket { get; set; } = "";
        public int result { get; set; } = 999;
        public int step { get; set; }
        public string sessionid { get; set; } = "";
        public int showappealurl { get; set; }
        public int secondauthtype { get; set; }
        public Secondauthlist[] secondauthlist { get; set; }
        public Resultdata resultData { get; set; } = new Resultdata();
    }

    public class Secondauthlist
    {
        public int secondauthtype { get; set; }
    }


    public class Resultdata
    {
        public string type { get; set; } = "";
        public string title { get; set; } = "";
        public string desc { get; set; } = "";
        public object[] btns { get; set; }
    }

}
