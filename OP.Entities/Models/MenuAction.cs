using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 菜单操作类
    /// </summary>
    public class MenuAction
    {
        public int MenuActionID { get; set; } // MenuActionID (Primary key)

        ///<summary>
        /// 菜单ID
        ///</summary>
        public int? MenuID { get; set; } // MenuID

        ///<summary>
        /// 操作名称
        ///</summary>
        public string ActionName { get; set; } // ActionName

        ///<summary>
        /// 操作链接
        ///</summary>
        public string ActionUrl { get; set; } // ActionURL
    }
}
