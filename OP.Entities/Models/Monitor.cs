using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 监控配置
    /// </summary>
    public class Monitor
    {
        public Guid MonitorID { get; set; }
        public string MonitorName { get; set; } //监控名称
        public string Contract { get; set; }//合约名称
        public DateTime MonitorDate { get; set; }//监控日期
        public string Editor { get; set; }//编辑人
        public DateTime? EditTime { get; set; } //编辑时间
        public string Auditor { get; set; }//审核人
        public DateTime? AuditTime { get; set; } //审核时间
        public bool IsAudit { get; set; }//是否通过审核
        public bool IsActive { get; set; }//是否启用
        public Monitor() {
            MonitorID = Guid.NewGuid();
        }
    }
}
