using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRole
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserRoleID { get; set; }
        [DisplayName("用户ID")]
        public int UserID { get; set; }
        [DisplayName("角色ID")]
        public int RoleID { get; set; }
    }
}
