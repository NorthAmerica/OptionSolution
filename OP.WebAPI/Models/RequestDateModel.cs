using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.Models
{
    public class RequestDateModel
    {
        public List<RequestDate> datas { get; set; }
    }
    public class RequestDate
    {
        public string optionsProductId { get; set; }
        public string tradeDate { get; set; }
    }
}