using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 交易日
    /// </summary>
    public class Tday
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int TdayID { get; set; }
        [DisplayName("交易日日期")]
        public string Tdays { get; set; }
        [DisplayName("年份")]
        public int Tyear { get; set; }
        [DisplayName("交易天数")]
        public int Tnum { get; set; }
    }
}
