using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OP.Entities.Models
{
    /// <summary>
    /// 现货盘面对冲表
    /// </summary>
    public class GoodsFuture
    {
        [Key]
        public Guid GoodsFuturesID { get; set; } // GoodsFuturesID (Primary key)
        public Guid GoodsPurchaseID { get; set; } // GoodsPurchaseID
        /// <summary>
        /// 合约代码
        /// </summary>
        public string Contract { get; set; } // Contract
        /// <summary>
        /// 资金账号
        /// </summary>
        public string FundAccount { get; set; } // FundAccount
        /// <summary>
        /// 持仓量
        /// </summary>
        public string Positions { get; set; } // Positions
        /// <summary>
        /// 对应合同号
        /// </summary>
        public string ContractNo { get; set; } // ContractNo
        /// <summary>
        /// 买入开仓价格
        /// </summary>
        public decimal? BuyOpen { get; set; } // BuyOpen
        /// <summary>
        /// 卖出平仓价格
        /// </summary>
        public decimal? SellClose { get; set; } // SellClose
        /// <summary>
        /// 卖出开仓价格
        /// </summary>
        public decimal? SellOpen { get; set; } // SellOpen
        /// <summary>
        /// 买入平仓价格
        /// </summary>
        public decimal? BuyClose { get; set; } // BuyClose
        /// <summary>
        /// 盈亏点数
        /// </summary>
        public decimal? PointCount { get; set; } // PointCount
        /// <summary>
        /// 盈亏金额
        /// </summary>
        public decimal? Amount { get; set; } // Amount
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RecordTime { get; set; } // RecordTime
        /// <summary>
        /// 记录人
        /// </summary>
        public string Noter { get; set; } // Noter
        public GoodsFuture()
        {
            GoodsFuturesID = System.Guid.NewGuid();
        }
    }
}
