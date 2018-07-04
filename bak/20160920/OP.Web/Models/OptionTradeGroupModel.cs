using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    public class OptionTradeGroupModel
    {
        public string OptionsProductID { get; set; }
        public string ProductName { get; set; }
        public string Deadline { get; set; }
        public decimal TradeNum { get; set; }
        public decimal TradeCharge { get; set; }
        public decimal TradePrice { get; set; }
        public decimal TradeMargin { get; set; }
        public decimal RiseCompensate { get; set; }
        public decimal FallCompensate { get; set; }
    }
}