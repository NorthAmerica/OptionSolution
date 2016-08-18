using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 留言栏
    /// </summary>
    public class GuestBook
    {
        public int GuestBookID { get; set; } // GuestBookID (Primary key)
        public string GuestName { get; set; } // 姓名
        public string GuestMobile { get; set; } // 手机
        public string GuestContent { get; set; } // 留言内容
        public System.DateTime GuestDate { get; set; } // 留言时间
    }
}
