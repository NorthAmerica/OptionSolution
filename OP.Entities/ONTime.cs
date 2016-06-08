using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 开启时间设置
    /// </summary>
    public class ONTime
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ONTimeID { get; set; }
        [DisplayName("开始时间")]
        public DateTime BeginTime { get; set; }
        [DisplayName("结束时间")]
        public DateTime EndTime { get; set; }
    }
}
