using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期货价格表
    /// </summary>
    public class FuturePrice
    {
        public System.Guid FuturePriceID { get; set; } // FuturePriceID (Primary key)
        public decimal Price { get; set; } // 价格
        public string Type { get; set; } // 价格类型
        public string TradeCode { get; set; } // 合约名称
        public System.DateTime Date { get; set; } // 时间

        public FuturePrice()
        {
            FuturePriceID = System.Guid.NewGuid();
        }
    }
}
