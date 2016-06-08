using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace OP.Entities
{
    /// <summary>
    /// 结算价类型《结算日期货合约收盘价》《产品期限内所有交易日收盘价的均价》
    /// </summary>
    public class CallPriceType
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CallPriceTypeID { get; set; }
        [DisplayName("结算价类型名称")]
        public string CallPriceTypeName { get; set; }
        [DisplayName("结算价类型描述")]
        public string CallPriceTypeDescribe { get; set; }
    }
}
