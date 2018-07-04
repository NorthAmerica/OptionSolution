using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.TestModels
{
    /// <summary>
    /// 获取保单成交数据模型
    /// </summary>
    public class QueryInsureOrderModel
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// 操作类型：1获取保单并转账，2查询保单
        /// </summary>

        public int operationType { get; set; }
    }
}