using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace OP.Entities
{
    /// <summary>
    /// 宣传册数据
    /// </summary>
    public class Brochure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid BrochureID { get; set; }
        [DisplayName("期权产品ID")]
        public Guid? OptionsProductID { get; set; }
        [DisplayName("是否为模板")]
        public bool IsTemp { get; set; }
        [DisplayName("模板名称")]
        public string TempName { get; set; }
        [DisplayName("模板描述")]
        public string TempDescrip { get; set; }
        [DisplayName("新增修改模板时间")]
        public DateTime TempDate { get; set; }
        [DisplayName("新增宣传册时间")]
        public DateTime? AddDate { get; set; }
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
        public byte[] SFPic { get; set; }
        [DisplayName("生效日")]
        public string StartDateDescrip { get; set; }
        [DisplayName("到期日")]
        public string EndDateDescrip { get; set; }
        [DisplayName("交易日")]
        public string TradeDateDescrip { get; set; }
        [DisplayName("示例图")]
        public byte[] ExamplePic { get; set; }
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
