using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 下跌规则
    /// </summary>
    public class FallRole
    {
        public System.Guid FallRoleID { get; set; } // FallRoleID (Primary key)
        public string FallRoleName { get; set; } // 下跌规则名称
        public string CreateDate { get; set; } // 创建时间
        public decimal Up { get; set; } // 上区间
        public decimal Down { get; set; } // 下区间
        public string UpDownType { get; set; } // 区间类型 分为《固定值》
        public string PartType { get; set; } // 部分类型 分为《按下跌部分》《按超过下跌部分》
        public decimal CompensateNum { get; set; } // 赔付数
        public string CompensateType { get; set; } // 赔付类型 分为《百分比》
        public decimal TopCompensateNum { get; set; } // 最高赔付数
        public string TopCompensateType { get; set; } // 最高赔付类型 分为《固定值》
        public System.Guid OptionsProductID { get; set; } // 期权产品ID

        public FallRole()
        {
            FallRoleID = System.Guid.NewGuid();
        }
    }
}
