using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OP.Brochure.Models
{
    public class BrochureViewModel
    {
        public Guid BrochureID { get; set; }
        public Guid OptionsProductID { get; set; }
        [DisplayName("产品名称")]
        public string ProductName { get; set; }
        [DisplayName("合约名称")]
        public string Contract { get; set; }
        [DisplayName("产品期限(天)")]
        public int Deadline { get; set; }
        [DisplayName("产品费用")]
        public decimal Price { get; set; }
        /// <summary>
        /// 金额类型 分为《固定值》《单位值》
        /// </summary>
        [DisplayName("金额类型")]
        public string PriceType { get; set; }
        /// <summary>
        /// 产品费用类型 分为《保证金》《保费》
        /// </summary>
        [DisplayName("产品费用类型")]
        public string AmountType { get; set; }
        [DisplayName("标的合约")]
        public string ContractDescrip { get; set; }
        [DisplayName("购买起点")]
        public string BuyBegin { get; set; }
        [DisplayName("购买时间")]
        public string BuyTime { get; set; }
        [DisplayName("补偿说明")]
        public string PayDescrip { get; set; }
        [DisplayName("结算公式")]
        public string SettlementFormula { get; set; }
        [DisplayName("结算公式图(盈亏结构图)")]
        public string SFPic { get; set; }
        [DisplayName("购买日")]
        public string StartDateDescrip { get; set; }
        [DisplayName("到期日")]
        public string EndDateDescrip { get; set; }
        [DisplayName("交易日")]
        public string TradeDateDescrip { get; set; }
        [DisplayName("示例图")]
        public string ExamplePic { get; set; }
        [DisplayName("风险揭示书链接")]
        public string RiskAnnouncementURL { get; set; }
        [DisplayName("价格补偿服务购买协议")]
        public string PurchaseAgreementURL { get; set; }
        [DisplayName("常见问题")]
        public string FAQ { get; set; }
        [DisplayName("示例说明")]
        public string ExampleDescrip { get; set; }
    }
}