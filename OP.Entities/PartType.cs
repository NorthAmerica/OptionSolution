using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 部分类型《按下跌部分》《按超过下跌部分》
    /// </summary>
    public class PartType
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int PartTypeID { get; set; }
        [DisplayName("部分类型名称")]
        public string PartTypeName { get; set; }
        [DisplayName("部分类型描述")]
        public string PartTypeDescribe { get; set; }
    }
}
