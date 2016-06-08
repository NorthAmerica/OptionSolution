using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期货价格表
    /// </summary>
    public class FuturePrice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid FuturePriceID { get; set; }
        [DisplayName("价格")]
        public decimal Price { get; set; }
        [DisplayName("价格类型")]
        public string Type { get; set; }
        [DisplayName("合约名称")]
        public string TradeCode { get; set; }
        [DisplayName("时间")]
        public string Date { get; set; }
    }
}
