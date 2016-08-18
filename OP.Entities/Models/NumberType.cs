using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 数字类型《固定值》《百分比》《单位值》
    /// </summary>
    public class NumberType
    {
        public int NumberTypeID { get; set; } // NumberTypeID (Primary key)
        public string NumberTypeName { get; set; } // 数字类型名称
        public string NumberTypeDescribe { get; set; } // 数字类型描述
    }
}
