using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期权类型 决定不同算法
    /// </summary>
    public class OptionType
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int OptionTypeID { get; set; }
        [DisplayName("期权类型名称")]
        public string OptionTypeName { get; set; }
        [DisplayName("期权类型描述")]
        public string OptionTypeDescribe { get; set; }
    }
}
