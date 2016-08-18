using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    public class RoleMenu
    {
        public int RoleMenuID { get; set; } // RoleMenuID (Primary key)
        public int RoleID { get; set; } // 角色ID
        public int MenuID { get; set; } // 菜单ID
    }
}
