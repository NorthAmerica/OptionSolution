using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 从第三方获取的成交记录
    /// </summary>
    public class TradeOrder
    {
        public System.Guid TradeOrderID { get; set; } // TradeOrderID (Primary key)
        public System.Guid OptionsProductID { get; set; } // 期权产品ID
        public string PartnerName { get; set; } // 第三方公司名称
        public string BusinessNo { get; set; } // 第三方ID
        public string BusinessInfo { get; set; } // 第三方消息
        public System.DateTime PayTime { get; set; } // 支付时间
        public decimal TradeNum { get; set; } // 成交数量
        public decimal Charge { get; set; } // 手续费
        public decimal TradePrice { get; set; } // 成交金额
        public bool IsWindInsert { get; set; } // 是否通过查询WIND数据后成交入库
        public bool IsReturnOK { get; set; } // 成交回报发送到第三方是否成功
        public System.DateTime? CreateDate { get; set; } // 创建时间

        public TradeOrder()
        {
            TradeOrderID = System.Guid.NewGuid();
        }
    }
}
