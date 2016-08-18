using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期权类型 决定不同算法
    /// </summary>
    public class OptionType
    {
        public int OptionTypeID { get; set; } // OptionTypeID (Primary key)
        public string OptionTypeName { get; set; } // 期权类型名称
        public string OptionTypeDescribe { get; set; } // 期权类型描述
    }
}
