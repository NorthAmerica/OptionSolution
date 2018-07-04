using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.Models
{
    public class ReturnFuturePriceModel
    {
        public string result { get; set; }
        public string message { get; set; }
        public List<RFuturePrice> datas { get; set; }
    }
    public class RFuturePrice
    {
        public string date { get; set; }
        public decimal price { get; set; }
    }
}