using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 部分类型《按下跌部分》《按超过下跌部分》
    /// </summary>
    public class PartType
    {
        public int PartTypeID { get; set; } // PartTypeID (Primary key)
        public string PartTypeName { get; set; } // 部分类型名称
        public string PartTypeDescribe { get; set; } // 部分类型描述
    }
}
