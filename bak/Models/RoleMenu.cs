using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    public class RoleMenu
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RoleMenuID { get; set; }
        [DisplayName("角色ID")]
        public int RoleID { get; set; }
        [DisplayName("菜单ID")]
        public int MenuID { get; set; }
    }
}
