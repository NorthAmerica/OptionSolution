using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 产品全局开关设置
    /// </summary>
    public class ONOFFSet
    {
        public int ONOFFSetID { get; set; } // ONOFFSetID (Primary key)
        public int ONOFFMode { get; set; } //  0：手动设置 1：时间自动设置
        public bool HandSwitch { get; set; } // 手动开关设置
    }

}
