using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 开启时间设置
    /// </summary>
    public class ONTime
    {
        public int ONTimeID { get; set; } // ONTimeID (Primary key)
        public System.DateTime BeginTime { get; set; } // 开始时间
        public System.DateTime EndTime { get; set; } // 结束时间
    }
}
