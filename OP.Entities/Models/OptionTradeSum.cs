using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期权交易汇总
    /// </summary>
    public class OptionTradeSum
    {
        public System.Guid OptionTradeSumID { get; set; } // OptionTradeSumID (Primary key)
        public int OptionsProductID { get; set; } // 期权产品ID
        public string ProductName { get; set; } // 期权产品名称
        public decimal TradeNumSum { get; set; } // 总成交量
        public decimal TradeAmountSum { get; set; } // 总成交金额
        public string BeginDate { get; set; } // 成交日期
        public string EndDate { get; set; } // 结算日期
        /// <summary>
        /// 0:数据已接收但未处理 1：合约已设置完成 2：基准价结算日已同步,等待结算
        /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
        /// </summary>
        public string ManageStatus { get; set; } // 处理状态
        /// <summary>
        /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
        /// </summary>
        public string FundStatus { get; set; } // 资金状态

        public OptionTradeSum()
        {
            OptionTradeSumID = System.Guid.NewGuid();
        }
    }
}
