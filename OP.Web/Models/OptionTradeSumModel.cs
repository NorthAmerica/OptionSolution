using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    public class OptionTradeSumModel
    {
        public string OptionsProductID { get; set; }
        public string PartnerName { get; set; }
        public string ProductName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OptionType { get; set; }
        public decimal TradeNumSum { get; set; }
        public decimal TradeChargeSum { get; set; }
        public decimal TradePriceSum { get; set; }
        public decimal TradeMarginSum { get; set; }
        public decimal RiseCompensateSum { get; set; }
        public decimal FallCompensateSum { get; set; }

    }
}