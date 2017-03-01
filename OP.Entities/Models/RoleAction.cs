using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 操作权限类
    /// </summary>
    public class RoleAction
    {
        public int RoleActionID { get; set; } // RoleActionID (Primary key)

        ///<summary>
        /// 菜单操作ID
        ///</summary>
        public int? MenuActionID { get; set; } // MenuActionID

        ///<summary>
        /// 角色ID
        ///</summary>
        public int? RoleID { get; set; } // RoleID
    }
}
