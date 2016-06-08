using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace OP.Entities
{
    /// <summary>
    /// 期权交易明细
    /// </summary>
    public class OptionTrade
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid OptionTradeID { get; set; }
        [DisplayName("期权产品ID")]
        public Guid OptionsProductID { get; set; }
        [DisplayName("第三方保单号")]
        public string BusinessNo { get; set; }
        [DisplayName("第三方附加信息")]
        public string BusinessInfo { get; set; }
        [DisplayName("合作者名称")]
        public string PartnerName { get; set; }
        [DisplayName("期权产品名称")]
        public string ProductName { get; set; }
        [DisplayName("期权类型")]
        public string OptionType { get; set; }
        [DisplayName("结算价类型")]
        public string CallPriceType { get; set; }
        [DisplayName("产品期限(天)")]
        public int? Deadline { get; set; }
        [DisplayName("成交量")]
        public decimal? TradeNum { get; set; }
        [DisplayName("成交手续费")]
        public decimal? TradeCharge { get; set; }
        [DisplayName("成交保费")]
        public decimal? TradePrice { get; set; }
        [DisplayName("成交保证金")]
        public decimal? TradeMargin { get; set; }
        [DisplayName("成交日期")]
        public DateTime? TradeDate { get; set; }
        [DisplayName("开始日期")]
        public DateTime? BeginDate { get; set; }
        [DisplayName("合约名称")]
        public string Contract { get; set; }
        [DisplayName("基准价")]
        public decimal? BeginClose { get; set; }
        [DisplayName("结算价")]
        public decimal? EndClose { get; set; }
        [DisplayName("结算日期")]
        public DateTime? EndDate { get; set; }
        [DisplayName("上涨赔付金额")]
        public decimal? RiseCompensate { get; set; }
        [DisplayName("下跌赔付金额")]
        public decimal? FallCompensate { get; set; }
        /// <summary>
        /// 0:数据已接收但未处理 1：合约已设置完成 2：基准价结算日已同步,等待结算
        /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
        /// </summary>
        [DisplayName("处理状态")]
        public string ManageStatus { get; set; }
        /// <summary>
        /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
        /// </summary>
        [DisplayName("资金状态")]
        public string FundStatus { get; set; }
        /// <summary>
        /// 0：未发送 1：已发送
        /// </summary>
        [DisplayName("发送状态")]
        public int? SendStatus { get; set; }
    }
}
