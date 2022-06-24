namespace WeChat.Core.Protocol.Protos
{
    #region 银行卡明细
    public class BankDetail
    {
        public string retcode { get; set; }
        public string retmsg { get; set; }
        public string bind_query_scene { get; set; }
        public int query_cache_time { get; set; }
        public Array[] Array { get; set; }
        public object[] virtual_card_array { get; set; }
        public User_Info user_info { get; set; }
        public Switch_Info switch_info { get; set; }
        public Balance_Info balance_info { get; set; }
        public object[] history_card_array { get; set; }
        public object[] balance_notice { get; set; }
        public object[] fetch_notice { get; set; }
        public int query_order_time { get; set; }
        public Lqt_Info lqt_info { get; set; }
        public long time_stamp { get; set; }
        public Bind_Card_Menu bind_card_menu { get; set; }
        public Bank_Priority bank_priority { get; set; }
        public object[] paymenu_array { get; set; }
        public int paymenu_use_new { get; set; }
        public Wallet_Info wallet_info { get; set; }
        public int unipayorderstate { get; set; }
        public object[] favor_compose_channel_info { get; set; }
        public string final_support_bank_list { get; set; }
    }

    public class User_Info
    {
        public string is_reg { get; set; }
        public string true_name { get; set; }
        public string bind_card_num { get; set; }
        public string icard_user_flag { get; set; }
        public string cre_name { get; set; }
        public string cre_type { get; set; }
        public string transfer_url { get; set; }
        public string lct_wording { get; set; }
        public string lct_url { get; set; }
        public long authen_channel_state { get; set; }
        public Lqt_Cell_Info lqt_cell_info { get; set; }
    }

    public class Lqt_Cell_Info
    {
        public int is_show_cell { get; set; }
        public string cell_icon { get; set; }
        public int is_open_lqt { get; set; }
        public string lqt_title { get; set; }
        public string lqt_wording { get; set; }
    }

    public class Switch_Info
    {
        public long switch_bit { get; set; }
    }

    public class Balance_Info
    {
        public string use_cft_balance { get; set; }
        public string balance_bank_type { get; set; }
        public string balance_bind_serial { get; set; }
        public string total_balance { get; set; }
        public string avail_balance { get; set; }
        public string frozen_balance { get; set; }
        public string fetch_balance { get; set; }
        public string mobile { get; set; }
        public string support_micropay { get; set; }
        public string balance_list_url { get; set; }
        public string balance_version { get; set; }
        public int time_out { get; set; }
        public string balance_logo_url { get; set; }
        public Prompt_Info prompt_info { get; set; }
        public string busi_frozen_balance { get; set; }
    }

    public class Prompt_Info
    {
    }

    public class Lqt_Info
    {
        public string lqt_bank_type { get; set; }
        public string lqt_bind_serial { get; set; }
        public string lqt_bank_name { get; set; }
        public int total_balance { get; set; }
        public int avail_balance { get; set; }
        public string lqt_logo_url { get; set; }
        public string mobile { get; set; }
        public string support_micropay { get; set; }
    }

    public class Bind_Card_Menu
    {
        public int menu_jump_type { get; set; }
        public string menu_jump_url { get; set; }
        public string menu_username { get; set; }
        public string menu_path { get; set; }
        public string menu_title { get; set; }
        public string menu_icon_url { get; set; }
    }

    public class Bank_Priority
    {
        public Bankinfo_Array[] bankinfo_array { get; set; }
    }

    public class Bankinfo_Array
    {
        public string bind_serial { get; set; }
    }

    public class Wallet_Info
    {
        public int wallet_balance { get; set; }
        public int wallet_entrance_balance_switch_state { get; set; }
    }

    public class Array
    {
        public string IsSaveYfq { get; set; }
        public string bank_flag { get; set; }
        public string bank_name { get; set; }
        public string bank_phone { get; set; }
        public string bank_type { get; set; }
        public string bankacc_type { get; set; }
        public string bind_day_quota { get; set; }
        public string bind_once_quota { get; set; }
        public string bind_serial { get; set; }
        public string bind_tail { get; set; }
        public string day_quota_1 { get; set; }
        public string day_quota_3 { get; set; }
        public string expired_flag { get; set; }
        public string mobile { get; set; }
        public string once_quota_1 { get; set; }
        public string once_quota_3 { get; set; }
        public string bank_card_tag { get; set; }
        public string extra_bind_flag { get; set; }
        public string bind_icharacter4 { get; set; }
        public int support_micropay { get; set; }
        public string support_save { get; set; }
        public string support_fetch { get; set; }
        public string fetch_pre_arrive_time { get; set; }
        public string draw_available { get; set; }
        public string draw_type { get; set; }
        public string export_start { get; set; }
        public string export_end { get; set; }
        public string bankacc_type_name { get; set; }
        public string draw_status { get; set; }
        public string arrive_type { get; set; }
        public string maintain_starttime { get; set; }
        public string maintain_endtime { get; set; }
        public string fetch_pre_arrive_time_wording { get; set; }
        public int support_foreign_mobile { get; set; }
        public string mobile_area { get; set; }
        public int support_intl_sms { get; set; }
        public int bind_state { get; set; }
        public string bind_version { get; set; }
    }
    #endregion
}
