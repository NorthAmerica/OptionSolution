using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        public int MenuID { get; set; } // MenuID (Primary key)
        public string MenuName { get; set; } // 菜单名 (length: 50)
        public string MenuURL { get; set; } // 菜单链接
        public int OrderNum { get; set; } // 排序号
        public int FMenuID { get; set; } // 父节点
    }
}
