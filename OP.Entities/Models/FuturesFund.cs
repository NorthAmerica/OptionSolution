using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期货账户资金
    /// </summary>
    public class FuturesFund
    {
        public System.Guid FuturesFundID { get; set; } // FuturesFundID (Primary key)
        public string ZH { get; set; } // 账号
        public string KSRQ { get; set; } // 开始日期
        public string JSRQ { get; set; } // 结束日期
        public decimal QCQY { get; set; } // 期初权益
        public decimal QMQY { get; set; } // 期末权益
        public decimal KYZJ { get; set; } // 可用资金
        public decimal BZJ { get; set; } // 保证金
        public decimal JCSXF { get; set; } // 基础手续费
        public decimal FJSXF { get; set; } // 附加手续费
        public decimal ZSXF { get; set; } // 总手续费
        public decimal CCFDYK { get; set; } // 持仓浮动盈亏
        public decimal CCDSYK { get; set; } // 持仓盯市盈亏
        public decimal PCFDYK { get; set; } // 平仓浮动盈亏
        public decimal PCDSYK { get; set; } // 平仓盯市盈亏
        public decimal RJ { get; set; } // 入金
        public decimal CJ { get; set; } // 出金
        public decimal FXD { get; set; } // 风险度

        public FuturesFund()
        {
            FuturesFundID = System.Guid.NewGuid();
        }
    }
}
