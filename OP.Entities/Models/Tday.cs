using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 交易日
    /// </summary>
    public class Tday
    {
        public int TdayID { get; set; } // TdayID (Primary key)
        public string Tdays { get; set; } // 交易日日期
        public int Tyear { get; set; } // 年份
        public int Tnum { get; set; } // 交易天数
    }
}
