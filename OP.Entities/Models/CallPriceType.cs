using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 结算价类型《结算日期货合约收盘价》《产品期限内所有交易日收盘价的均价》
    /// </summary>
    public class CallPriceType
    {
        public int CallPriceTypeID { get; set; } // CallPriceTypeID (Primary key)
        public string CallPriceTypeName { get; set; } // 结算价类型名称
        public string CallPriceTypeDescribe { get; set; } // 结算价类型描述
    }
}
