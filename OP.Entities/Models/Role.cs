using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        public int RoleID { get; set; } // RoleID (Primary key)
        public string RoleName { get; set; } // 角色名称
        public string RoleDescribe { get; set; } // 角色描述
    }
}
