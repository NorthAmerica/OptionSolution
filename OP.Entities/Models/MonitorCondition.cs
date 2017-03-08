using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 监控条件配置
    /// </summary>
    public class MonitorCondition
    {
        public Guid MonitorConditionID { get; set; } // MonitorConditionID (Primary key)
        public Guid MonitorID { get; set; } //MonitorID外键
        public string Contract { get; set; }//合约名称
        public DateTime MonitorDate { get; set; }//监控日期
        public int MainPosition { get; set; } //持仓
        public int MinPosition { get; set; } //最小持仓
        public int MaxPosition { get; set; } //最大持仓
        public int MinPrice { get; set; } //最小价格
        public int MaxPrice { get; set; } //最大价格
        
        public MonitorCondition()
        {
            MonitorConditionID = System.Guid.NewGuid();
        }
    }
}
