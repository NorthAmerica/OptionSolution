using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RoleID { get; set; }
        [Required(ErrorMessage = "请输入角色名称")]
        [DisplayName("角色名称")]
        public string RoleName { get; set; }
        [DisplayName("角色描述")]
        public string RoleDescribe { get; set; }
    }
}
