using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.WebAPI.Models
{
    public class ReturnDateModel
    {
        /// <summary>
        /// 1:成功 0:失败
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        public List<Dates> datas { get; set; }
    }
    public class Dates
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}