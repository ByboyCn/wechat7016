using System;

namespace WeChat.Core.Protocol
{
    public enum WXCGIUrl
    {
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindopmobileforreg", Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_bindopmobileforreg = 145,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newreg", RequestID = 32, ResponseID = 1000000032, Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_newreg = 126,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getloginqrcode", RequestID = 232, ResponseID = 1000000232, Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_getloginqrcode = 502,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkloginqrcode", RequestID = 233, ResponseID = 1000000233, Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_checkloginqrcode = 503,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pushloginurl", RequestID = 247, ResponseID = 1000000247, Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_pushloginurl = 654,
        [WXCGIUrl("/cgi-bin/micromsg-bin/manualauth", RequestID = 253, ResponseID = 1000000253, Encode = WXEncode.None, Proxy = true)]
        micromsg_bin_manualauth = 701,
        [WXCGIUrl("/cgi-bin/micromsg-bin/autoauth", RequestID = 254, ResponseID = 1000000254, Encode = WXEncode.None)]
        micromsg_bin_autoauth = 702,
        [WXCGIUrl("/cgi-bin/micromsg-bin/secautoauth", Encode = WXEncode.HYBRID_ECDH)]
        micromsg_bin_secautoauth = 763,
        [WXCGIUrl("/cgi-bin/micromsg-bin/secmanualauth", Encode = WXEncode.HYBRID_ECDH, Proxy = true)]
        micromsg_bin_secmanualauth = 252,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindopmobile", RequestID = 45, ResponseID = 1000000045)]
        micromsg_bin_bindopmobile = 132,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shakereport", RequestID = 56, ResponseID = 1000000056)]
        micromsg_bin_shakereport = 161,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shakeget", RequestID = 57, ResponseID = 1000000057)]
        micromsg_bin_shakeget = 162,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipsync", RequestID = 62, ResponseID = 1000000062)]
        micromsg_bin_voipsync = 174,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipinvite", RequestID = 63, ResponseID = 1000000063)]
        micromsg_bin_voipinvite = 170,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipcancelinvite", RequestID = 64, ResponseID = 1000000064)]
        micromsg_bin_voipcancelinvite = 171,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipanswer", RequestID = 65, ResponseID = 1000000065)]
        micromsg_bin_voipanswer = 172,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipshutdown", RequestID = 66, ResponseID = 1000000066)]
        micromsg_bin_voipshutdown = 173,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendemoji", RequestID = 68, ResponseID = 1000000068)]
        micromsg_bin_sendemoji = 175,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipgetroominfo", RequestID = 119, ResponseID = 1000000119)]
        micromsg_bin_voipgetroominfo = 303,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipack", RequestID = 123, ResponseID = 1000000123)]
        micromsg_bin_voipack = 305,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipinviteremind", RequestID = 125, ResponseID = 1000000125)]
        micromsg_bin_voipinviteremind = 306,
        [WXCGIUrl("/cgi-bin/micromsg-bin/masssend", RequestID = 84, ResponseID = 1000000084)]
        micromsg_bin_masssend = 193,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newsetpasswd", RequestID = 180, ResponseID = 1000000180, Proxy = false)]
        micromsg_bin_newsetpasswd = 383,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadvideo", RequestID = 39, ResponseID = 1000000039)]
        micromsg_bin_uploadvideo = 149,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadvoice", RequestID = 19, ResponseID = 1000000019)]
        micromsg_bin_uploadvoice = 127,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addchatroommember", RequestID = 36, ResponseID = 1000000036)]
        micromsg_bin_addchatroommember = 120,
        [WXCGIUrl("/cgi-bin/micromsg-bin/createchatroom", RequestID = 37, ResponseID = 1000000037)]
        micromsg_bin_createchatroom = 119,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getprofile", RequestID = 118, ResponseID = 1000000118)]
        micromsg_bin_getprofile = 302,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadhdheadimg", RequestID = 46, ResponseID = 1000000046)]
        micromsg_bin_uploadhdheadimg = 157,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendappmsg", RequestID = 107, ResponseID = 1000000107)]
        micromsg_bin_sendappmsg = 222,
        [WXCGIUrl("/cgi-bin/micromsg-bin/geta8key", RequestID = 155, ResponseID = 1000000155)]
        micromsg_bin_geta8key = 233,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mp-geta8key", RequestID = 345, ResponseID = 1000000345)]
        micromsg_bin_mp_geta8key = 238,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pay-geta8key", RequestID = 346, ResponseID = 1000000346)]
        micromsg_bin_pay_geta8key = 835,
        [WXCGIUrl("/cgi-bin/micromsg-bin/minor-geta8key", RequestID = 387, ResponseID = 1000000387)]
        micromsg_bin_minor_geta8key = 812,
        [WXCGIUrl("/cgi-bin/micromsg-bin/3rd-geta8key", RequestID = 388, ResponseID = 1000000388)]
        micromsg_bin_3rd_geta8key = 226,
        [WXCGIUrl("/cgi-bin/micromsg-bin/searchcontact", RequestID = 34, ResponseID = 1000000034)]
        micromsg_bin_searchcontact = 106,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyuser", RequestID = 44, ResponseID = 1000000044)]
        micromsg_bin_verifyuser = 137,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voiceaddr", RequestID = 94, ResponseID = 1000000094)]
        micromsg_bin_voiceaddr = 206,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shaketranimgreport", RequestID = 127, ResponseID = 1000000127)]
        micromsg_bin_shaketranimgreport = 316,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shaketranimgunbind", RequestID = 130, ResponseID = 1000000130)]
        micromsg_bin_shaketranimgunbind = 319,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newverifypasswd", RequestID = 182, ResponseID = 1000000182, Proxy = false)]
        micromsg_bin_newverifypasswd = 384,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkunbind", RequestID = 131, ResponseID = 1000000131)]
        micromsg_bin_checkunbind = 254,
        [WXCGIUrl("/cgi-bin/micromsg-bin/queryhaspasswd", RequestID = 132, ResponseID = 1000000132)]
        micromsg_bin_queryhaspasswd = 255,
        [WXCGIUrl("/cgi-bin/micromsg-bin/opvoicereminder", RequestID = 150, ResponseID = 1000000150)]
        micromsg_bin_opvoicereminder = 331,
        [WXCGIUrl("/cgi-bin/micromsg-bin/talkmicaction", RequestID = 146, ResponseID = 1000000146)]
        micromsg_bin_talkmicaction = 334,
        [WXCGIUrl("/cgi-bin/micromsg-bin/talknoop", RequestID = 149, ResponseID = 1000000149)]
        micromsg_bin_talknoop = 335,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadmsgimg", RequestID = 9, ResponseID = 1000000009)]
        micromsg_bin_uploadmsgimg = 110,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadinputvoice", RequestID = 158, ResponseID = 1000000158)]
        micromsg_bin_uploadinputvoice = 349,
        [WXCGIUrl("/cgi-bin/micromsg-bin/clickcommand", RequestID = 176, ResponseID = 1000000176)]
        micromsg_bin_clickcommand = 359,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shakemusic", RequestID = 177, ResponseID = 1000000177)]
        micromsg_bin_shakemusic = 367,
        [WXCGIUrl("/cgi-bin/micromsg-bin/joinlbsroom", RequestID = 183, ResponseID = 1000000183)]
        micromsg_bin_joinlbsroom = 376,
        [WXCGIUrl("/cgi-bin/micromsg-bin/tenpay", RequestID = 185, ResponseID = 1000000185)]
        micromsg_bin_tenpay = 385,
        [WXCGIUrl("/cgi-bin/micromsg-bin/paydeluserroll", RequestID = 187, ResponseID = 1000000187)]
        micromsg_bin_paydeluserroll = 389,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payauthapp", RequestID = 373, ResponseID = 1000000373)]
        mmpay_bin_payauthapp = 397,
        [WXCGIUrl("/cgi-bin/mmpay-bin/genprepay", RequestID = 372, ResponseID = 1000000372)]
        mmpay_bin_genprepay = 398,
        [WXCGIUrl("/cgi-bin/mmpay-bin/cancelqrpay", RequestID = 409, ResponseID = 1000000409)]
        mmpay_bin_cancelqrpay = 410,
        [WXCGIUrl("/cgi-bin/mmpay-bin/checkpayjsapi", RequestID = 371, ResponseID = 1000000371)]
        mmpay_bin_checkpayjsapi = 580,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_cancelpay", RequestID = 404, ResponseID = 1000000404)]
        mmpay_bin_tenpay_ts_cancelpay = 2823,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_cancelpay", RequestID = 494, ResponseID = 1000000494)]
        mmpay_bin_tenpay_sns_ff_cancelpay = 2722,
        [WXCGIUrl("/cgi-bin/mmpay-bin/offlinepayconfirm", RequestID = 376, ResponseID = 1000000376)]
        mmpay_bin_offlinepayconfirm = 609,
        [WXCGIUrl("/cgi-bin/mmpay-bin/paysubscribe", RequestID = 374, ResponseID = 1000000374)]
        mmpay_bin_paysubscribe = 421,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmradarsearch", RequestID = 209, ResponseID = 1000000209)]
        micromsg_bin_mmradarsearch = 425,
        [WXCGIUrl("/cgi-bin/micromsg-bin/iphonereg", RequestID = 4, ResponseID = 1000000004)]
        micromsg_bin_iphonereg = 105,
        [WXCGIUrl("/cgi-bin/micromsg-bin/heartbeat", RequestID = 238, ResponseID = 1000000238)]
        micromsg_bin_heartbeat = 518,
        [WXCGIUrl("/cgi-bin/micromsg-bin/festivalhongbao2016", RequestID = 515, ResponseID = 1000000515)]
        micromsg_bin_festivalhongbao2016 = 515,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newsendmsg", RequestID = 237, ResponseID = 1000000237)]
        micromsg_bin_newsendmsg = 522,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcrmsg", RequestID = 257, ResponseID = 1000000257)]
        micromsg_bin_getcrmsg = 805,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/authen", RequestID = 407, ResponseID = 1000000407)]
        mmpay_bin_tenpay_authen = 461,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/saveauthen", RequestID = 402, ResponseID = 1000000402)]
        mmpay_bin_tenpay_saveauthen = 1610,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/fetchauthen", RequestID = 399, ResponseID = 1000000399)]
        mmpay_bin_tenpay_fetchauthen = 1605,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/verify", RequestID = 417, ResponseID = 1000000417)]
        mmpay_bin_tenpay_verify = 462,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/saveverify", RequestID = 412, ResponseID = 1000000412)]
        mmpay_bin_tenpay_saveverify = 1607,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/fetchverify", RequestID = 419, ResponseID = 1000000419)]
        mmpay_bin_tenpay_fetchverify = 1606,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/qrcodeuse", RequestID = 427, ResponseID = 1000000427)]
        mmpay_bin_tenpay_qrcodeuse = 465,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/verifyreg", RequestID = 420, ResponseID = 1000000420)]
        mmpay_bin_tenpay_verifyreg = 474,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/saveverifyreg", RequestID = 416, ResponseID = 1000000416)]
        mmpay_bin_tenpay_saveverifyreg = 1684,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/fetchverifyreg", RequestID = 423, ResponseID = 1000000423)]
        mmpay_bin_tenpay_fetchverifyreg = 1608,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/checkpwd", RequestID = 360, ResponseID = 1000000360)]
        mmpay_bin_tenpay_checkpwd = 476,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinecreate", RequestID = 375, ResponseID = 1000000375)]
        mmpay_bin_tenpay_offlinecreate = 565,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinequeryuser", RequestID = 377, ResponseID = 1000000377)]
        mmpay_bin_tenpay_offlinequeryuser = 568,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinegettoken", RequestID = 400, ResponseID = 1000000400)]
        mmpay_bin_tenpay_offlinegettoken = 571,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/savebindquery", RequestID = 410, ResponseID = 1000000410)]
        mmpay_bin_tenpay_savebindquery = 2750,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/fetchbindquery", RequestID = 422, ResponseID = 1000000422)]
        mmpay_bin_tenpay_fetchbindquery = 2687,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/elementquerynew", RequestID = 359, ResponseID = 1000000359)]
        mmpay_bin_tenpay_elementquerynew = 1505,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/genpresave", RequestID = 401, ResponseID = 1000000401)]
        mmpay_bin_tenpay_genpresave = 1502,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/genprefetch", RequestID = 397, ResponseID = 1000000397)]
        mmpay_bin_tenpay_genprefetch = 1503,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/verifybind", RequestID = 361, ResponseID = 1000000361)]
        mmpay_bin_tenpay_verifybind = 1506,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/qrcodeusebindquery", RequestID = 403, ResponseID = 1000000403)]
        mmpay_bin_tenpay_qrcodeusebindquery = 1593,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/banpaybindauthen", RequestID = 364, ResponseID = 1000000364)]
        mmpay_bin_tenpay_banpaybindauthen = 1600,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/banpaybindverify", RequestID = 365, ResponseID = 1000000365)]
        mmpay_bin_tenpay_banpaybindverify = 1601,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getbanpaymobileinfo", RequestID = 363, ResponseID = 1000000363)]
        mmpay_bin_tenpay_getbanpaymobileinfo = 1667,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getpaypwdtoken", RequestID = 411, ResponseID = 1000000411)]
        mmpay_bin_getpaypwdtoken = 2704,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/gendigitalcert", RequestID = 378, ResponseID = 1000000378)]
        mmpay_bin_tenpay_gendigitalcert = 1580,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/deletedigitalcert", RequestID = 379, ResponseID = 1000000379)]
        mmpay_bin_tenpay_deletedigitalcert = 1568,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/payauthnative", RequestID = 431, ResponseID = 1000000431)]
        mmpay_bin_tenpay_payauthnative = 1694,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sendpayaward", RequestID = 362, ResponseID = 1000000362)]
        mmpay_bin_tenpay_sendpayaward = 1589,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/payorderquery", RequestID = 415, ResponseID = 1000000415)]
        mmpay_bin_tenpay_payorderquery = 1525,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinegetmsg", RequestID = 396, ResponseID = 1000000396)]
        mmpay_bin_tenpay_offlinegetmsg = 1981,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineackmsg", RequestID = 398, ResponseID = 1000000398)]
        mmpay_bin_tenpay_offlineackmsg = 1230,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinequeryorder", RequestID = 414, ResponseID = 1000000414)]
        mmpay_bin_tenpay_offlinequeryorder = 1318,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinecancelpay", RequestID = 413, ResponseID = 1000000413)]
        mmpay_bin_tenpay_offlinecancelpay = 1385,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-login", RequestID = 392, ResponseID = 1000000392)]
        mmbiz_bin_js_login = 1029,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-refreshsession", RequestID = 395, ResponseID = 1000000395)]
        mmbiz_bin_js_refreshsession = 1196,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-userauth", RequestID = 393, ResponseID = 1000000393)]
        mmbiz_bin_js_userauth = 1116,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-usersetauth", RequestID = 394, ResponseID = 1000000394)]
        mmbiz_bin_js_usersetauth = 1027,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaattr/wxaattrsync", RequestID = 390, ResponseID = 1000000390)]
        mmbiz_bin_wxaattr_wxaattrsync = 1151,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getwxacdndownloadurl", RequestID = 391, ResponseID = 1000000391)]
        mmbiz_bin_wxaapp_getwxacdndownloadurl = 1139,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaattr/launchwxaapp", RequestID = 389, ResponseID = 1000000389)]
        mmbiz_bin_wxaattr_launchwxaapp = 1122,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fplaceorder", RequestID = 466, ResponseID = 1000000466)]
        mmpay_bin_f2fplaceorder = 1582,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transfersetf2ffee", RequestID = 467, ResponseID = 1000000467)]
        mmpay_bin_transfersetf2ffee = 1623,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferscanqrcode", RequestID = 468, ResponseID = 1000000468)]
        mmpay_bin_transferscanqrcode = 1515,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transfersendcancelf2f", RequestID = 469, ResponseID = 1000000469)]
        mmpay_bin_transfersendcancelf2f = 1535,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_authen", RequestID = 489, ResponseID = 1000000489)]
        mmpay_bin_tenpay_sns_ff_authen = 1536,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_verify", RequestID = 490, ResponseID = 1000000490)]
        mmpay_bin_tenpay_sns_ff_verify = 1591,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_verifyreg", RequestID = 491, ResponseID = 1000000491)]
        mmpay_bin_tenpay_sns_ff_verifyreg = 1517,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_qrcodeusebindquery", RequestID = 492, ResponseID = 1000000492)]
        mmpay_bin_tenpay_sns_ff_qrcodeusebindquery = 1543,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_ff_payorderquery", RequestID = 493, ResponseID = 1000000493)]
        mmpay_bin_tenpay_sns_ff_payorderquery = 1656,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_authen", RequestID = 383, ResponseID = 1000000383)]
        mmpay_bin_tenpay_ts_authen = 1552,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_verify", RequestID = 384, ResponseID = 1000000384)]
        mmpay_bin_tenpay_ts_verify = 1699,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_verifyreg", RequestID = 430, ResponseID = 1000000430)]
        mmpay_bin_tenpay_ts_verifyreg = 1559,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_qrcodeusebindquery", RequestID = 385, ResponseID = 1000000385)]
        mmpay_bin_tenpay_ts_qrcodeusebindquery = 1573,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/ts_payorderquery", RequestID = 386, ResponseID = 1000000386)]
        mmpay_bin_tenpay_ts_payorderquery = 1692,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineqrcodeusebindquery", RequestID = 406, ResponseID = 1000000406)]
        mmpay_bin_tenpay_offlineqrcodeusebindquery = 1953,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinepayauthen", RequestID = 405, ResponseID = 1000000405)]
        mmpay_bin_tenpay_offlinepayauthen = 1972,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2frcvdlist", RequestID = 474, ResponseID = 1000000474)]
        mmpay_bin_f2frcvdlist = 1963,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2frmrcvdrcd", RequestID = 475, ResponseID = 1000000475)]
        mmpay_bin_f2frmrcvdrcd = 1964,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2frcvrcdhissta", RequestID = 476, ResponseID = 1000000476)]
        mmpay_bin_f2frcvrcdhissta = 1993,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2frcvdlistjsapicheck", RequestID = 477, ResponseID = 1000000477)]
        mmpay_bin_f2frcvdlistjsapicheck = 1973,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voicetrans", RequestID = 381, ResponseID = 1000000381)]
        micromsg_bin_voicetrans = 235,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fpaycheck", RequestID = 471, ResponseID = 1000000471)]
        mmpay_bin_f2fpaycheck = 1273,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getf2frcvvoice", RequestID = 478, ResponseID = 1000000478)]
        mmpay_bin_getf2frcvvoice = 1384,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fannounce", RequestID = 472, ResponseID = 1000000472)]
        mmpay_bin_f2fannounce = 1256,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/lqtpaybindauthen", RequestID = 425, ResponseID = 1000000425)]
        mmpay_bin_tenpay_lqtpaybindauthen = 1259,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/lqtpaybindverify", RequestID = 418, ResponseID = 1000000418)]
        mmpay_bin_tenpay_lqtpaybindverify = 1305,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fqrcode", RequestID = 473, ResponseID = 1000000473)]
        mmpay_bin_f2fqrcode = 1588,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fplaceorder", RequestID = 479, ResponseID = 1000000479)]
        mmpay_bin_busif2fplaceorder = 1633,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fpayok", RequestID = 481, ResponseID = 1000000481)]
        mmpay_bin_busif2fpayok = 1537,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2factqry", RequestID = 482, ResponseID = 1000000482)]
        mmpay_bin_busif2factqry = 1680,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fpaycheck", RequestID = 480, ResponseID = 1000000480)]
        mmpay_bin_busif2fpaycheck = 1241,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fgetfavor", RequestID = 484, ResponseID = 1000000484)]
        mmpay_bin_busif2fgetfavor = 2677,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2funlockfavor", RequestID = 483, ResponseID = 1000000483)]
        mmpay_bin_busif2funlockfavor = 2702,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fsucpage", RequestID = 486, ResponseID = 1000000486)]
        mmpay_bin_busif2fsucpage = 2504,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busif2fzerocallback", RequestID = 487, ResponseID = 1000000487)]
        mmpay_bin_busif2fzerocallback = 2682,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newsync", RequestID = 121, ResponseID = 1000000121)]
        micromsg_bin_newsync = 138,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newinit", RequestID = 27, ResponseID = 1000000027)]
        micromsg_bin_newinit = 139,
        [WXCGIUrl("/cgi-bin/mmpay-bin/checkuserauthjsapi", RequestID = 432, ResponseID = 1000000432)]
        mmpay_bin_checkuserauthjsapi = 2728,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fsucpage", RequestID = 485, ResponseID = 1000000485)]
        mmpay_bin_f2fsucpage = 2773,
        [WXCGIUrl("/cgi-bin/mmpay-bin/f2fdynamiccode", RequestID = 488, ResponseID = 1000000488)]
        mmpay_bin_f2fdynamiccode = 2736,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpackagelist")]
        micromsg_bin_getpackagelist = 159,
        [WXCGIUrl("/cgi-bin/micromsg-bin/downloadpackage")]
        micromsg_bin_downloadpackage = 160,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shakeimg")]
        micromsg_bin_shakeimg = 165,
        [WXCGIUrl("/cgi-bin/micromsg-bin/expose")]
        micromsg_bin_expose = 166,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getvuserinfo")]
        micromsg_bin_getvuserinfo = 167,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getmfriend")]
        micromsg_bin_getmfriend = 142,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getqrcode")]
        micromsg_bin_getqrcode = 168,
        [WXCGIUrl("/cgi-bin/micromsg-bin/revokechatroomqrcode")]
        micromsg_bin_revokechatroomqrcode = 700,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gmailoper")]
        micromsg_bin_gmailoper = 169,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipheartbeat")]
        micromsg_bin_voipheartbeat = 178,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipdoublelinkswitch")]
        micromsg_bin_voipdoublelinkswitch = 249,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipstatreport")]
        micromsg_bin_voipstatreport = 320,
        [WXCGIUrl("/cgi-bin/micromsg-bin/generalset")]
        micromsg_bin_generalset = 177,
        [WXCGIUrl("/cgi-bin/micromsg-bin/delchatroommember")]
        micromsg_bin_delchatroommember = 179,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcontact")]
        micromsg_bin_getcontact = 182,
        [WXCGIUrl("/cgi-bin/micromsg-bin/facebookauth")]
        micromsg_bin_facebookauth = 183,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendsight")]
        micromsg_bin_sendsight = 245,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendfeedback")]
        micromsg_bin_sendfeedback = 153,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendcard")]
        micromsg_bin_sendcard = 131,
        [WXCGIUrl("/cgi-bin/micromsg-bin/downloadvideo")]
        micromsg_bin_downloadvideo = 150,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getmsgimg")]
        micromsg_bin_getmsgimg = 109,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendverifyemail")]
        micromsg_bin_sendverifyemail = 108,
        [WXCGIUrl("/cgi-bin/micromsg-bin/switchpushmail")]
        micromsg_bin_switchpushmail = 129,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadmcontact")]
        micromsg_bin_uploadmcontact = 133,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadvoicerecognize")]
        micromsg_bin_uploadvoicerecognize = 329,
        [WXCGIUrl("/cgi-bin/micromsg-bin/downloadvoice")]
        micromsg_bin_downloadvoice = 128,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pickbottle")]
        micromsg_bin_pickbottle = 155,
        [WXCGIUrl("/cgi-bin/micromsg-bin/openbottle")]
        micromsg_bin_openbottle = 156,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getbottlecount")]
        micromsg_bin_getbottlecount = 152,
        [WXCGIUrl("/cgi-bin/micromsg-bin/throwbottle")]
        micromsg_bin_throwbottle = 154,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/fetchdata")]
        mmbiz_bin_wxabusiness_fetchdata = 1733,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getprofileinfo")]
        mmbiz_bin_wxabusiness_getprofileinfo = 2921,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/updateevaluate")]
        mmbiz_bin_wxabusiness_updateevaluate = 2521,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsupload")]
        micromsg_bin_mmsnsupload = 207,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnspost")]
        micromsg_bin_mmsnspost = 209,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsobjectdetail")]
        micromsg_bin_mmsnsobjectdetail = 210,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstimeline")]
        micromsg_bin_mmsnstimeline = 211,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsuserpage")]
        micromsg_bin_mmsnsuserpage = 212,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnscomment")]
        micromsg_bin_mmsnscomment = 213,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnssync")]
        micromsg_bin_mmsnssync = 214,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsobjectop")]
        micromsg_bin_mmsnsobjectop = 218,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstagoption")]
        micromsg_bin_mmsnstagoption = 290,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstagmemberoption")]
        micromsg_bin_mmsnstagmemberoption = 291,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstaglist")]
        micromsg_bin_mmsnstaglist = 292,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstagmemmutilset")]
        micromsg_bin_mmsnstagmemmutilset = 293,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnspreloadingtimeline")]
        micromsg_bin_mmsnspreloadingtimeline = 718,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstorypost")]
        micromsg_bin_mmstorypost = 351,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstorycomment")]
        micromsg_bin_mmstorycomment = 354,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryuserpage")]
        micromsg_bin_mmstoryuserpage = 273,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstorysync")]
        micromsg_bin_mmstorysync = 513,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryobjectop")]
        micromsg_bin_mmstoryobjectop = 764,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstorychatroomsync")]
        micromsg_bin_mmstorychatroomsync = 998,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryhistorypage")]
        micromsg_bin_mmstoryhistorypage = 191,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstorydatedetail")]
        micromsg_bin_mmstorydatedetail = 529,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryobjectdetail")]
        micromsg_bin_mmstoryobjectdetail = 186,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryfeaturedpage")]
        micromsg_bin_mmstoryfeaturedpage = 3926,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmstoryobjectcomments")]
        micromsg_bin_mmstoryobjectcomments = 3985,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetheadimg")]
        micromsg_bin_batchgetheadimg = 123,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gethdheadimg")]
        micromsg_bin_gethdheadimg = 158,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadappattach")]
        micromsg_bin_uploadappattach = 220,
        [WXCGIUrl("/cgi-bin/micromsg-bin/downloadappattach")]
        micromsg_bin_downloadappattach = 221,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getappinfo")]
        micromsg_bin_getappinfo = 231,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getrecommendapplist")]
        micromsg_bin_getrecommendapplist = 232,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getappinfolist")]
        micromsg_bin_getappinfolist = 451,
        [WXCGIUrl("/cgi-bin/micromsg-bin/logoutwebwx")]
        micromsg_bin_logoutwebwx = 281,
        [WXCGIUrl("/cgi-bin/micromsg-bin/statusnotify")]
        micromsg_bin_statusnotify = 251,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setpushsound")]
        micromsg_bin_setpushsound = 304,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportstrategy")]
        micromsg_bin_reportstrategy = 308,
        [WXCGIUrl("/cgi-bin/micromsg-bin/kvreport")]
        micromsg_bin_kvreport = 310,
        [WXCGIUrl("/cgi-bin/micromsg-bin/useractionreport")]
        micromsg_bin_useractionreport = 311,
        [WXCGIUrl("/cgi-bin/micromsg-bin/clientperfreport")]
        micromsg_bin_clientperfreport = 309,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shaketranimgget")]
        micromsg_bin_shaketranimgget = 317,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetshaketranimg")]
        micromsg_bin_batchgetshaketranimg = 318,
        [WXCGIUrl("/cgi-bin/micromsg-bin/unbindqq")]
        micromsg_bin_unbindqq = 253,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindqq")]
        micromsg_bin_bindqq = 144,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindemail")]
        micromsg_bin_bindemail = 256,
        [WXCGIUrl("/cgi-bin/micromsg-bin/logout")]
        micromsg_bin_logout = 282,
        [WXCGIUrl("/cgi-bin/micromsg-bin/entertalkroom")]
        micromsg_bin_entertalkroom = 332,
        [WXCGIUrl("/cgi-bin/micromsg-bin/exittalkroom")]
        micromsg_bin_exittalkroom = 333,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gettalkroommember")]
        micromsg_bin_gettalkroommember = 336,
        [WXCGIUrl("/cgi-bin/micromsg-bin/talkstatreport")]
        micromsg_bin_talkstatreport = 373,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatuploadhead")]
        micromsg_bin_bakchatuploadhead = 321,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatuploadend")]
        micromsg_bin_bakchatuploadend = 322,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatuploadmsg")]
        micromsg_bin_bakchatuploadmsg = 323,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatuploadmedia")]
        micromsg_bin_bakchatuploadmedia = 324,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatrecovergetlist")]
        micromsg_bin_bakchatrecovergetlist = 325,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatrecoverhead")]
        micromsg_bin_bakchatrecoverhead = 326,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatrecoverdata")]
        micromsg_bin_bakchatrecoverdata = 327,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatdelete")]
        micromsg_bin_bakchatdelete = 328,
        [WXCGIUrl("/cgi-bin/micromsg-bin/grantbigchatroom")]
        micromsg_bin_grantbigchatroom = 339,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendqrcodebyemail")]
        micromsg_bin_sendqrcodebyemail = 340,
        [WXCGIUrl("/cgi-bin/micromsg-bin/updatesafedevice")]
        micromsg_bin_updatesafedevice = 361,
        [WXCGIUrl("/cgi-bin/micromsg-bin/delsafedevice")]
        micromsg_bin_delsafedevice = 362,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportcommand")]
        micromsg_bin_reportcommand = 2592,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportshow")]
        micromsg_bin_reportshow = 2645,
        [WXCGIUrl("/cgi-bin/micromsg-bin/often_read_bar_report")]
        micromsg_bin_often_read_bar_report = 2550,
        [WXCGIUrl("/cgi-bin/micromsg-bin/statreport")]
        micromsg_bin_statreport = 250,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getroommember")]
        micromsg_bin_getroommember = 377,
        [WXCGIUrl("/cgi-bin/micromsg-bin/appcommentreport")]
        micromsg_bin_appcommentreport = 378,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcdndns")]
        micromsg_bin_getcdndns = 379,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcert")]
        micromsg_bin_getcert = 381,
        [WXCGIUrl("/cgi-bin/micromsg-bin/payqueryuserroll")]
        micromsg_bin_payqueryuserroll = 388,
        [WXCGIUrl("/cgi-bin/micromsg-bin/ibeaconboardcast")]
        micromsg_bin_ibeaconboardcast = 658,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getbeaconsingroup")]
        mmo2o_bin_getbeaconsingroup = 1704,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getbeaconspushmessage")]
        mmo2o_bin_getbeaconspushmessage = 1708,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/verifybeaconjspermission")]
        mmo2o_bin_verifybeaconjspermission = 1702,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetcontactprofile")]
        micromsg_bin_batchgetcontactprofile = 140,
        [WXCGIUrl("/cgi-bin/micromsg-bin/ocrtranslation")]
        micromsg_bin_ocrtranslation = 392,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newocrtranslation")]
        micromsg_bin_newocrtranslation = 294,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscanimg")]
        mmbiz_bin_usrmsg_bizscanimg = 1062,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/jsapi-preverify")]
        mmbiz_bin_jsapi_preverify = 1093,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/jsapi-realtimeverify")]
        mmbiz_bin_jsapi_realtimeverify = 1094,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/jsapi-auth")]
        mmbiz_bin_jsapi_auth = 1095,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/jsapi-setauth")]
        mmbiz_bin_jsapi_setauth = 1096,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/translatelink")]
        mmbiz_bin_translatelink = 1200,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/entertempsession")]
        mmbiz_bin_usrmsg_entertempsession = 1066,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/deltempsession")]
        mmbiz_bin_usrmsg_deltempsession = 1067,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/uploadsoterauthkey")]
        mmbiz_bin_usrmsg_uploadsoterauthkey = 1185,
        [WXCGIUrl("/cgi-bin/micromsg-bin/appcenter")]
        micromsg_bin_appcenter = 452,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getauthapplist")]
        micromsg_bin_getauthapplist = 394,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setappsetting")]
        micromsg_bin_setappsetting = 396,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getappsetting")]
        micromsg_bin_getappsetting = 395,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getsuggestionapplist")]
        micromsg_bin_getsuggestionapplist = 409,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gamereportkv")]
        micromsg_bin_gamereportkv = 427,
        [WXCGIUrl("/cgi-bin/micromsg-bin/submitpayproductbuyinfo")]
        micromsg_bin_submitpayproductbuyinfo = 1553,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_cancelpay")]
        mmpay_bin_tenpay_sns_aa_cancelpay = 2533,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_cancelpay")]
        mmpay_bin_tenpay_sns_tf_cancelpay = 2958,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_cancelpay")]
        mmpay_bin_tenpay_sns_cancelpay = 2976,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/unicancelpay")]
        mmpay_bin_tenpay_unicancelpay = 2705,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_cancelpay")]
        mmpay_bin_tenpay_seb_ff_cancelpay = 2820,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_cancelpay")]
        mmpay_bin_tenpay_tax_cancelpay = 2652,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_cancelpay")]
        mmpay_bin_tenpay_dc_cancelpay = 2849,
        [WXCGIUrl("/cgi-bin/micromsg-bin/removevirtualbankcard")]
        micromsg_bin_removevirtualbankcard = 600,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getofflinepayinfo")]
        micromsg_bin_getofflinepayinfo = 606,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/querywechatwallet")]
        mmpay_bin_tenpay_querywechatwallet = 2672,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getbalancemenu")]
        mmpay_bin_tenpay_getbalancemenu = 2567,
        [WXCGIUrl("/cgi-bin/mmpay-bin/querywalletentrancebalanceswitchstate")]
        mmpay_bin_querywalletentrancebalanceswitchstate = 2635,
        [WXCGIUrl("/cgi-bin/mmpay-bin/setwalletentrancebalanceswitchstate")]
        mmpay_bin_setwalletentrancebalanceswitchstate = 2554,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setmainbankcard")]
        micromsg_bin_setmainbankcard = 621,
        [WXCGIUrl("/cgi-bin/micromsg-bin/favsync")]
        micromsg_bin_favsync = 400,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addfavitem")]
        micromsg_bin_addfavitem = 401,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchdelfavitem")]
        micromsg_bin_batchdelfavitem = 403,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetfavitem")]
        micromsg_bin_batchgetfavitem = 402,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkfavitem")]
        micromsg_bin_checkfavitem = 405,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkcdn")]
        micromsg_bin_checkcdn = 404,
        [WXCGIUrl("/cgi-bin/micromsg-bin/modfavitem")]
        micromsg_bin_modfavitem = 426,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchmodfavitem")]
        micromsg_bin_batchmodfavitem = 649,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getfavinfo")]
        micromsg_bin_getfavinfo = 438,
        [WXCGIUrl("/cgi-bin/micromsg-bin/favsecurity")]
        micromsg_bin_favsecurity = 921,
        [WXCGIUrl("/cgi-bin/micromsg-bin/shaketv")]
        micromsg_bin_shaketv = 408,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinfoadd")]
        micromsg_bin_rcptinfoadd = 415,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinfoquery")]
        micromsg_bin_rcptinfoquery = 417,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinforemove")]
        micromsg_bin_rcptinforemove = 416,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinfotouch")]
        micromsg_bin_rcptinfotouch = 419,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinfoupdate")]
        micromsg_bin_rcptinfoupdate = 418,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rcptinfoimport")]
        micromsg_bin_rcptinfoimport = 582,
        [WXCGIUrl("/cgi-bin/micromsg-bin/upgradechatroom")]
        micromsg_bin_upgradechatroom = 482,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getchatroomupgradestatus")]
        micromsg_bin_getchatroomupgradestatus = 519,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getchatroommemberdetail")]
        micromsg_bin_getchatroommemberdetail = 551,
        [WXCGIUrl("/cgi-bin/micromsg-bin/invitechatroommember")]
        micromsg_bin_invitechatroommember = 610,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getemotionlist")]
        micromsg_bin_getemotionlist = 411,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getemotiondetail")]
        micromsg_bin_getemotiondetail = 412,
        [WXCGIUrl("/cgi-bin/micromsg-bin/modemotionpack")]
        micromsg_bin_modemotionpack = 413,
        [WXCGIUrl("/cgi-bin/micromsg-bin/exchangeemotionpack")]
        micromsg_bin_exchangeemotionpack = 423,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getemotiondesc")]
        micromsg_bin_getemotiondesc = 521,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmgetpersonaldesigner")]
        micromsg_bin_mmgetpersonaldesigner = 720,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmgetemotionreward")]
        micromsg_bin_mmgetemotionreward = 822,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmgetemotiondonorlist")]
        micromsg_bin_mmgetemotiondonorlist = 299,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmaskforreward")]
        micromsg_bin_mmaskforreward = 830,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmgetdesigneremojilist")]
        micromsg_bin_mmgetdesigneremojilist = 821,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmgetdesignersimpleinfo")]
        micromsg_bin_mmgetdesignersimpleinfo = 239,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getemotionactivity")]
        micromsg_bin_getemotionactivity = 368,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmemojitextantispam")]
        micromsg_bin_mmemojitextantispam = 532,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkresupdate")]
        micromsg_bin_checkresupdate = 721,
        [WXCGIUrl("/cgi-bin/micromsg-bin/encryptcheckresupdate")]
        micromsg_bin_encryptcheckresupdate = 722,
        [WXCGIUrl("/cgi-bin/micromsg-bin/secencryptcheckresupdate")]
        micromsg_bin_secencryptcheckresupdate = 784,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscanbarcode")]
        mmbiz_bin_usrmsg_bizscanbarcode = 1061,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifypurchase")]
        micromsg_bin_verifypurchase = 414,
        [WXCGIUrl("/cgi-bin/micromsg-bin/preparepurchase")]
        micromsg_bin_preparepurchase = 422,
        [WXCGIUrl("/cgi-bin/micromsg-bin/cancelpurchase")]
        micromsg_bin_cancelpurchase = 486,
        [WXCGIUrl("/cgi-bin/micromsg-bin/scanstreetview")]
        micromsg_bin_scanstreetview = 424,
        [WXCGIUrl("/cgi-bin/micromsg-bin/listmfriend")]
        micromsg_bin_listmfriend = 431,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendsmstomfriend")]
        micromsg_bin_sendsmstomfriend = 432,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendphoto2fbwall")]
        micromsg_bin_sendphoto2fbwall = 433,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscanlicense")]
        mmbiz_bin_usrmsg_bizscanlicense = 1160,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscangetproductinfo")]
        mmbiz_bin_usrmsg_bizscangetproductinfo = 1063,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscanproductreport")]
        mmbiz_bin_usrmsg_bizscanproductreport = 1064,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/bizscangetactioninfo")]
        mmbiz_bin_usrmsg_bizscangetactioninfo = 1068,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getproductdetail")]
        micromsg_bin_getproductdetail = 553,
        [WXCGIUrl("/cgi-bin/micromsg-bin/presubmitorder")]
        micromsg_bin_presubmitorder = 554,
        [WXCGIUrl("/cgi-bin/micromsg-bin/cancelpreorder")]
        micromsg_bin_cancelpreorder = 555,
        [WXCGIUrl("/cgi-bin/micromsg-bin/submitmallorder")]
        micromsg_bin_submitmallorder = 556,
        [WXCGIUrl("/cgi-bin/micromsg-bin/submitmallfreeorder")]
        micromsg_bin_submitmallfreeorder = 557,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getlastestexpressinfo")]
        micromsg_bin_getlastestexpressinfo = 578,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getproductdiscount")]
        micromsg_bin_getproductdiscount = 579,
        [WXCGIUrl("/cgi-bin/micromsg-bin/searchorrecommendbiz")]
        micromsg_bin_searchorrecommendbiz = 455,
        [WXCGIUrl("/cgi-bin/micromsg-bin/grouprecommendbiz")]
        micromsg_bin_grouprecommendbiz = 456,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportkvcomm")]
        micromsg_bin_reportkvcomm = 430,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportkvcommrsa")]
        micromsg_bin_reportkvcommrsa = 499,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getupdateinfo")]
        micromsg_bin_getupdateinfo = 113,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newreportidkey")]
        micromsg_bin_newreportidkey = 986,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newreportidkeyrsa")]
        micromsg_bin_newreportidkeyrsa = 987,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newreportkvcomm")]
        micromsg_bin_newreportkvcomm = 996,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newreportkvcommrsa")]
        micromsg_bin_newreportkvcommrsa = 997,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getkvidkeystrategy")]
        micromsg_bin_getkvidkeystrategy = 988,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getkvidkeystrategyrsa")]
        micromsg_bin_getkvidkeystrategyrsa = 989,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportidkey")]
        micromsg_bin_reportidkey = 693,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportidkeyrsa")]
        micromsg_bin_reportidkeyrsa = 694,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindgooglecontact")]
        micromsg_bin_bindgooglecontact = 487,
        [WXCGIUrl("/cgi-bin/micromsg-bin/invitegooglecontact")]
        micromsg_bin_invitegooglecontact = 489,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpoilist")]
        micromsg_bin_getpoilist = 457,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkconversationfile")]
        micromsg_bin_checkconversationfile = 483,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadfile")]
        micromsg_bin_uploadfile = 484,
        [WXCGIUrl("/cgi-bin/micromsg-bin/composesend")]
        micromsg_bin_composesend = 485,
        [WXCGIUrl("/cgi-bin/micromsg-bin/listgooglecontact")]
        micromsg_bin_listgooglecontact = 488,
        [WXCGIUrl("/cgi-bin/micromsg-bin/jointrackroom")]
        micromsg_bin_jointrackroom = 490,
        [WXCGIUrl("/cgi-bin/micromsg-bin/refreshtrackroom")]
        micromsg_bin_refreshtrackroom = 492,
        [WXCGIUrl("/cgi-bin/micromsg-bin/exittrackroom")]
        micromsg_bin_exittrackroom = 491,
        [WXCGIUrl("/cgi-bin/micromsg-bin/generalshare")]
        micromsg_bin_generalshare = 493,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpayfunctionlist")]
        micromsg_bin_getpayfunctionlist = 495,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpayfunctionproductlist")]
        micromsg_bin_getpayfunctionproductlist = 496,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getlatestpayproductinfo")]
        micromsg_bin_getlatestpayproductinfo = 1578,
        [WXCGIUrl("/cgi-bin/mmpay-bin/flowdatarechargepreinquery")]
        mmpay_bin_flowdatarechargepreinquery = 1555,
        [WXCGIUrl("/cgi-bin/mmpay-bin/paychargeproxy")]
        mmpay_bin_paychargeproxy = 1570,
        [WXCGIUrl("/cgi-bin/micromsg-bin/genbiziapprepay")]
        micromsg_bin_genbiziapprepay = 508,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getbiziappayresult")]
        micromsg_bin_getbiziappayresult = 509,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getbiziapdetail")]
        micromsg_bin_getbiziapdetail = 514,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/boss/getinitdata")]
        mmbiz_bin_boss_getinitdata = 1942,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/boss/getpackage")]
        mmbiz_bin_boss_getpackage = 2879,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getfacecheckaction")]
        mmpay_bin_getfacecheckaction = 2696,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getfacecheckresult")]
        mmpay_bin_getfacecheckresult = 2726,
        [WXCGIUrl("/cgi-bin/mmpay-bin/securetunnel")]
        mmpay_bin_securetunnel = 2632,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getpaidorderdetail")]
        mmpay_bin_tenpay_getpaidorderdetail = 2570,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinegetpaidorderdetail")]
        mmpay_bin_tenpay_offlinegetpaidorderdetail = 2516,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getqqmusiclyric")]
        micromsg_bin_getqqmusiclyric = 520,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getonlineinfo")]
        micromsg_bin_getonlineinfo = 526,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkvoicetrans")]
        micromsg_bin_checkvoicetrans = 546,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getvoicetransres")]
        micromsg_bin_getvoicetransres = 548,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadvoicefortrans")]
        micromsg_bin_uploadvoicefortrans = 547,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindlinkedincontact")]
        micromsg_bin_bindlinkedincontact = 549,
        [WXCGIUrl("/cgi-bin/micromsg-bin/unbindlinkedincontact")]
        micromsg_bin_unbindlinkedincontact = 550,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcarditeminfo")]
        micromsg_bin_getcarditeminfo = 1057,
        [WXCGIUrl("/cgi-bin/micromsg-bin/acceptcarditem")]
        micromsg_bin_acceptcarditem = 1037,
        [WXCGIUrl("/cgi-bin/micromsg-bin/giftcarditem")]
        micromsg_bin_giftcarditem = 1045,
        [WXCGIUrl("/cgi-bin/micromsg-bin/cardsync")]
        micromsg_bin_cardsync = 1047,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetcarditem")]
        micromsg_bin_batchgetcarditem = 1074,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchdelcarditem")]
        micromsg_bin_batchdelcarditem = 1077,
        [WXCGIUrl("/cgi-bin/micromsg-bin/cardshoplbs")]
        micromsg_bin_cardshoplbs = 1058,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardserial")]
        micromsg_bin_getcardserial = 1089,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardcount")]
        micromsg_bin_getcardcount = 1088,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getavailablecard")]
        micromsg_bin_getavailablecard = 1059,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardlistfromapp")]
        micromsg_bin_getcardlistfromapp = 1079,
        [WXCGIUrl("/cgi-bin/micromsg-bin/acceptcardlistfromapp")]
        micromsg_bin_acceptcardlistfromapp = 1049,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardconfiginfo")]
        micromsg_bin_getcardconfiginfo = 1046,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetcarditembytpinfo")]
        micromsg_bin_batchgetcarditembytpinfo = 1099,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getdynamiccardcode")]
        micromsg_bin_getdynamiccardcode = 1382,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardslayout")]
        micromsg_bin_getcardslayout = 1054,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/mmbizjsapi_getuseropenid")]
        mmbiz_bin_usrmsg_mmbizjsapi_getuseropenid = 1177,
        [WXCGIUrl("/cgi-bin/micromsg-bin/uploadcardimg")]
        micromsg_bin_uploadcardimg = 575,
        [WXCGIUrl("/cgi-bin/micromsg-bin/deletecardimg")]
        micromsg_bin_deletecardimg = 576,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gettvinfo")]
        micromsg_bin_gettvinfo = 552,
        [WXCGIUrl("/cgi-bin/micromsg-bin/whatsnews")]
        micromsg_bin_whatsnews = 581,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bindharddevice")]
        micromsg_bin_bindharddevice = 536,
        [WXCGIUrl("/cgi-bin/micromsg-bin/unbindharddevice")]
        micromsg_bin_unbindharddevice = 537,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendharddevicemsg")]
        micromsg_bin_sendharddevicemsg = 538,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getboundharddevices")]
        micromsg_bin_getboundharddevices = 539,
        [WXCGIUrl("/cgi-bin/micromsg-bin/searchharddevice")]
        micromsg_bin_searchharddevice = 540,
        [WXCGIUrl("/cgi-bin/micromsg-bin/harddeviceauth")]
        micromsg_bin_harddeviceauth = 541,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchsearchharddevice")]
        micromsg_bin_batchsearchharddevice = 542,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getharddeviceoperticket")]
        micromsg_bin_getharddeviceoperticket = 543,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/uploaddevicestep")]
        mmoc_bin_hardware_uploaddevicestep = 1261,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/updatemydeviceattr")]
        mmoc_bin_hardware_updatemydeviceattr = 1263,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/getsportdevicelist")]
        mmbiz_bin_rank_getsportdevicelist = 1267,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/searchwifiharddevice")]
        mmoc_bin_hardware_searchwifiharddevice = 1270,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/getharddevicehelpurl")]
        mmoc_bin_hardware_getharddevicehelpurl = 1719,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/searchbleharddevice")]
        mmoc_bin_hardware_searchbleharddevice = 1706,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/mydevice/connectedrouter")]
        mmoc_bin_hardware_mydevice_connectedrouter = 1799,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/transfermsgtodevice")]
        mmoc_bin_hardware_transfermsgtodevice = 1717,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/device/subscribestatus")]
        mmbiz_bin_device_subscribestatus = 1090,
        [WXCGIUrl("/cgi-bin/micromsg-bin/revokemsg")]
        micromsg_bin_revokemsg = 594,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmfacingcreatechatroom")]
        micromsg_bin_mmfacingcreatechatroom = 653,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sharefav")]
        micromsg_bin_sharefav = 608,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkcansubscribebiz")]
        micromsg_bin_checkcansubscribebiz = 605,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getlbslifelist")]
        micromsg_bin_getlbslifelist = 603,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gettranstext")]
        micromsg_bin_gettranstext = 631,
        [WXCGIUrl("/cgi-bin/micromsg-bin/apauth")]
        micromsg_bin_apauth = 640,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/addcontact")]
        mmo2o_bin_addcontact = 1703,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/bizwificonnect")]
        mmo2o_bin_bizwificonnect = 1705,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getportalapinfo")]
        mmo2o_bin_getportalapinfo = 1709,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getpcfrontpage")]
        mmo2o_bin_getpcfrontpage = 1760,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/setpcloginuserInfo")]
        mmo2o_bin_setpcloginuserInfo = 1761,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getbackpagefor33")]
        mmo2o_bin_getbackpagefor33 = 1726,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/apcheck")]
        mmo2o_bin_apcheck = 1744,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/getapinfolist")]
        mmo2o_bin_getapinfolist = 1711,
        [WXCGIUrl("/cgi-bin/mmo2o-bin/freewifireport")]
        mmo2o_bin_freewifireport = 1781,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoipinvite")]
        micromsg_bin_csvoipinvite = 823,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoiphangup")]
        micromsg_bin_csvoiphangup = 880,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoipsync")]
        micromsg_bin_csvoipsync = 818,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoipheartbeat")]
        micromsg_bin_csvoipheartbeat = 795,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoipredirect")]
        micromsg_bin_csvoipredirect = 285,
        [WXCGIUrl("/cgi-bin/micromsg-bin/csvoipreport")]
        micromsg_bin_csvoipreport = 312,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchtranscdnitem")]
        micromsg_bin_batchtranscdnitem = 632,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getimunreadmsgcount")]
        micromsg_bin_getimunreadmsgcount = 630,
        [WXCGIUrl("/cgi-bin/micromsg-bin/createpoi")]
        micromsg_bin_createpoi = 650,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpoicity")]
        micromsg_bin_getpoicity = 923,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/mmbizjsapi_uploadmedia")]
        mmbiz_bin_usrmsg_mmbizjsapi_uploadmedia = 1032,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/mmbizjsapi_downloadmedia")]
        mmbiz_bin_usrmsg_mmbizjsapi_downloadmedia = 1033,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/mmbizjsapi_uploadcdninfo")]
        mmbiz_bin_usrmsg_mmbizjsapi_uploadcdninfo = 1034,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/mmbizjsapi_downloadcdninfo")]
        mmbiz_bin_usrmsg_mmbizjsapi_downloadcdninfo = 1035,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addcontactlabel")]
        micromsg_bin_addcontactlabel = 635,
        [WXCGIUrl("/cgi-bin/micromsg-bin/delcontactlabel")]
        micromsg_bin_delcontactlabel = 636,
        [WXCGIUrl("/cgi-bin/micromsg-bin/updatecontactlabel")]
        micromsg_bin_updatecontactlabel = 637,
        [WXCGIUrl("/cgi-bin/micromsg-bin/modifycontactlabellist")]
        micromsg_bin_modifycontactlabellist = 638,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcontactlabellist")]
        micromsg_bin_getcontactlabellist = 639,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/getserviceapplist")]
        mmbiz_bin_usrmsg_getserviceapplist = 1060,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/setrecvtmpmsgoption")]
        mmbiz_bin_usrmsg_setrecvtmpmsgoption = 1030,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/getallrecvtmpmsgoption")]
        mmbiz_bin_usrmsg_getallrecvtmpmsgoption = 1031,
        [WXCGIUrl("/cgi-bin/micromsg-bin/exposewithproof")]
        micromsg_bin_exposewithproof = 661,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getexposelink")]
        micromsg_bin_getexposelink = 982,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsearchhomepage")]
        micromsg_bin_mmsearchhomepage = 659,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsearchdetailpage")]
        micromsg_bin_mmsearchdetailpage = 660,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmwebsearch")]
        micromsg_bin_mmwebsearch = 719,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchconfirm")]
        mmsearch_bin_searchconfirm = 2957,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchguide")]
        mmsearch_bin_searchguide = 1048,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchreport")]
        mmsearch_bin_searchreport = 1134,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchsuggestion")]
        mmsearch_bin_searchsuggestion = 1161,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/websearchconfig")]
        mmsearch_bin_websearchconfig = 1948,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchlocalpage")]
        mmsearch_bin_searchlocalpage = 1944,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchsimilaremoticon")]
        mmsearch_bin_searchsimilaremoticon = 2999,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/mmwebrecommend")]
        mmsearch_bin_mmwebrecommend = 1943,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/recommendgetvideourl")]
        mmsearch_bin_recommendgetvideourl = 2579,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/topstoryvote")]
        mmsearch_bin_topstoryvote = 2531,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/pardussearch")]
        mmsearch_bin_pardussearch = 1076,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/parduspresearch")]
        mmsearch_bin_parduspresearch = 1417,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getqqgroup")]
        micromsg_bin_getqqgroup = 143,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcurlocation")]
        micromsg_bin_getcurlocation = 665,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/topstorypluginpostcomment")]
        mmsearch_bin_topstorypluginpostcomment = 2906,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/topstorypluginsetcomment")]
        mmsearch_bin_topstorypluginsetcomment = 2802,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/searchwebcomm")]
        mmsearch_bin_searchwebcomm = 2582,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/getuserattrbyopenid")]
        mmsearch_bin_getuserattrbyopenid = 2830,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/colikeblock")]
        mmsearch_bin_colikeblock = 2859,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/getcolikeblocklist")]
        mmsearch_bin_getcolikeblocklist = 2748,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/colikepost")]
        mmsearch_bin_colikepost = 2534,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getreadingmodeinfo")]
        micromsg_bin_getreadingmodeinfo = 673,
        [WXCGIUrl("/cgi-bin/mmkf-bin/kfgetdefaultlist")]
        mmkf_bin_kfgetdefaultlist = 672,
        [WXCGIUrl("/cgi-bin/mmkf-bin/kfgetbindlist")]
        mmkf_bin_kfgetbindlist = 674,
        [WXCGIUrl("/cgi-bin/mmkf-bin/kfgetinfolist")]
        mmkf_bin_kfgetinfolist = 675,
        [WXCGIUrl("/cgi-bin/micromsg-bin/jumpemotiondetail")]
        micromsg_bin_jumpemotiondetail = 666,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipredirect")]
        micromsg_bin_voipredirect = 678,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/lbslife/lbslifegetnearbyentrancelist")]
        mmbiz_bin_lbslife_lbslifegetnearbyentrancelist = 1086,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/lbslife/lbslifegetnearbyrecommendpoi")]
        mmbiz_bin_lbslife_lbslifegetnearbyrecommendpoi = 1087,
        [WXCGIUrl("/cgi-bin/micromsg-bin/oplog")]
        micromsg_bin_oplog = 681,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/api/checksmscanaddcard")]
        mmbiz_bin_api_checksmscanaddcard = 1038,
        [WXCGIUrl("/cgi-bin/mmgame-bin/searchgamelist")]
        mmgame_bin_searchgamelist = 1215,
        [WXCGIUrl("/cgi-bin/mmgame-bin/syncwxaggamelist")]
        mmgame_bin_syncwxaggamelist = 2583,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamecentersearch")]
        mmgame_bin_gamecentersearch = 1328,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamecentersearchrecommend")]
        mmgame_bin_gamecentersearchrecommend = 1329,
        [WXCGIUrl("/cgi-bin/mmgame-bin/newgetgameindex")]
        mmgame_bin_newgetgameindex = 1216,
        [WXCGIUrl("/cgi-bin/mmgame-bin/newgetgamedetail")]
        mmgame_bin_newgetgamedetail = 1217,
        [WXCGIUrl("/cgi-bin/mmgame-bin/newgetlibgamelist")]
        mmgame_bin_newgetlibgamelist = 1218,
        [WXCGIUrl("/cgi-bin/mmgame-bin/newsubscribenewgame")]
        mmgame_bin_newsubscribenewgame = 1219,
        [WXCGIUrl("/cgi-bin/mmgame-bin/newgetmoregamelist")]
        mmgame_bin_newgetmoregamelist = 1220,
        [WXCGIUrl("/cgi-bin/mmgame-bin/upfriend")]
        mmgame_bin_upfriend = 1330,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getuplist")]
        mmgame_bin_getuplist = 1331,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgamecanvasinfo")]
        mmgame_bin_getgamecanvasinfo = 1337,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamemsgblock")]
        mmgame_bin_gamemsgblock = 1221,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamereport")]
        mmgame_bin_gamereport = 1223,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsadcomment")]
        micromsg_bin_mmsnsadcomment = 682,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnsadobjectdetail")]
        micromsg_bin_mmsnsadobjectdetail = 683,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindex_v3")]
        mmgame_bin_getgameindex_v3 = 1297,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindex2")]
        mmgame_bin_getgameindex2 = 1238,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindex4")]
        mmgame_bin_getgameindex4 = 2994,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindexforeign")]
        mmgame_bin_getgameindexforeign = 2855,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindex4tabnav")]
        mmgame_bin_getgameindex4tabnav = 2641,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgameindex4feedslist")]
        mmgame_bin_getgameindex4feedslist = 2943,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getgamecenterglobalsetting")]
        mmgame_bin_getgamecenterglobalsetting = 1311,
        [WXCGIUrl("/cgi-bin/mmgame-bin/checkwepkgversion")]
        mmgame_bin_checkwepkgversion = 1313,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gethvgamemenu")]
        mmgame_bin_gethvgamemenu = 1369,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getuservideolist")]
        mmgame_bin_getuservideolist = 3549,
        [WXCGIUrl("/cgi-bin/mmgame-bin/checkuserifhasnewvideo")]
        mmgame_bin_checkuserifhasnewvideo = 3911,
        [WXCGIUrl("/cgi-bin/mmgame-bin/getwxagameconfig")]
        mmgame_bin_getwxagameconfig = 2955,
        [WXCGIUrl("/cgi-bin/mmgame-bin/publishugctogamecenter")]
        mmgame_bin_publishugctogamecenter = 2989,
        [WXCGIUrl("/cgi-bin/mmgame-bin/reportserverdata")]
        mmgame_bin_reportserverdata = 12630,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/updatecover")]
        mmbiz_bin_rank_updatecover = 1040,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/addlike")]
        mmbiz_bin_rank_addlike = 1041,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/getuserranklike")]
        mmbiz_bin_rank_getuserranklike = 1042,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/getuserrankdetail")]
        mmbiz_bin_rank_getuserrankdetail = 1043,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/rank/updateranksetting")]
        mmbiz_bin_rank_updateranksetting = 1044,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/addfollow")]
        mmoc_bin_hardware_addfollow = 1777,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/delfollow")]
        mmoc_bin_hardware_delfollow = 1792,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/getwerunfollowerlist")]
        mmoc_bin_hardware_getwerunfollowerlist = 1758,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/getsteplist")]
        mmoc_bin_hardware_getsteplist = 1734,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/getwerunuserstate")]
        mmoc_bin_hardware_getwerunuserstate = 1926,
        [WXCGIUrl("/cgi-bin/mmoc-bin/hardware/uploadminiappstep")]
        mmoc_bin_hardware_uploadminiappstep = 1949,
        [WXCGIUrl("/cgi-bin/mmoc-bin/ad/exposure")]
        mmoc_bin_ad_exposure = 1231,
        [WXCGIUrl("/cgi-bin/mmoc-bin/ad/click")]
        mmoc_bin_ad_click = 1232,
        [WXCGIUrl("/cgi-bin/mmoc-bin/ad/addatareport")]
        mmoc_bin_ad_addatareport = 1295,
        [WXCGIUrl("/cgi-bin/mmoc-bin/adplayinfo/get_adcanvasinfo")]
        mmoc_bin_adplayinfo_get_adcanvasinfo = 1286,
        [WXCGIUrl("/cgi-bin/mmoc-bin/ad/adchannelmsg")]
        mmoc_bin_ad_adchannelmsg = 2538,
        [WXCGIUrl("/cgi-bin/mmoc-bin/adplayinfo/get_landpage_smartphone")]
        mmoc_bin_adplayinfo_get_landpage_smartphone = 2605,
        [WXCGIUrl("/cgi-bin/mmux-bin/adlog")]
        mmux_bin_adlog = 1802,
        [WXCGIUrl("/cgi-bin/mmux-bin/jslog")]
        mmux_bin_jslog = 1803,
        [WXCGIUrl("/cgi-bin/mmux-bin/weappsearchadclick")]
        mmux_bin_weappsearchadclick = 1873,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/mmuxwxa_getofficialcanvasinfo")]
        mmux_bin_wxaapp_mmuxwxa_getofficialcanvasinfo = 1890,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/mmuxwxa_favofficialitem")]
        mmux_bin_wxaapp_mmuxwxa_favofficialitem = 2874,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/mmuxwxa_officialsync")]
        mmux_bin_wxaapp_mmuxwxa_officialsync = 2721,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/comment/show/wxaapp_showcomments")]
        mmux_bin_wxaapp_comment_show_wxaapp_showcomments = 1824,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/comment/post/wxaapp_postcomment")]
        mmux_bin_wxaapp_comment_post_wxaapp_postcomment = 1843,
        [WXCGIUrl("/cgi-bin/mmux-bin/adclick")]
        mmux_bin_adclick = 1817,
        [WXCGIUrl("/cgi-bin/mmux-bin/adexposure")]
        mmux_bin_adexposure = 1875,
        [WXCGIUrl("/cgi-bin/micromsg-bin/registernewpatternlock")]
        micromsg_bin_registernewpatternlock = 688,
        [WXCGIUrl("/cgi-bin/micromsg-bin/oppatternlock")]
        micromsg_bin_oppatternlock = 689,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizsearch/homepage")]
        mmbiz_bin_bizsearch_homepage = 1070,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizsearch/detailpage")]
        mmbiz_bin_bizsearch_detailpage = 1071,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmsnstimelinewithtype")]
        micromsg_bin_mmsnstimelinewithtype = 695,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/getappticket")]
        mmbiz_bin_getappticket = 1097,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmbatchemojibackup")]
        micromsg_bin_mmbatchemojibackup = 696,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmbatchemojidownload")]
        micromsg_bin_mmbatchemojidownload = 697,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmbackupemojioperate")]
        micromsg_bin_mmbackupemojioperate = 698,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmemojiupload")]
        micromsg_bin_mmemojiupload = 703,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmuploademojiprepare")]
        micromsg_bin_mmuploademojiprepare = 3886,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getlenslist")]
        micromsg_bin_getlenslist = 3847,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getlensinfo")]
        micromsg_bin_getlensinfo = 3903,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getiosextensionkey")]
        micromsg_bin_getiosextensionkey = 685,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getvoiceprintresource")]
        micromsg_bin_getvoiceprintresource = 611,
        [WXCGIUrl("/cgi-bin/micromsg-bin/registervoiceprint")]
        micromsg_bin_registervoiceprint = 612,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyvoiceprint")]
        micromsg_bin_verifyvoiceprint = 613,
        [WXCGIUrl("/cgi-bin/micromsg-bin/switchopvoiceprint")]
        micromsg_bin_switchopvoiceprint = 615,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getvoiceprintresourcersa")]
        micromsg_bin_getvoiceprintresourcersa = 616,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyvoiceprintrsa")]
        micromsg_bin_verifyvoiceprintrsa = 617,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getvoiceprintticketrsa")]
        micromsg_bin_getvoiceprintticketrsa = 618,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newregvoiceprint")]
        micromsg_bin_newregvoiceprint = 736,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getaddress")]
        micromsg_bin_getaddress = 655,
        [WXCGIUrl("/cgi-bin/micromsg-bin/mmuploadmypanellist")]
        micromsg_bin_mmuploadmypanellist = 717,
        [WXCGIUrl("/cgi-bin/mmpay-bin/hongbao")]
        mmpay_bin_hongbao = 1556,
        [WXCGIUrl("/cgi-bin/mmpay-bin/yearrequestwxhb")]
        mmpay_bin_yearrequestwxhb = 1643,
        [WXCGIUrl("/cgi-bin/mmpay-bin/operationwxhb")]
        mmpay_bin_operationwxhb = 1554,
        [WXCGIUrl("/cgi-bin/mmpay-bin/requestwxhb")]
        mmpay_bin_requestwxhb = 1575,
        [WXCGIUrl("/cgi-bin/mmpay-bin/sharewxhb")]
        mmpay_bin_sharewxhb = 1668,
        [WXCGIUrl("/cgi-bin/mmpay-bin/receivewxhb")]
        mmpay_bin_receivewxhb = 1581,//1581 5181
        [WXCGIUrl("/cgi-bin/mmpay-bin/openwxhb")]
        mmpay_bin_openwxhb = 1685,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unionhb/receiveunionhb")]
        mmpay_bin_receiveunionhb = 4536,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unionhb/openunionhb")]
        mmpay_bin_openunionhb = 5148,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qrydetailwxhb")]
        mmpay_bin_qrydetailwxhb = 1585,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qrylistwxhb")]
        mmpay_bin_qrylistwxhb = 1514,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unionhb/qrydetailunionhb")]
        mmpay_bin_qrydetailunionhb = 4395,
        [WXCGIUrl("/cgi-bin/mmpay-bin/wishwxhb")]
        mmpay_bin_wishwxhb = 1682,
        [WXCGIUrl("/cgi-bin/mmpay-bin/deletelistwxhb")]
        mmpay_bin_deletelistwxhb = 1612,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/businesscallbackwxhb")]
        mmpay_bin_ftfhb_businesscallbackwxhb = 2929,
        [WXCGIUrl("/cgi-bin/mmpay-bin/businesshongbao")]
        mmpay_bin_businesshongbao = 1558,
        [WXCGIUrl("/cgi-bin/micromsg-bin/asyncbizsubscribe")]
        micromsg_bin_asyncbizsubscribe = 980,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/card/reportlocation")]
        mmbiz_bin_card_reportlocation = 1253,
        [WXCGIUrl("/cgi-bin/micromsg-bin/extdeviceloginconfirmget")]
        micromsg_bin_extdeviceloginconfirmget = 971,
        [WXCGIUrl("/cgi-bin/micromsg-bin/extdeviceloginconfirmok")]
        micromsg_bin_extdeviceloginconfirmok = 972,
        [WXCGIUrl("/cgi-bin/micromsg-bin/extdeviceloginconfirmcancel")]
        micromsg_bin_extdeviceloginconfirmcancel = 973,
        [WXCGIUrl("/cgi-bin/micromsg-bin/extdevicecontrol")]
        micromsg_bin_extdevicecontrol = 792,
        [WXCGIUrl("/cgi-bin/micromsg-bin/disasterauth")]
        micromsg_bin_disasterauth = 3941,
        [WXCGIUrl("/cgi-bin/micromsg-bin/initreg")]
        micromsg_bin_initreg = 353,
        [WXCGIUrl("/cgi-bin/micromsg-bin/thirdappverify")]
        micromsg_bin_thirdappverify = 755,
        [WXCGIUrl("/cgi-bin/mmpay-bin/a2auth")]
        mmpay_bin_a2auth = 799,
        [WXCGIUrl("/cgi-bin/micromsg-bin/a3auth")]
        micromsg_bin_a3auth = 352,
        [WXCGIUrl("/cgi-bin/micromsg-bin/rtkvreport")]
        micromsg_bin_rtkvreport = 716,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkbigfileupload")]
        micromsg_bin_checkbigfileupload = 727,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkbigfiledownload")]
        micromsg_bin_checkbigfiledownload = 728,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkmd5")]
        micromsg_bin_checkmd5 = 939,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/bizattrsync")]
        mmbiz_bin_bizattr_bizattrsync = 1075,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/batchbizattrsync")]
        mmbiz_bin_bizattr_batchbizattrsync = 1166,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/bizprofile")]
        mmbiz_bin_bizattr_bizprofile = 2656,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/bizprofilev2")]
        mmbiz_bin_bizattr_bizprofilev2 = 2899,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatcreateqrcode")]
        micromsg_bin_bakchatcreateqrcode = 704,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getconnectinfo")]
        micromsg_bin_getconnectinfo = 595,
        [WXCGIUrl("/cgi-bin/micromsg-bin/bakchatcreateqrcodeoffline")]
        micromsg_bin_bakchatcreateqrcodeoffline = 1000,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamecreatechatroom")]
        mmgame_bin_gamecreatechatroom = 1205,
        [WXCGIUrl("/cgi-bin/mmgame-bin/gamejoinchatroom")]
        mmgame_bin_gamejoinchatroom = 1206,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizchatuserinfolist")]
        mmocbiz_bin_getbizchatuserinfolist = 1353,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizchatmyuserinfo")]
        mmocbiz_bin_getbizchatmyuserinfo = 1354,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/createbizchatinfo")]
        mmocbiz_bin_createbizchatinfo = 1355,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/updatebizchat")]
        mmocbiz_bin_updatebizchat = 1356,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/updatebizchatmemberlist")]
        mmocbiz_bin_updatebizchatmemberlist = 1357,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/quitbizchat")]
        mmocbiz_bin_quitbizchat = 1358,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/qymsgstatenotify")]
        mmocbiz_bin_qymsgstatenotify = 1361,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/setbrandflag")]
        mmocbiz_bin_setbrandflag = 1363,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizchatinfolist")]
        mmocbiz_bin_getbizchatinfolist = 1365,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/getvideoinfo")]
        mmbiz_bin_usrmsg_getvideoinfo = 1069,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getfavbizchatlist")]
        mmocbiz_bin_getfavbizchatlist = 1367,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/initiatebizchat")]
        mmocbiz_bin_initiatebizchat = 1389,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizjsapiredirecturl")]
        mmocbiz_bin_getbizjsapiredirecturl = 1393,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizjsapiresult")]
        mmocbiz_bin_getbizjsapiresult = 1285,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/switchbrand")]
        mmocbiz_bin_switchbrand = 1394,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/convertbizchat")]
        mmocbiz_bin_convertbizchat = 1315,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/bizchatsearchcontact")]
        mmocbiz_bin_bizchatsearchcontact = 1364,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/getbizenterpriseattr")]
        mmocbiz_bin_getbizenterpriseattr = 1343,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/setbizenterpriseattr")]
        mmocbiz_bin_setbizenterpriseattr = 1228,
        [WXCGIUrl("/cgi-bin/mmocbiz-bin/reportpluginstat")]
        mmocbiz_bin_reportpluginstat = 2805,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipspeedtest")]
        micromsg_bin_voipspeedtest = 765,
        [WXCGIUrl("/cgi-bin/micromsg-bin/voipspeedresult")]
        micromsg_bin_voipspeedresult = 901,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibggetjumpurl")]
        mmpay_bin_payibggetjumpurl = 1564,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibggenprepay")]
        mmpay_bin_payibggenprepay = 1563,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibgjsgettransaction")]
        mmpay_bin_payibgjsgettransaction = 1565,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sharecardsync")]
        micromsg_bin_sharecardsync = 1121,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sharecarditem")]
        micromsg_bin_sharecarditem = 902,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getsharecardlist")]
        micromsg_bin_getsharecardlist = 1132,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getsharecard")]
        micromsg_bin_getsharecard = 1051,
        [WXCGIUrl("/cgi-bin/micromsg-bin/commentsharecard")]
        micromsg_bin_commentsharecard = 905,
        [WXCGIUrl("/cgi-bin/micromsg-bin/marksharecard")]
        micromsg_bin_marksharecard = 1078,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcomment")]
        micromsg_bin_getcomment = 908,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getsharecardslayout")]
        micromsg_bin_getsharecardslayout = 1072,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/card/getcardshomepage")]
        mmbiz_bin_card_getcardshomepage = 1164,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/card/getsharecardconsumedinfo")]
        mmbiz_bin_card_getsharecardconsumedinfo = 1050,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/card/delsharecard")]
        mmbiz_bin_card_delsharecard = 1163,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibggetuseropenid")]
        mmpay_bin_payibggetuseropenid = 1566,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibggetoverseawallet")]
        mmpay_bin_payibggetoverseawallet = 1577,
        [WXCGIUrl("/cgi-bin/micromsg-bin/preacceptgiftcard")]
        micromsg_bin_preacceptgiftcard = 1171,
        [WXCGIUrl("/cgi-bin/micromsg-bin/acceptgiftcard")]
        micromsg_bin_acceptgiftcard = 1136,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getcardgiftinfo")]
        micromsg_bin_getcardgiftinfo = 1165,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pullfunctionmsg")]
        micromsg_bin_pullfunctionmsg = 614,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addtxnewsmsg")]
        micromsg_bin_addtxnewsmsg = 825,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getdisasterinfo")]
        micromsg_bin_getdisasterinfo = 775,
        [WXCGIUrl("/cgi-bin/mmux-bin/getabtest")]
        mmux_bin_getabtest = 1801,
        [WXCGIUrl("/cgi-bin/mmux-bin/getlabsinfo")]
        mmux_bin_getlabsinfo = 1816,
        [WXCGIUrl("/cgi-bin/mmexptappsvr-bin/getexptconfig")]
        mmexptappsvr_bin_getexptconfig = 2738,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstninvite")]
        micromsg_bin_pstninvite = 991,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstncancelinvite")]
        micromsg_bin_pstncancelinvite = 843,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnshutdown")]
        micromsg_bin_pstnshutdown = 824,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnsync")]
        micromsg_bin_pstnsync = 819,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnreport")]
        micromsg_bin_pstnreport = 227,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnheartbeat")]
        micromsg_bin_pstnheartbeat = 723,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnredirect")]
        micromsg_bin_pstnredirect = 726,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pstnchecknumber")]
        micromsg_bin_pstnchecknumber = 807,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportmediainfo")]
        micromsg_bin_reportmediainfo = 809,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getwechatoutcoupons")]
        micromsg_bin_getwechatoutcoupons = 257,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getwcoproductlist")]
        micromsg_bin_getwcoproductlist = 929,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getwcogiftcardlist")]
        micromsg_bin_getwcogiftcardlist = 288,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendwcofeedback")]
        micromsg_bin_sendwcofeedback = 871,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getwcocallinfo")]
        micromsg_bin_getwcocallinfo = 746,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getwcopackageproductlist")]
        micromsg_bin_getwcopackageproductlist = 831,
        [WXCGIUrl("/cgi-bin/micromsg-bin/wcopurchasepackage")]
        micromsg_bin_wcopurchasepackage = 277,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendyo")]
        micromsg_bin_sendyo = 976,
        [WXCGIUrl("/cgi-bin/micromsg-bin/transferchatroomowner")]
        micromsg_bin_transferchatroomowner = 990,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getchatroominfodetail")]
        micromsg_bin_getchatroominfodetail = 223,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setchatroomannouncement")]
        micromsg_bin_setchatroomannouncement = 993,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setpushmutetime")]
        micromsg_bin_setpushmutetime = 979,
        [WXCGIUrl("/cgi-bin/micromsg-bin/postinvitefriendsmsg")]
        micromsg_bin_postinvitefriendsmsg = 995,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getinvitefriendsmsg")]
        micromsg_bin_getinvitefriendsmsg = 994,
        [WXCGIUrl("/cgi-bin/mmoctv/optvhist")]
        mmoctv_optvhist = 1000,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/createtalkroom")]
        qcwxmultitalk_bin_createtalkroom = 1918,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/entertalkroom")]
        qcwxmultitalk_bin_entertalkroom = 1919,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/exittalkroom")]
        qcwxmultitalk_bin_exittalkroom = 1927,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/cancelcreatetalkroom")]
        qcwxmultitalk_bin_cancelcreatetalkroom = 1928,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/rejectentertalkroom")]
        qcwxmultitalk_bin_rejectentertalkroom = 1929,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/addmembers")]
        qcwxmultitalk_bin_addmembers = 1931,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/hellotalkroom")]
        qcwxmultitalk_bin_hellotalkroom = 1932,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/miscinfo")]
        qcwxmultitalk_bin_miscinfo = 1933,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/modifygroupinfo")]
        qcwxmultitalk_bin_modifygroupinfo = 1934,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/voiceackreq")]
        qcwxmultitalk_bin_voiceackreq = 1935,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/clientscenereport")]
        qcwxmultitalk_bin_clientscenereport = 1936,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/voiceredirectreq")]
        qcwxmultitalk_bin_voiceredirectreq = 1937,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/getgroupinfobatch")]
        qcwxmultitalk_bin_getgroupinfobatch = 1938,
        [WXCGIUrl("/cgi-bin/qcwxmultitalk-bin/memberwhisper")]
        qcwxmultitalk_bin_memberwhisper = 1939,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxpagedata")]
        mmbiz_bin_wxpagedata = 1143,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/transid")]
        mmbiz_bin_transid = 1142,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/changepwd")]
        mmpay_bin_tenpay_changepwd = 468,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/resetpwdauthen")]
        mmpay_bin_tenpay_resetpwdauthen = 469,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/resetpwdverify")]
        mmpay_bin_tenpay_resetpwdverify = 470,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/bindauthen")]
        mmpay_bin_tenpay_bindauthen = 471,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/bindverify")]
        mmpay_bin_tenpay_bindverify = 472,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/unbind")]
        mmpay_bin_tenpay_unbind = 473,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/bindverifyreg")]
        mmpay_bin_tenpay_bindverifyreg = 475,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/timeseed")]
        mmpay_bin_tenpay_timeseed = 477,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/resetpwd")]
        mmpay_bin_tenpay_resetpwd = 478,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineclose")]
        mmpay_bin_tenpay_offlineclose = 566,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlinegettokenbackground")]
        mmpay_bin_tenpay_offlinegettokenbackground = 1725,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/bindquerynew")]
        mmpay_bin_tenpay_bindquerynew = 1501,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineshowcode")]
        mmpay_bin_tenpay_offlineshowcode = 1645,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/opentouchpay")]
        mmpay_bin_tenpay_opentouchpay = 1596,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/closetouchpay")]
        mmpay_bin_tenpay_closetouchpay = 1597,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getopentouchcert")]
        mmpay_bin_tenpay_getopentouchcert = 1598,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/androidopentouch")]
        mmpay_bin_tenpay_androidopentouch = 1599,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/datareport")]
        mmpay_bin_tenpay_datareport = 1602,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/webankloanordershow")]
        mmpay_bin_tenpay_webankloanordershow = 1603,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/webankverifysms")]
        mmpay_bin_tenpay_webankverifysms = 1604,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/realnameauthen")]
        mmpay_bin_tenpay_realnameauthen = 1616,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/realnamereg")]
        mmpay_bin_tenpay_realnamereg = 1648,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5requesttransfer")]
        mmpay_bin_h5requesttransfer = 1622,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5transferoperate")]
        mmpay_bin_h5transferoperate = 1574,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getuserexinfo")]
        mmpay_bin_tenpay_getuserexinfo = 1976,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/setuserexinfo")]
        mmpay_bin_tenpay_setuserexinfo = 1978,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/resetpwdbytoken")]
        mmpay_bin_tenpay_resetpwdbytoken = 1371,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/paysecurity")]
        mmpay_bin_tenpay_paysecurity = 1669,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/openiostouchlock")]
        mmpay_bin_tenpay_openiostouchlock = 1967,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/closewalletlock")]
        mmpay_bin_tenpay_closewalletlock = 1321,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/touchlockauthen")]
        mmpay_bin_tenpay_touchlockauthen = 1304,
        [WXCGIUrl("/cgi-bin/mmpay-bin/openecardauth")]
        mmpay_bin_openecardauth = 1958,
        [WXCGIUrl("/cgi-bin/mmpay-bin/openecard")]
        mmpay_bin_openecard = 1985,
        [WXCGIUrl("/cgi-bin/mmpay-bin/bindecard")]
        mmpay_bin_bindecard = 1986,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qryecardbanklist4bind")]
        mmpay_bin_qryecardbanklist4bind = 1988,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qrycancelecarddesc")]
        mmpay_bin_qrycancelecarddesc = 2931,
        [WXCGIUrl("/cgi-bin/mmpay-bin/honeypayerlist")]
        mmpay_bin_honeypayerlist = 2725,
        [WXCGIUrl("/cgi-bin/mmpay-bin/checkhoneypayer")]
        mmpay_bin_checkhoneypayer = 2618,
        [WXCGIUrl("/cgi-bin/mmpay-bin/checkhoneyuser")]
        mmpay_bin_checkhoneyuser = 2926,
        [WXCGIUrl("/cgi-bin/mmpay-bin/createhoneypaycard")]
        mmpay_bin_createhoneypaycard = 2662,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qryhppayerdetail")]
        mmpay_bin_qryhppayerdetail = 2876,
        [WXCGIUrl("/cgi-bin/mmpay-bin/modifyhppayernotify")]
        mmpay_bin_modifyhppayernotify = 2742,
        [WXCGIUrl("/cgi-bin/mmpay-bin/modifyhppayerpayway")]
        mmpay_bin_modifyhppayerpayway = 2941,
        [WXCGIUrl("/cgi-bin/mmpay-bin/modifyhppayercreditline")]
        mmpay_bin_modifyhppayercreditline = 2685,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qryhpusererdetail")]
        mmpay_bin_qryhpusererdetail = 2613,
        [WXCGIUrl("/cgi-bin/mmpay-bin/gethpcard")]
        mmpay_bin_gethpcard = 1983,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unbindhpcard")]
        mmpay_bin_unbindhpcard = 2659,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qryhpcarddetail")]
        mmpay_bin_qryhpcarddetail = 2851,
        [WXCGIUrl("/cgi-bin/mmpay-bin/createhpcardtoken")]
        mmpay_bin_createhpcardtoken = 2630,
        [WXCGIUrl("/cgi-bin/mmpay-bin/gmcreditlinetoken")]
        mmpay_bin_gmcreditlinetoken = 2815,
        [WXCGIUrl("/cgi-bin/mmpay-bin/cfrequestwxhb")]
        mmpay_bin_cfrequestwxhb = 1639,
        [WXCGIUrl("/cgi-bin/mmpay-bin/cfopenwxhb")]
        mmpay_bin_cfopenwxhb = 1641,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5requestwxhb")]
        mmpay_bin_h5requestwxhb = 1647,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/queryuserwallet")]
        mmpay_bin_tenpay_queryuserwallet = 1631,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/setuserwallet")]
        mmpay_bin_tenpay_setuserwallet = 1663,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snsfreepasswdauthen")]
        mmpay_bin_tenpay_snsfreepasswdauthen = 1625,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snspaymanage")]
        mmpay_bin_tenpay_snspaymanage = 1697,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/unbindbanner")]
        mmpay_bin_tenpay_unbindbanner = 1540,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getbannerinfo")]
        mmpay_bin_tenpay_getbannerinfo = 1679,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/paymanage")]
        mmpay_bin_tenpay_paymanage = 1654,
        [WXCGIUrl("/cgi-bin/mmpay-bin/bankresource")]
        mmpay_bin_bankresource = 1650,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getrealnamewording")]
        mmpay_bin_getrealnamewording = 1666,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffrequestwxhb")]
        mmpay_bin_ftfhb_ffrequestwxhb = 1970,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffquerydowxhb")]
        mmpay_bin_ftfhb_ffquerydowxhb = 1990,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffclearwxhb")]
        mmpay_bin_ftfhb_ffclearwxhb = 1987,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffauthreceivewxhb")]
        mmpay_bin_ftfhb_ffauthreceivewxhb = 1999,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffopenwxhb")]
        mmpay_bin_ftfhb_ffopenwxhb = 1997,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/realnamegetduty")]
        mmpay_bin_tenpay_realnamegetduty = 1614,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/realnamesetduty")]
        mmpay_bin_tenpay_realnamesetduty = 1584,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/realnameguidequery")]
        mmpay_bin_tenpay_realnameguidequery = 1630,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineverifytoken")]
        mmpay_bin_tenpay_offlineverifytoken = 1686,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/offlineuserbindquery")]
        mmpay_bin_tenpay_offlineuserbindquery = 1742,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-login-confirm")]
        mmbiz_bin_js_login_confirm = 1117,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-authorize")]
        mmbiz_bin_js_authorize = 1157,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-authorize-confirm")]
        mmbiz_bin_js_authorize_confirm = 1158,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-operatewxdata")]
        mmbiz_bin_js_operatewxdata = 1133,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-operatewxdata-vip")]
        mmbiz_bin_js_operatewxdata_vip = 1912,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/geteventsampleconf")]
        mmbiz_bin_geteventsampleconf = 1126,
        [WXCGIUrl("/cgi-bin/micromsg-bin/removetrustedfriends")]
        micromsg_bin_removetrustedfriends = 867,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addtrustedfriends")]
        micromsg_bin_addtrustedfriends = 583,
        [WXCGIUrl("/cgi-bin/micromsg-bin/gettrustedfriends")]
        micromsg_bin_gettrustedfriends = 869,
        [WXCGIUrl("/cgi-bin/mmux-bin/repeaturloper")]
        mmux_bin_repeaturloper = 1863,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-checkjsapiinfo")]
        mmbiz_bin_js_checkjsapiinfo = 1187,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/getservicenotifyoptions")]
        mmbiz_bin_wxausrevent_getservicenotifyoptions = 1145,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/batchswitchservicenotifyoption")]
        mmbiz_bin_wxausrevent_batchswitchservicenotifyoption = 1176,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/exitreport")]
        mmbiz_bin_exitreport = 1642,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/webcompt/webcomptcommcgi")]
        mmbiz_bin_webcompt_webcomptcommcgi = 2936,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/webcompt/reportjserr")]
        mmbiz_bin_webcompt_reportjserr = 2914,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/batchrecordwxatemplatemsgevent")]
        mmbiz_bin_wxausrevent_batchrecordwxatemplatemsgevent = 1129,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getpubliclibinfo")]
        mmbiz_bin_wxaapp_getpubliclibinfo = 1168,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/weappsearch")]
        mmbiz_bin_wxaapp_weappsearch = 1162,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/mmuxwxa_weappsearch")]
        mmux_bin_wxaapp_mmuxwxa_weappsearch = 2676,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/mmuxwxa_weappsuggestion")]
        mmux_bin_wxaapp_mmuxwxa_weappsuggestion = 1747,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxartrappsvr/route")]
        mmbiz_bin_wxartrappsvr_route = 2946,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp_weappsearchlocal")]
        mmux_bin_wxaapp_weappsearchlocal = 2601,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/wxatmplcomplaint")]
        mmbiz_bin_wxausrevent_wxatmplcomplaint = 1198,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/wxaappidkeybatchreport")]
        mmbiz_bin_wxausrevent_wxaappidkeybatchreport = 1009,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/getappconfig")]
        mmbiz_bin_wxausrevent_getappconfig = 1138,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getwxausagerecord")]
        mmbiz_bin_wxaapp_getwxausagerecord = 1148,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/updatewxausagerecord")]
        mmbiz_bin_wxaapp_updatewxausagerecord = 1149,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/updatestarrecord")]
        mmbiz_bin_wxaapp_updatestarrecord = 1839,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/checkdemoinfo")]
        mmbiz_bin_wxaapp_checkdemoinfo = 1124,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getwidgetinfo")]
        mmbiz_bin_wxaapp_getwidgetinfo = 1186,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/wxaapp_widgetalarm/wxaapp_widgetalarm")]
        mmux_bin_wxaapp_wxaapp_widgetalarm_wxaapp_widgetalarm = 2653,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/wxaapp_opsearch")]
        mmux_bin_wxaapp_wxaapp_opsearch = 1865,
        [WXCGIUrl("/cgi-bin/mmux-bin/wxaapp/weappsearchguide")]
        mmux_bin_wxaapp_weappsearchguide = 1866,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getwxaappnearby")]
        mmbiz_bin_wxaapp_getwxaappnearby = 1056,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/weappsearchtitle")]
        mmbiz_bin_wxaapp_weappsearchtitle = 1170,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/weappsearchsuggestion")]
        mmbiz_bin_wxaapp_weappsearchsuggestion = 1173,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp_getauthinfo")]
        mmbiz_bin_wxaapp_getauthinfo = 1115,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp_modauth")]
        mmbiz_bin_wxaapp_modauth = 1188,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/uploaduserlocationinfo")]
        mmbiz_bin_wxaapp_uploaduserlocationinfo = 1154,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaattr/batchwxaattrsync")]
        mmbiz_bin_wxaattr_batchwxaattrsync = 1192,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getadwxacdndownloadurl")]
        mmbiz_bin_wxaapp_getadwxacdndownloadurl = 1996,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaattr/launchwxawidget")]
        mmbiz_bin_wxaattr_launchwxawidget = 1181,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getshareinfo")]
        mmbiz_bin_wxaapp_getshareinfo = 1118,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/reportwxaappexpose")]
        mmbiz_bin_wxabusiness_reportwxaappexpose = 1345,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getremotedebugticket")]
        mmbiz_bin_wxabusiness_getremotedebugticket = 1862,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxausrevent/getsubbusinessinfo")]
        mmbiz_bin_wxausrevent_getsubbusinessinfo = 1303,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getwxagame")]
        mmbiz_bin_wxaapp_getwxagame = 1841,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getwxabindbizinfo")]
        mmbiz_bin_wxabusiness_getwxabindbizinfo = 1823,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxasync/wxabatchsyncversion")]
        mmbiz_bin_wxasync_wxabatchsyncversion = 2763,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxasync/wxaapp_predownloadcode")]
        mmbiz_bin_wxasync_wxaapp_predownloadcode = 1479,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getkefusessioninfo")]
        mmbiz_bin_wxabusiness_getkefusessioninfo = 2912,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getrecommendwxa")]
        mmbiz_bin_wxabusiness_getrecommendwxa = 2778,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/reportrecommendwxa")]
        mmbiz_bin_wxabusiness_reportrecommendwxa = 2564,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/launchbizwxaapp")]
        mmbiz_bin_wxabusiness_launchbizwxaapp = 1268,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/updateruntimeqrcode")]
        mmbiz_bin_wxabusiness_updateruntimeqrcode = 2578,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/autofill/getinfo")]
        mmbiz_bin_wxaapp_autofill_getinfo = 1191,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/autofill/saveinfo")]
        mmbiz_bin_wxaapp_autofill_saveinfo = 1180,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/autofill/authinfo")]
        mmbiz_bin_wxaapp_autofill_authinfo = 1183,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/autofill/deleteinfo")]
        mmbiz_bin_wxaapp_autofill_deleteinfo = 1194,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/sendverifycode")]
        mmbiz_bin_wxaapp_sendverifycode = 1024,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/checkverifycode")]
        mmbiz_bin_wxaapp_checkverifycode = 1010,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/js-getuserwxphone")]
        mmbiz_bin_js_getuserwxphone = 1141,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/customphone/getallphone")]
        mmbiz_bin_wxaapp_customphone_getallphone = 2536,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/customphone/updateuserphone")]
        mmbiz_bin_wxaapp_customphone_updateuserphone = 2932,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/customphone/sendverifycode")]
        mmbiz_bin_wxaapp_customphone_sendverifycode = 2695,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/customphone/checkverifycode")]
        mmbiz_bin_wxaapp_customphone_checkverifycode = 2775,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getdynamicdata")]
        mmbiz_bin_wxaapp_getdynamicdata = 1193,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/gettestcodedownloadinfo")]
        mmbiz_bin_wxaapp_gettestcodedownloadinfo = 1718,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getsearchshowoutwxaapp")]
        mmbiz_bin_wxabusiness_getsearchshowoutwxaapp = 1314,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/getgamemenu")]
        mmbiz_bin_wxaapp_getgamemenu = 1738,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxaapp/verifyplugin")]
        mmbiz_bin_wxaapp_verifyplugin = 1714,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/userdata/showauthorizeuserid")]
        mmbiz_bin_userdata_showauthorizeuserid = 1774,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/userdata/submitauthorizeuserid")]
        mmbiz_bin_userdata_submitauthorizeuserid = 1721,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/userdata/sendsms")]
        mmbiz_bin_userdata_sendsms = 1762,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/userdata/verifysmscode")]
        mmbiz_bin_userdata_verifysmscode = 1776,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxahb/requestwxaapphb")]
        mmbiz_bin_wxahb_requestwxaapphb = 2651,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxahb/querywxaapphbdetail")]
        mmbiz_bin_wxahb_querywxaapphbdetail = 2937,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxahb/querywxaapphbsendstate")]
        mmbiz_bin_wxahb_querywxaapphbsendstate = 2503,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxahb/openwxaapphb")]
        mmbiz_bin_wxahb_openwxaapphb = 2528,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxahb/receivewxaapphb")]
        mmbiz_bin_wxahb_receivewxaapphb = 2869,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getgdrpauth")]
        mmbiz_bin_wxabusiness_getgdrpauth = 2575,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/setgdrpauth")]
        mmbiz_bin_wxabusiness_setgdrpauth = 2734,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferplaceorder")]
        mmpay_bin_transferplaceorder = 1544,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferquery")]
        mmpay_bin_transferquery = 1628,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferoperation")]
        mmpay_bin_transferoperation = 1691,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferresendmsg")]
        mmpay_bin_transferresendmsg = 1545,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transfergetchargefee")]
        mmpay_bin_transfergetchargefee = 1689,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaaoperation")]
        mmpay_bin_newaaoperation = 1698,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaalaunchbymoney")]
        mmpay_bin_newaalaunchbymoney = 1624,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaalaunchbyperson")]
        mmpay_bin_newaalaunchbyperson = 1655,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaapay")]
        mmpay_bin_newaapay = 1629,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaaclose")]
        mmpay_bin_newaaclose = 1530,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaaquerylist")]
        mmpay_bin_newaaquerylist = 1676,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaaquerydetail")]
        mmpay_bin_newaaquerydetail = 1695,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaapayurge")]
        mmpay_bin_newaapayurge = 1644,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaaclosenotify")]
        mmpay_bin_newaaclosenotify = 1672,
        [WXCGIUrl("/cgi-bin/mmpay-bin/newaapaysucc")]
        mmpay_bin_newaapaysucc = 1344,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snsauthen")]
        mmpay_bin_tenpay_snsauthen = 1664,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snsverify")]
        mmpay_bin_tenpay_snsverify = 1617,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snsverifyreg")]
        mmpay_bin_tenpay_snsverifyreg = 1520,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snsqrcodeusebindquery")]
        mmpay_bin_tenpay_snsqrcodeusebindquery = 1569,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snspayorderquery")]
        mmpay_bin_tenpay_snspayorderquery = 1618,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_authen")]
        mmpay_bin_tenpay_sns_authen = 1664,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_verify")]
        mmpay_bin_tenpay_sns_verify = 1617,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_verifyreg")]
        mmpay_bin_tenpay_sns_verifyreg = 1520,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_qrcodeusebindquery")]
        mmpay_bin_tenpay_sns_qrcodeusebindquery = 1569,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_payorderquery")]
        mmpay_bin_tenpay_sns_payorderquery = 1618,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_authen")]
        mmpay_bin_tenpay_sns_aa_authen = 1527,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_verify")]
        mmpay_bin_tenpay_sns_aa_verify = 1675,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_verifyreg")]
        mmpay_bin_tenpay_sns_aa_verifyreg = 1507,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_qrcodeusebindquery")]
        mmpay_bin_tenpay_sns_aa_qrcodeusebindquery = 1551,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_aa_payorderquery")]
        mmpay_bin_tenpay_sns_aa_payorderquery = 1652,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_authen")]
        mmpay_bin_tenpay_sns_tf_authen = 1659,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_verify")]
        mmpay_bin_tenpay_sns_tf_verify = 1592,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_verifyreg")]
        mmpay_bin_tenpay_sns_tf_verifyreg = 1653,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_qrcodeusebindquery")]
        mmpay_bin_tenpay_sns_tf_qrcodeusebindquery = 1688,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sns_tf_payorderquery")]
        mmpay_bin_tenpay_sns_tf_payorderquery = 1512,
        [WXCGIUrl("/cgi-bin/mmpay-bin/gettransferwording")]
        mmpay_bin_gettransferwording = 1992,
        [WXCGIUrl("/cgi-bin/mmpay-bin/beforetransfer")]
        mmpay_bin_beforetransfer = 2783,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_authen")]
        mmpay_bin_tenpay_seb_ff_authen = 2740,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_verify")]
        mmpay_bin_tenpay_seb_ff_verify = 2689,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_verifyreg")]
        mmpay_bin_tenpay_seb_ff_verifyreg = 2542,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_qrcodeusebindquery")]
        mmpay_bin_tenpay_seb_ff_qrcodeusebindquery = 2916,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/seb_ff_payorderquer")]
        mmpay_bin_tenpay_seb_ff_payorderquer = 2956,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_authen")]
        mmpay_bin_tenpay_tax_authen = 2862,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_verify")]
        mmpay_bin_tenpay_tax_verify = 2824,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_verifyreg")]
        mmpay_bin_tenpay_tax_verifyreg = 2626,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_qrcodeusebindquery")]
        mmpay_bin_tenpay_tax_qrcodeusebindquery = 2867,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/tax_payorderquery")]
        mmpay_bin_tenpay_tax_payorderquery = 2872,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_authen")]
        mmpay_bin_tenpay_dc_authen = 1867,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_verify")]
        mmpay_bin_tenpay_dc_verify = 1888,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_verifyreg")]
        mmpay_bin_tenpay_dc_verifyreg = 2935,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_qrcodeusebindquery")]
        mmpay_bin_tenpay_dc_qrcodeusebindquery = 1891,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/dc_payorderquery")]
        mmpay_bin_tenpay_dc_payorderquery = 2760,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/uniqrcodeusebindquery")]
        mmpay_bin_tenpay_uniqrcodeusebindquery = 1878,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/uniauthen")]
        mmpay_bin_tenpay_uniauthen = 2814,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/univerify")]
        mmpay_bin_tenpay_univerify = 2892,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/univerifyreg")]
        mmpay_bin_tenpay_univerifyreg = 2565,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/unipayorderquery")]
        mmpay_bin_tenpay_unipayorderquery = 2737,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unigenprepay")]
        mmpay_bin_unigenprepay = 2519,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tax_genprepay")]
        mmpay_bin_tax_genprepay = 2923,
        [WXCGIUrl("/cgi-bin/mmpay-bin/dc_genprepay")]
        mmpay_bin_dc_genprepay = 2798,
        [WXCGIUrl("/cgi-bin/mmpay-bin/unipayauthapp")]
        mmpay_bin_unipayauthapp = 2655,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/unipayauthnative")]
        mmpay_bin_tenpay_unipayauthnative = 2987,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/querypayaward")]
        mmpay_bin_tenpay_querypayaward = 1979,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportclientcheck")]
        micromsg_bin_reportclientcheck = 771,
        [WXCGIUrl("/cgi-bin/micromsg-bin/lbsfind")]
        micromsg_bin_lbsfind = 148,
        [WXCGIUrl("/cgi-bin/micromsg-bin/approveaddchatroommember")]
        micromsg_bin_approveaddchatroommember = 774,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportvoiceresult")]
        micromsg_bin_reportvoiceresult = 228,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getsafetyinfo")]
        micromsg_bin_getsafetyinfo = 850,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getbioconfig")]
        micromsg_bin_getbioconfig = 734,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/faceidentify")]
        mmbiz_bin_usrmsg_faceidentify = 1080,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/facevideobindbioid")]
        mmbiz_bin_usrmsg_facevideobindbioid = 1197,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/usrmsg/faceidentifyprepage")]
        mmbiz_bin_usrmsg_faceidentifyprepage = 1147,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getbioconfigrsa")]
        micromsg_bin_getbioconfigrsa = 733,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyfacersa")]
        micromsg_bin_verifyfacersa = 930,
        [WXCGIUrl("/cgi-bin/micromsg-bin/registerfacersa")]
        micromsg_bin_registerfacersa = 931,
        [WXCGIUrl("/cgi-bin/micromsg-bin/registerface")]
        micromsg_bin_registerface = 918,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyface")]
        micromsg_bin_verifyface = 797,
        [WXCGIUrl("/cgi-bin/micromsg-bin/switchopface")]
        micromsg_bin_switchopface = 938,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getverifyticketrsa")]
        micromsg_bin_getverifyticketrsa = 915,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/checklaunchapp")]
        mmbiz_bin_checklaunchapp = 1125,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkmusic")]
        micromsg_bin_checkmusic = 940,
        [WXCGIUrl("/cgi-bin/micromsg-bin/initcontact")]
        micromsg_bin_initcontact = 851,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchgetcontactbriefinfo")]
        micromsg_bin_batchgetcontactbriefinfo = 945,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getshakemusicurl")]
        micromsg_bin_getshakemusicurl = 769,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getmdrcvvoice")]
        mmpay_bin_getmdrcvvoice = 1317,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5f2ftransfergetqrcode")]
        mmpay_bin_h5f2ftransfergetqrcode = 1335,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5f2ftransferscanqrcode")]
        mmpay_bin_h5f2ftransferscanqrcode = 1301,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5f2ftransferpay")]
        mmpay_bin_h5f2ftransferpay = 1529,
        [WXCGIUrl("/cgi-bin/mmpay-bin/h5f2ftransfercancelpay")]
        mmpay_bin_h5f2ftransfercancelpay = 1257,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/getuserauthlist")]
        mmbiz_bin_getuserauthlist = 1146,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/deluserauth")]
        mmbiz_bin_deluserauth = 1127,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/moduserauth")]
        mmbiz_bin_moduserauth = 1144,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/searchuserauth")]
        mmbiz_bin_searchuserauth = 1169,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qryusrfunddetail")]
        mmpay_bin_qryusrfunddetail = 1211,
        [WXCGIUrl("/cgi-bin/mmpay-bin/purchasefund")]
        mmpay_bin_purchasefund = 1276,
        [WXCGIUrl("/cgi-bin/mmpay-bin/qrypurchaseresult")]
        mmpay_bin_qrypurchaseresult = 1283,
        [WXCGIUrl("/cgi-bin/mmpay-bin/preredeemfund")]
        mmpay_bin_preredeemfund = 1324,
        [WXCGIUrl("/cgi-bin/mmpay-bin/redeemfund")]
        mmpay_bin_redeemfund = 1338,
        [WXCGIUrl("/cgi-bin/mmpay-bin/closefundaccount")]
        mmpay_bin_closefundaccount = 1386,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snslqtpaybindauthen")]
        mmpay_bin_tenpay_snslqtpaybindauthen = 1274,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/snslqtpaybindverify")]
        mmpay_bin_tenpay_snslqtpaybindverify = 1281,
        [WXCGIUrl("/cgi-bin/mmpay-bin/onclickredeem")]
        mmpay_bin_onclickredeem = 1830,
        [WXCGIUrl("/cgi-bin/mmpay-bin/onclickpurchase")]
        mmpay_bin_onclickpurchase = 2585,
        [WXCGIUrl("/cgi-bin/mmpay-bin/openlqbaccount")]
        mmpay_bin_openlqbaccount = 2996,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getpaymenu")]
        mmpay_bin_tenpay_getpaymenu = 1754,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_authorize")]
        mmbiz_bin_oauth_authorize = 1254,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_authorize_confirm")]
        mmbiz_bin_oauth_authorize_confirm = 1373,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/sdk_oauth_authorize")]
        mmbiz_bin_sdk_oauth_authorize = 1388,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/sdk_oauth_authorize_confirm")]
        mmbiz_bin_sdk_oauth_authorize_confirm = 1346,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_addavatar")]
        mmbiz_bin_oauth_addavatar = 2500,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_delavatar")]
        mmbiz_bin_oauth_delavatar = 2700,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_getrandomavatar")]
        mmbiz_bin_oauth_getrandomavatar = 2785,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_addavatarheadimg")]
        mmbiz_bin_oauth_addavatarheadimg = 2667,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/qrconnect_authorize")]
        mmbiz_bin_qrconnect_authorize = 2543,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/qrconnect_authorize_confirm")]
        mmbiz_bin_qrconnect_authorize_confirm = 1137,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/oauth_checkgrant")]
        mmbiz_bin_oauth_checkgrant = 2842,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/getbankcardinfo")]
        mmpay_bin_tenpay_getbankcardinfo = 2556,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ocrgetbankcardinfo")]
        mmpay_bin_ocrgetbankcardinfo = 2693,
        [WXCGIUrl("/cgi-bin/mmpay-bin/setrewardqrcode")]
        mmpay_bin_setrewardqrcode = 1562,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getrewardqrcode")]
        mmpay_bin_getrewardqrcode = 1323,
        [WXCGIUrl("/cgi-bin/mmpay-bin/setrewardqrcodephotoword")]
        mmpay_bin_setrewardqrcodephotoword = 1649,
        [WXCGIUrl("/cgi-bin/mmpay-bin/scanrewardqrcode")]
        mmpay_bin_scanrewardqrcode = 1516,
        [WXCGIUrl("/cgi-bin/mmpay-bin/rewardqrcodeplaceorder")]
        mmpay_bin_rewardqrcodeplaceorder = 1336,
        [WXCGIUrl("/cgi-bin/mmpay-bin/rewardqrcodepaycheck")]
        mmpay_bin_rewardqrcodepaycheck = 1960,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getpayuserduty")]
        mmpay_bin_getpayuserduty = 2541,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/setpayuserduty")]
        mmpay_bin_tenpay_setpayuserduty = 2791,
        [WXCGIUrl("/cgi-bin/micromsg-bin/privacypolicychoise")]
        micromsg_bin_privacypolicychoise = 268,
        [WXCGIUrl("/cgi-bin/mmpay-bin/payibgcheckjsapisign")]
        mmpay_bin_payibgcheckjsapisign = 1767,
        [WXCGIUrl("/cgi-bin/micromsg-bin/apnsreport")]
        micromsg_bin_apnsreport = 668,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferoldpaycheck")]
        mmpay_bin_transferoldpaycheck = 1779,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getbanklist_tsbc")]
        mmpay_bin_getbanklist_tsbc = 1399,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tsrecordlist_tsbc")]
        mmpay_bin_tsrecordlist_tsbc = 1378,
        [WXCGIUrl("/cgi-bin/mmpay-bin/appointbank_tsbc")]
        mmpay_bin_appointbank_tsbc = 1348,
        [WXCGIUrl("/cgi-bin/mmpay-bin/checkbankbind_tsbc")]
        mmpay_bin_checkbankbind_tsbc = 1349,
        [WXCGIUrl("/cgi-bin/mmpay-bin/request_tsbc")]
        mmpay_bin_request_tsbc = 1380,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getbankinfo_tsbc")]
        mmpay_bin_getbankinfo_tsbc = 1542,
        [WXCGIUrl("/cgi-bin/mmpay-bin/modifyexplain_tsbc")]
        mmpay_bin_modifyexplain_tsbc = 1590,
        [WXCGIUrl("/cgi-bin/mmpay-bin/deleterecord_tsbc")]
        mmpay_bin_deleterecord_tsbc = 1395,
        [WXCGIUrl("/cgi-bin/mmpay-bin/operation_tsbc")]
        mmpay_bin_operation_tsbc = 1280,
        [WXCGIUrl("/cgi-bin/mmpay-bin/querydetail_tsbc")]
        mmpay_bin_querydetail_tsbc = 1579,
        [WXCGIUrl("/cgi-bin/mmpay-bin/historylist_tsbc")]
        mmpay_bin_historylist_tsbc = 1511,
        [WXCGIUrl("/cgi-bin/mmpay-bin/deletehistoryrecord_tsbc")]
        mmpay_bin_deletehistoryrecord_tsbc = 1737,
        [WXCGIUrl("/cgi-bin/mmpay-bin/busscb_tsbc")]
        mmpay_bin_busscb_tsbc = 1340,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/sendbindcardaward")]
        mmpay_bin_tenpay_sendbindcardaward = 1786,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/querybindcardaward")]
        mmpay_bin_tenpay_querybindcardaward = 1773,
        [WXCGIUrl("/cgi-bin/micromsg-bin/setmsgremind")]
        micromsg_bin_setmsgremind = 525,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getremind")]
        micromsg_bin_getremind = 866,
        [WXCGIUrl("/cgi-bin/micromsg-bin/favremind")]
        micromsg_bin_favremind = 118,
        [WXCGIUrl("/cgi-bin/micromsg-bin/prconfig")]
        micromsg_bin_prconfig = 3899,
        [WXCGIUrl("/cgi-bin/micromsg-bin/encryptprconfig")]
        micromsg_bin_encryptprconfig = 3790,
        [WXCGIUrl("/cgi-bin/micromsg-bin/secencryptprconfig")]
        micromsg_bin_secencryptprconfig = 3824,
        [WXCGIUrl("/cgi-bin/mmpay-bin/scanf2fmaterialcode")]
        mmpay_bin_scanf2fmaterialcode = 1800,
        [WXCGIUrl("/cgi-bin/mmpay-bin/scanrewardmaterialcode")]
        mmpay_bin_scanrewardmaterialcode = 2811,
        [WXCGIUrl("/cgi-bin/mmpay-bin/genmallprepay")]
        mmpay_bin_genmallprepay = 2755,
        [WXCGIUrl("/cgi-bin/micromsg-bin/pushnewtips")]
        micromsg_bin_pushnewtips = 597,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetf2flottery")]
        mmpay_bin_mktgetf2flottery = 2803,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktf2fmodifyexposure")]
        mmpay_bin_mktf2fmodifyexposure = 2529,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktdrawf2flottery")]
        mmpay_bin_mktdrawf2flottery = 1859,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetlottery")]
        mmpay_bin_mktgetlottery = 2508,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktmodifyexposure")]
        mmpay_bin_mktmodifyexposure = 2888,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktdrawlottery")]
        mmpay_bin_mktdrawlottery = 2547,
        [WXCGIUrl("/cgi-bin/micromsg-bin/openimsync")]
        micromsg_bin_openimsync = 810,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendopenimverifyrequest")]
        micromsg_bin_sendopenimverifyrequest = 243,
        [WXCGIUrl("/cgi-bin/micromsg-bin/searchopenimcontact")]
        micromsg_bin_searchopenimcontact = 372,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sendopenimverifyreply")]
        micromsg_bin_sendopenimverifyreply = 679,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addopenimcontact")]
        micromsg_bin_addopenimcontact = 667,
        [WXCGIUrl("/cgi-bin/micromsg-bin/openimoplog")]
        micromsg_bin_openimoplog = 806,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifyopenimcontact")]
        micromsg_bin_verifyopenimcontact = 853,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimcontact")]
        micromsg_bin_getopenimcontact = 881,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimstatus")]
        micromsg_bin_getopenimstatus = 570,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimresource")]
        micromsg_bin_getopenimresource = 453,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getupdatablemsginfo")]
        mmbiz_bin_wxabusiness_getupdatablemsginfo = 2954,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/timeline_comment_reward_stat")]
        mmbiz_bin_bizattr_timeline_comment_reward_stat = 2571,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/timeline_often_read_biz")]
        mmbiz_bin_bizattr_timeline_often_read_biz = 2768,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/timeline/bizrecommendcard")]
        mmbiz_bin_timeline_bizrecommendcard = 2787,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_get")]
        mmbiz_bin_appmsg_appmsg_get = 1179,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_getext")]
        mmbiz_bin_appmsg_appmsg_getext = 2776,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_comment_list")]
        mmbiz_bin_appmsg_appmsg_comment_list = 2866,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_operate_comment")]
        mmbiz_bin_appmsg_appmsg_operate_comment = 2617,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_like")]
        mmbiz_bin_appmsg_appmsg_like = 2691,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_like_comment")]
        mmbiz_bin_appmsg_appmsg_like_comment = 2759,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_comment_exposure")]
        mmbiz_bin_appmsg_appmsg_comment_exposure = 2827,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsg/appmsg_report")]
        mmbiz_bin_appmsg_appmsg_report = 1870,
        [WXCGIUrl("/cgi-bin/mmsearch-bin/readitlaterreaditlater")]
        mmsearch_bin_readitlaterreaditlater = 2664,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/walletlockreport")]
        mmpay_bin_tenpay_walletlockreport = 2826,
        [WXCGIUrl("/cgi-bin/mmpay-bin/tenpay/geteuinfo")]
        mmpay_bin_tenpay_geteuinfo = 2713,
        [WXCGIUrl("/cgi-bin/mmpay-bin/verifyuserrealnameinfo")]
        mmpay_bin_verifyuserrealnameinfo = 2784,
        [WXCGIUrl("/cgi-bin/mmpay-bin/resetpaypwdbyface")]
        mmpay_bin_resetpaypwdbyface = 2514,
        [WXCGIUrl("/cgi-bin/micromsg-bin/checkmobilesimtype")]
        micromsg_bin_checkmobilesimtype = 813,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addchatroomadmin")]
        micromsg_bin_addchatroomadmin = 889,
        [WXCGIUrl("/cgi-bin/micromsg-bin/delchatroomadmin")]
        micromsg_bin_delchatroomadmin = 259,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getforcepush")]
        micromsg_bin_getforcepush = 691,
        [WXCGIUrl("/cgi-bin/micromsg-bin/scanappforcepush")]
        micromsg_bin_scanappforcepush = 3538,
        [WXCGIUrl("/cgi-bin/micromsg-bin/subappforcepush")]
        micromsg_bin_subappforcepush = 3743,
        [WXCGIUrl("/cgi-bin/micromsg-bin/createopenimchatroom")]
        micromsg_bin_createopenimchatroom = 371,
        [WXCGIUrl("/cgi-bin/micromsg-bin/addopenimchatroommember")]
        micromsg_bin_addopenimchatroommember = 814,
        [WXCGIUrl("/cgi-bin/micromsg-bin/delopenimchatroommember")]
        micromsg_bin_delopenimchatroommember = 943,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimchatroomcontact")]
        micromsg_bin_getopenimchatroomcontact = 407,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimchatroommemberdetail")]
        micromsg_bin_getopenimchatroommemberdetail = 942,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenimchatroomqrcode")]
        micromsg_bin_getopenimchatroomqrcode = 890,
        [WXCGIUrl("/cgi-bin/micromsg-bin/inviteopenimchatroommember")]
        micromsg_bin_inviteopenimchatroommember = 887,
        [WXCGIUrl("/cgi-bin/micromsg-bin/revokeopenimchatroomqrcode")]
        micromsg_bin_revokeopenimchatroomqrcode = 772,
        [WXCGIUrl("/cgi-bin/micromsg-bin/modopenimchatroomowner")]
        micromsg_bin_modopenimchatroomowner = 811,
        [WXCGIUrl("/cgi-bin/micromsg-bin/approveaddopenimchatroommember")]
        micromsg_bin_approveaddopenimchatroommember = 941,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getopenurl")]
        micromsg_bin_getopenurl = 913,
        [WXCGIUrl("/cgi-bin/micromsg-bin/decryptwxworkchatrecord")]
        micromsg_bin_decryptwxworkchatrecord = 3869,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getweappbox")]
        mmbiz_bin_wxabusiness_getweappbox = 1869,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/batchgetappmsg")]
        mmbiz_bin_batchgetappmsg = 2594,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/checktmplver")]
        mmbiz_bin_checktmplver = 2731,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/appmsgreport")]
        mmbiz_bin_appmsgreport = 2998,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/ffwxhbinvalidateshareurl")]
        mmpay_bin_ftfhb_ffwxhbinvalidateshareurl = 1971,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getcloudimsession")]
        mmbiz_bin_wxabusiness_getcloudimsession = 2985,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/joincloudimroom")]
        mmbiz_bin_wxabusiness_joincloudimroom = 1991,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetcardentrancestyle")]
        mmpay_bin_mktgetcardentrancestyle = 2793,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetmktcardhomepage")]
        mmpay_bin_mktgetmktcardhomepage = 2619,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetcardpkgmchinfo")]
        mmpay_bin_mktgetcardpkgmchinfo = 2769,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktdeletemchinlist")]
        mmpay_bin_mktdeletemchinlist = 1768,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetmkttickethomepage")]
        mmpay_bin_mktgetmkttickethomepage = 2940,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktgetmktinvalidtickethomepage")]
        mmpay_bin_mktgetmktinvalidtickethomepage = 2979,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktdeletecardinticketlist")]
        mmpay_bin_mktdeletecardinticketlist = 2660,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktdeletecardininvalidlist")]
        mmpay_bin_mktdeletecardininvalidlist = 2707,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktbatchdeletecardininvalidlist")]
        mmpay_bin_mktbatchdeletecardininvalidlist = 2850,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktfollowcardbdmch")]
        mmpay_bin_mktfollowcardbdmch = 2720,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktcheckmchservicepos")]
        mmpay_bin_mktcheckmchservicepos = 2553,
        [WXCGIUrl("/cgi-bin/mmpay-bin/mktuncheckmchservicepos")]
        mmpay_bin_mktuncheckmchservicepos = 2595,
        [WXCGIUrl("/cgi-bin/mmpay-bin/planindex")]
        mmpay_bin_planindex = 2796,
        [WXCGIUrl("/cgi-bin/mmpay-bin/manageplan")]
        mmpay_bin_manageplan = 2507,
        [WXCGIUrl("/cgi-bin/mmpay-bin/modifyplan")]
        mmpay_bin_modifyplan = 2614,
        [WXCGIUrl("/cgi-bin/mmpay-bin/addplan")]
        mmpay_bin_addplan = 2780,
        [WXCGIUrl("/cgi-bin/mmpay-bin/preaddplan")]
        mmpay_bin_preaddplan = 1770,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getrecommendedmusiclist")]
        micromsg_bin_getrecommendedmusiclist = 341,
        [WXCGIUrl("/cgi-bin/micromsg-bin/reportrecommendedmusicfeedback")]
        micromsg_bin_reportrecommendedmusicfeedback = 298,
        [WXCGIUrl("/cgi-bin/micromsg-bin/sprbgmsearch")]
        micromsg_bin_sprbgmsearch = 3645,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/getshowsource")]
        mmpay_bin_ftfhb_getshowsource = 2620,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/confirmshowsource")]
        mmpay_bin_ftfhb_confirmshowsource = 2969,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/deleteshowsource")]
        mmpay_bin_ftfhb_deleteshowsource = 2665,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/wxhbreport")]
        mmpay_bin_ftfhb_wxhbreport = 2715,
        [WXCGIUrl("/cgi-bin/mmpay-bin/reportpayres_tsbc")]
        mmpay_bin_reportpayres_tsbc = 2739,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getpayfunctionswitchlist")]
        micromsg_bin_getpayfunctionswitchlist = 2680,
        [WXCGIUrl("/cgi-bin/micromsg-bin/batchfunctionoperate")]
        micromsg_bin_batchfunctionoperate = 2938,
        [WXCGIUrl("/cgi-bin/micromsg-bin/speedtestreport")]
        micromsg_bin_speedtestreport = 271,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/searchwxa")]
        mmbiz_bin_wxabusiness_searchwxa = 2599,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/reportsearchwxa")]
        mmbiz_bin_wxabusiness_reportsearchwxa = 2678,
        [WXCGIUrl("/cgi-bin/mmpay-bin/ftfhb/gethbrefundconfig")]
        mmpay_bin_ftfhb_gethbrefundconfig = 1477,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/qrconnect_getcode")]
        mmbiz_bin_qrconnect_getcode = 2854,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/qrconnect_queryuuid")]
        mmbiz_bin_qrconnect_queryuuid = 2525,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/bizattr/subscribemsg")]
        mmbiz_bin_bizattr_subscribemsg = 2920,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/reportmusic")]
        mmbiz_bin_reportmusic = 2718,
        [WXCGIUrl("/cgi-bin/mmpay-bin/lqtlqautoin/qrysetting")]
        mmpay_bin_lqtlqautoin_qrysetting = 2668,
        [WXCGIUrl("/cgi-bin/mmpay-bin/lqtlqautoin/modifytrantime")]
        mmpay_bin_lqtlqautoin_modifytrantime = 1640,
        [WXCGIUrl("/cgi-bin/mmpay-bin/lqtlqautoin/openlqautotrans")]
        mmpay_bin_lqtlqautoin_openlqautotrans = 2896,
        [WXCGIUrl("/cgi-bin/mmpay-bin/lqtlqautoin/closeautolqtolqt")]
        mmpay_bin_lqtlqautoin_closeautolqtolqt = 2512,
        [WXCGIUrl("/cgi-bin/mmpay-bin/getpayplugin")]
        mmpay_bin_getpayplugin = 1820,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/getweapplistbylocation")]
        mmbiz_bin_wxabusiness_getweapplistbylocation = 1913,
        [WXCGIUrl("/cgi-bin/mmbiz-bin/wxabusiness/share_transid")]
        mmbiz_bin_wxabusiness_share_transid = 1961,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonehomepage")]
        mmpay_bin_transferphonehomepage = 2952,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonegethisrcvrs")]
        mmpay_bin_transferphonegethisrcvrs = 2993,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonedelhisrcvr")]
        mmpay_bin_transferphonedelhisrcvr = 1275,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonegetrcvr")]
        mmpay_bin_transferphonegetrcvr = 1495,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonecheckname")]
        mmpay_bin_transferphonecheckname = 2694,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphoneplaceorder")]
        mmpay_bin_transferphoneplaceorder = 2878,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonepaycheck")]
        mmpay_bin_transferphonepaycheck = 2817,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonesuccpage")]
        mmpay_bin_transferphonesuccpage = 1903,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonegetswitch")]
        mmpay_bin_transferphonegetswitch = 1813,
        [WXCGIUrl("/cgi-bin/mmpay-bin/transferphonechangeswitch")]
        mmpay_bin_transferphonechangeswitch = 1724,
        [WXCGIUrl("/cgi-bin/micromsg-bin/verifypersonalinfo")]
        micromsg_bin_verifypersonalinfo = 460,
        [WXCGIUrl("/cgi-bin/micromsg-bin/getchatroomannouncement")]
        micromsg_bin_getchatroomannouncement = 992,
        [WXCGIUrl("/cgi-bin/micromsg-bin/newgetinvitefriend")]
        micromsg_bin_newgetinvitefriend = 135,
        [WXCGIUrl("/cgi-bin/micromsg-bin/fpfreshnl")]
        micromsg_bin_fpfreshnl = 3789
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed partial class WXCGIUrlAttribute : Attribute
    {
        /// <summary>
        /// Url地址
        /// </summary>
        public string Url { get; }
        /// <summary>
        /// PB编码
        /// </summary>
        public WXEncode Encode { get; set; }
        /// <summary>
        /// 长链请求号
        /// </summary>
        public uint RequestID { get; set; }
        /// <summary>
        /// 长链响应号
        /// </summary>
        public uint ResponseID { get; set; }
        /// <summary>
        /// 使用代理
        /// </summary>
        public bool Proxy { get; set; } = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url"></param>
        public WXCGIUrlAttribute(string url)
        {
            Url = url;
            Encode = WXEncode.AES;
            RequestID = 0;
            ResponseID = 0;
            Proxy = false;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cmd"></param>
        public WXCGIUrlAttribute(string url, uint cmd)
        {
            Url = url;
            Encode = WXEncode.AES;
            RequestID = cmd;
            ResponseID = cmd + 1000000000;
        }
    }

    /// <summary>
    /// CGIURL扩展
    /// </summary>
    public static partial class WXCGIUrlExtensions
    {
        /// <summary>
        /// 获取URL
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetUrl(this WXCGIUrl target)
        {
            var result = default(string);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXCGIUrlAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXCGIUrlAttribute coAttrs = attris[0] as WXCGIUrlAttribute;
                result = coAttrs.Url;
            }
            return result;
        }

        /// <summary>
        /// 获取PB编码
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static WXEncode GetEncode(this WXCGIUrl target)
        {
            var result = default(WXEncode);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXCGIUrlAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXCGIUrlAttribute coAttrs = attris[0] as WXCGIUrlAttribute;
                result = coAttrs.Encode;
            }
            return result;
        }

        /// <summary>
        /// 获取长链请求号
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static uint GetRequestID(this WXCGIUrl target)
        {
            var result = default(uint);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXCGIUrlAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXCGIUrlAttribute coAttrs = attris[0] as WXCGIUrlAttribute;
                result = coAttrs.RequestID;
            }
            return result;
        }

        /// <summary>
        /// 获取长链响应号
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static uint GetResponseID(this WXCGIUrl target)
        {
            var result = default(uint);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXCGIUrlAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXCGIUrlAttribute coAttrs = attris[0] as WXCGIUrlAttribute;
                result = coAttrs.ResponseID;
            }
            return result;
        }

        /// <summary>
        /// 获取是否代理
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool GetProxy(this WXCGIUrl target)
        {
            var result = default(bool);
            var attris = target.GetType().GetField(target.ToString()).GetCustomAttributes(typeof(WXCGIUrlAttribute), true);
            if (attris != null && attris.Length > 0)
            {
                WXCGIUrlAttribute coAttrs = attris[0] as WXCGIUrlAttribute;
                result = coAttrs.Proxy;
            }
            return result;
        }
    }
}
