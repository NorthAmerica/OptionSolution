using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期货成交情况
    /// </summary>
    public class FuturesTradeVolume
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid FuturesTradeVolumeID { get; set; }
        [DisplayName("账号")]
        public string ZH { get; set; }
        [DisplayName("交易日")]
        public string JYR { get; set; }
        [DisplayName("委托号")]
        public string WTH { get; set; }
        [DisplayName("成交号")]
        public string CJH { get; set; }
        [DisplayName("请求号")]
        public string QQH { get; set; }
        [DisplayName("交易所")]
        public string JYS { get; set; }
        [DisplayName("合约")]
        public string HY { get; set; }
        [DisplayName("买卖")]
        public string MM { get; set; }
        [DisplayName("开平")]
        public string KP { get; set; }
        [DisplayName("投保")]
        public string TB { get; set; }
        [DisplayName("成交价")]
        public decimal CJJ { get; set; }
        [DisplayName("成交量")]
        public decimal CJL { get; set; }
        [DisplayName("成交金额")]
        public decimal CJJE { get; set; }
        [DisplayName("实际日期")]
        public string SJRQ { get; set; }
        [DisplayName("成交时间")]
        public string CJSJ { get; set; }
        [DisplayName("主账号")]
        public string ZZH { get; set; }
        [DisplayName("系统号")]
        public string XTH { get; set; }
        [DisplayName("手续费")]
        public decimal SXF { get; set; }
        [DisplayName("平仓浮动盈亏")]
        public decimal PCFDYK { get; set; }
        [DisplayName("平仓盈亏")]
        public decimal PCYK { get; set; }
        [DisplayName("基础手续费")]
        public decimal JCSXF { get; set; }

    }
}
