using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 资金状态
    /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
    /// </summary>
    public class FundStatus
    {
        public int FundStatusID { get; set; } // FundStatusID (Primary key)
        public string FundStatusName { get; set; } // 资金状态名称
        public int FundStatusNum { get; set; } // 资金状态标志
    }
}
