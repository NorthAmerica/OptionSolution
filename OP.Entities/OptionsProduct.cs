using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期权产品
    /// </summary>
    public class OptionsProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid OptionsProductID { get; set; }
        [DisplayName("合作者名称")]
        public string PartnerName { get; set; }
        [DisplayName("产品名称")]
        public string ProductName { get; set; }
        [DisplayName("产品特征")]
        public string ProductDescription { get; set; }
        [DisplayName("产品描述（显示在提交订单中）")]
        public string ProductDesc { get; set; }
        [DisplayName("产品详细描述（显示在保单详情，分行）")]
        public string ProductDtlDesc { get; set; }
        [DisplayName("（基准价-结算价）* 50% * 购买量,收益计算公式")]
        public string Formula { get; set; }
        [DisplayName("产品说明链接")]
        public string ProductUrl { get; set; }
        [DisplayName("合约名称")]
        public string Contract { get; set; }
        [DisplayName("合约名称(中文)")]
        public string ContractChs { get; set; }
        /// <summary>
        /// 期权类型《看涨期权》《看跌期权》
        /// </summary>
        [DisplayName("期权类型")]
        public string OptionType { get; set; }
        /// <summary>
        /// 结算日类型《欧式期权》《美式期权》
        /// </summary>
        [DisplayName("结算日类型")]
        public string EndType { get; set; }
        [DisplayName("新增日期")]
        public DateTime? AddDate { get; set; }
        [DisplayName("启动日期")]
        public DateTime? BeginDate { get; set; }
        [DisplayName("暂停日期")]
        public DateTime? EndDate { get; set; }
        [DisplayName("产品期限(天)")]
        public int Deadline { get; set; }
        [DisplayName("产品单位")]
        public string Unit { get; set; }
        [DisplayName("产品手续费")]
        public decimal Charge { get; set; }
        /// <summary>
        /// 手续费类型 分为《固定值》《单位值》
        /// </summary>
        [DisplayName("手续费类型")]
        public string ChargeType { get; set; }
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
        [DisplayName("最大购买份数")]
        public int MaxNum { get; set; }
        /// <summary>
        /// 状态分为 0初始化 1启用 2停用
        /// </summary>
        [DisplayName("产品状态")]
        public int Status { get; set; }
        [DisplayName("是否上传")]
        public bool IsUpLoad { get; set; }
        /// <summary>
        /// 结算价类型《结算日期货合约收盘价》《产品期限内所有交易日收盘价的均价》
        /// </summary>
        [DisplayName("结算价类型")]
        public string CallPriceType { get; set; }
    }
}
