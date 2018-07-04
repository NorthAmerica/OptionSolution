using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    /// <summary>
    /// 远程访问调用返回信息
    /// </summary>
    public class ReturnModel
    {
        /// <summary>
        /// 1:成功 0:失败
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
    }
}