using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 处理状态
    /// 0:数据已接收但未处理  2：基准价结算日已同步,等待结算
    /// 3：结算价接收完成 4：结算已完成 5：数据发送完成 
    /// </summary>
    public class ManageStatus
    {
        public int ManageStatusID { get; set; } // ManageStatusID (Primary key)
        public string ManageStatusName { get; set; } // 处理状态名称
        public int ManageStatusNum { get; set; } // 处理状态标志
    }
}
