using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 留言栏
    /// </summary>
    public class GuestBook
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int GuestBookID { get; set; }
        [DisplayName("姓名")]
        public string GuestName { get; set; }
        [DisplayName("手机")]
        public string GuestMobile { get; set; }
        [DisplayName("留言内容")]
        public string GuestContent { get; set; }
        [DisplayName("留言时间")]
        public DateTime GuestDate { get; set; }
    }
}
