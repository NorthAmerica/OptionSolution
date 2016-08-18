using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 数字类型《固定值》《百分比》《单位值》
    /// </summary>
    public class NumberType
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int NumberTypeID { get; set; }
        [DisplayName("数字类型名称")]
        public string NumberTypeName { get; set; }
        [DisplayName("数字类型描述")]
        public string NumberTypeDescribe { get; set; }
    }
}
