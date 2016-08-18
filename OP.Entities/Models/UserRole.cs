using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRole
    {
        public int UserRoleID { get; set; } // UserRoleID (Primary key)
        public int UserID { get; set; } // 用户ID
        public int RoleID { get; set; } // 角色ID
    }
}
