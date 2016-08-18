using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 上涨规则
    /// </summary>
    public class RiseRole
    {
        public System.Guid RiseRoleID { get; set; } // RiseRoleID (Primary key)
        public string RiseRoleName { get; set; } // 上涨规则名称
        public string CreateDate { get; set; } // 创建时间
        public decimal Up { get; set; } // 上区间
        public decimal Down { get; set; } // 下区间
        public string UpDownType { get; set; } // 区间类型 分为《固定值》
        public string PartType { get; set; } // 部分类型 分为《按上涨下跌部分》《按超过上涨下跌部分》
        public decimal DividendNum { get; set; } // 分红数
        public string DividendType { get; set; } // 分红类型 分为《百分比》
        public decimal TopDividendNum { get; set; } // 最高分红数
        public string TopDividendType { get; set; } // 最高赔付类型 分为《固定值》
        public System.Guid OptionsProductID { get; set; } // OptionsProductID

        public RiseRole()
        {
            RiseRoleID = System.Guid.NewGuid();
        }
    }
}
