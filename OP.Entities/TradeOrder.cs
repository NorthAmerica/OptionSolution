using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 从第三方获取的成交记录
    /// </summary>
    public class TradeOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid TradeOrderID { get; set; }
        [DisplayName("期权产品ID")]
        public Guid OptionsProductID { get; set; }
        [DisplayName("第三方公司名称")]
        public string PartnerName { get; set; }
        [DisplayName("第三方ID")]
        public string BusinessNo { get; set; }
        [DisplayName("第三方消息")]
        public string BusinessInfo { get; set; }
        [DisplayName("支付时间")]
        public DateTime PayTime { get; set; }
        [DisplayName("成交数量")]
        public decimal TradeNum { get; set; }
        [DisplayName("手续费")]
        public decimal Charge { get; set; }
        [DisplayName("成交金额")]
        public decimal TradePrice { get; set; }
        [DisplayName("是否通过查询WIND数据后成交入库")]
        public bool IsWindInsert { get; set; }
    }
}
