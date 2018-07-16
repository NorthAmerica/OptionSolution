using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期权订单
    /// </summary>
    public class OptionOrder
    {
        public System.Guid OptionOrderID { get; set; } // OptionTradeID (Primary key)
        public string CustomerName { get; set; } // 客户名称
        public string TransactionID { get; set; } //交易编号
        public string Contract { get; set; } // 合约名称
        public string ContractChs { get; set; } // 合约名称(中文)
        public string OptionType { get; set; } // 期权类型（亚式/香草）
        public string OptionDirection { get; set; } //期权方向（看涨/看跌）
        public string OptionStructure { get; set; } //产品结构（平值/虚值）
        public string TradeDirection { get; set; } //交易方向（买入/卖出）
        public System.DateTime? BeginDate { get; set; } // 开始日期
        public System.DateTime? EndDate { get; set; } // 结算日期
        public decimal? deadline { get; set; } // 期限
        public string OptionStyle { get; set; } //期权风格（欧式/美式）
        public decimal TradeNum { get; set; } //成交数量
        public decimal ExercisePrice { get; set; } //行权价
        public decimal? OptionRate { get; set; } //期权费率（%）(单位期权费/生效日参考价格)*100
        public decimal UnitOptionCost { get; set; } //单位期权费
        public decimal TotalOptionCost { get; set; } //期权费总额 （成交数量*单位期权费）
        public decimal BeginPrice { get; set; } //生效日参考价格
        public decimal NominalValue { get; set; } //名义市值（元） (生效日参考价格*成交数量)
    }
}
