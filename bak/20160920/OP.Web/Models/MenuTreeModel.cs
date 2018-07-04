using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.Web.Models
{
    /// <summary>
    /// Menu树形MODEL
    /// </summary>
    public class MenuTreeModel
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public string MenuID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string MenuURL { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderNum { get; set; }
        public List<MenuTreeModel> children { get; set; }
    }
}