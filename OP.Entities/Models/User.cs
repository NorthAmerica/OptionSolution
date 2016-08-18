using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class User
    {
        public int UserID { get; set; } // UserID (Primary key)
        public string UserName { get; set; } // 用户名 (length: 50)
        public string UserPassword { get; set; } // 用户密码 (length: 50)
        public bool Enable { get; set; } // 是否启用s
        public bool IsAdmin { get; set; } // 是否管理员
        public string Date { get; set; } // 创建时间
    }
}
