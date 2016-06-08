using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期货账户资金
    /// </summary>
    public class FuturesFund
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid FuturesFundID { get; set; }
        [DisplayName("账号")]
        public string ZH { get; set; }
        [DisplayName("开始日期")]
        public string KSRQ { get; set; }
        [DisplayName("结束日期")]
        public string JSRQ { get; set; }
        [DisplayName("期初权益")]
        public decimal QCQY { get; set; }
        [DisplayName("期末权益")]
        public decimal QMQY { get; set; }
        [DisplayName("可用资金")]
        public decimal KYZJ { get; set; }
        [DisplayName("保证金")]
        public decimal BZJ { get; set; }
        [DisplayName("基础手续费")]
        public decimal JCSXF { get; set; }
        [DisplayName("附加手续费")]
        public decimal FJSXF { get; set; }
        [DisplayName("总手续费")]
        public decimal ZSXF { get; set; }
        [DisplayName("持仓浮动盈亏")]
        public decimal CCFDYK { get; set; }
        [DisplayName("持仓盯市盈亏")]
        public decimal CCDSYK { get; set; }
        [DisplayName("平仓浮动盈亏")]
        public decimal PCFDYK { get; set; }
        [DisplayName("平仓盯市盈亏")]
        public decimal PCDSYK { get; set; }
        [DisplayName("入金")]
        public decimal RJ { get; set; }
        [DisplayName("出金")]
        public decimal CJ { get; set; }
        [DisplayName("风险度")]
        public decimal FXD { get; set; }
    }
}
