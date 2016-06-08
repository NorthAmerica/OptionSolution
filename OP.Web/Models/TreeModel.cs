using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    public class TreeModel
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 显示节点文本
        /// </summary>
        public string text { get; set; }
        public List<TreeModel> children { get; set; }
    }
}