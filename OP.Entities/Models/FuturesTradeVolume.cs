using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期货成交情况
    /// </summary>
    public class FuturesTradeVolume
    {
        public System.Guid FuturesTradeVolumeID { get; set; } // FuturesTradeVolumeID (Primary key)
        public string ZH { get; set; } // 账号
        public string JYR { get; set; } // 交易日
        public string WTH { get; set; } // 委托号
        public string CJH { get; set; } // 成交号
        public string QQH { get; set; } // 请求号
        public string JYS { get; set; } // 交易所
        public string HY { get; set; } // 合约
        public string MM { get; set; } // 买卖
        public string KP { get; set; } // 开平
        public string TB { get; set; } // 投保
        public decimal CJJ { get; set; } // 成交价
        public decimal CJL { get; set; } // 成交量
        public decimal CJJE { get; set; } // 成交金额
        public string SJRQ { get; set; } // 实际日期
        public string CJSJ { get; set; } // 成交时间
        public string ZZH { get; set; } // 主账号
        public string XTH { get; set; } // 系统号
        public decimal SXF { get; set; } // 手续费
        public decimal PCFDYK { get; set; } // 平仓浮动盈亏
        public decimal PCYK { get; set; } // 平仓盈亏
        public decimal JCSXF { get; set; } // 基础手续费

        public FuturesTradeVolume()
        {
            FuturesTradeVolumeID = System.Guid.NewGuid();
        }
    }
}
