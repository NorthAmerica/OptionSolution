using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期权交易明细
    /// </summary>
    public class OptionTrade
    {
        public System.Guid OptionTradeID { get; set; } // OptionTradeID (Primary key)
        public System.Guid OptionsProductID { get; set; } // 期权产品ID
        public string BusinessNo { get; set; } // 第三方保单号
        public string BusinessInfo { get; set; } // 第三方附加信息
        public string PartnerName { get; set; } // 合作者名称
        public string ProductName { get; set; } // 期权产品名称
        public string OptionType { get; set; } // 期权类型
        public string CallPriceType { get; set; } // 结算价类型
        public int? Deadline { get; set; } // 产品期限(天)
        public decimal? TradeNum { get; set; } // 成交量
        public decimal? TradeCharge { get; set; } // 成交手续费
        public decimal? TradePrice { get; set; } // 成交保费
        public decimal? TradeMargin { get; set; } // 成交保证金
        public System.DateTime? TradeDate { get; set; } // 成交日期
        public System.DateTime? BeginDate { get; set; } // 开始日期
        public string Contract { get; set; } // 合约名称
        public decimal? BeginClose { get; set; } // 基准价
        public decimal? EndClose { get; set; } // 结算价
        public System.DateTime? EndDate { get; set; } // 结算日期
        public decimal? RiseCompensate { get; set; } // 上涨赔付金额
        public decimal? FallCompensate { get; set; } // 下跌赔付金额
        ///<summary>
        /// 0:数据已接收但未处理 1：合约已设置完成 2：基准价结算日已同步,等待结算
        /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
        /// </summary>
        public string ManageStatus { get; set; } // 处理状态
        /// <summary>
        /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
        /// </summary>
        public string FundStatus { get; set; } // 资金状态
        /// <summary>
        /// 0：未发送 1：已发送
        /// </summary>
        public int? SendStatus { get; set; } // 发送状态

        public OptionTrade()
        {
            OptionTradeID = System.Guid.NewGuid();
        }
    }
}
