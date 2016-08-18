using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 合作者
    /// </summary>
    public class Partner
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int PartnerID { get; set; }
        [DisplayName("合作者名称")]
        public string PartnerName { get; set; }
        [DisplayName("合作者描述")]
        public string PartnerDescribe { get; set; }
    }
}
