using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class User
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        [Required(ErrorMessage = "请输入用户名")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过50")]
        [DisplayName("用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(50, ErrorMessage = "密码长度不能超过50")]
        [DisplayName("用户密码")]
        [PasswordPropertyTextAttribute(true)]
        public string UserPassword { get; set; }
        [DisplayName("是否启用")]
        public bool Enable { get; set; }
        [DisplayName("是否管理员")]
        public bool IsAdmin { get; set; }
        [DisplayName("创建时间")]
        public string Date { get; set; }
    }
}
