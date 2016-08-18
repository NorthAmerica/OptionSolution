using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 处理状态
    /// 0:数据已接收但未处理  2：基准价结算日已同步,等待结算
    /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
    /// </summary>
    public class ManageStatus
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ManageStatusID { get; set; }
        [DisplayName("处理状态名称")]
        public string ManageStatusName { get; set; }
        [DisplayName("处理状态标志")]
        public int ManageStatusNum { get; set; }
    }
}
