using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.Models
{
    public class RequestFuturePriceModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Contract { get; set; }
    }
}