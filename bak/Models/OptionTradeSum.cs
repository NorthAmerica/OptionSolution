using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 期权交易汇总
    /// </summary>
    public class OptionTradeSum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid OptionTradeSumID { get; set; }
        [DisplayName("期权产品ID")]
        public int OptionsProductID { get; set; }
        [DisplayName("期权产品名称")]
        public string ProductName { get; set; }
        [DisplayName("总成交量")]
        public decimal TradeNumSum { get; set; }
        [DisplayName("总成交金额")]
        public decimal TradeAmountSum { get; set; }
        [DisplayName("成交日期")]
        public string BeginDate { get; set; }
        [DisplayName("结算日期")]
        public string EndDate { get; set; }
        /// <summary>
        /// 0:数据已接收但未处理 1：合约已设置完成 2：基准价结算日已同步,等待结算
        /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
        /// </summary>
        [DisplayName("处理状态")]
        public string ManageStatus { get; set; }
        /// <summary>
        /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
        /// </summary>
        [DisplayName("资金状态")]
        public string FundStatus { get; set; }
    }
}
