using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.TestModels
{
    public class ReturnOrderModel
    {
        /// <summary>
        /// 1:成功 0:失败
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        public List<TradeOrder> orders;
    }

    public class TradeOrder
    {
        public string OptionsProductID { get; set; }
        public string BusinessNo { get; set; }
        public string BusinessInfo { get; set; }
        public string PayTime { get; set; }
        public decimal TradeNum { get; set; }
        public decimal Charge { get; set; }
        public decimal TradePrice { get; set; }
    }
}