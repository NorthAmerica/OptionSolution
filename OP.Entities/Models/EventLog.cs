using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 事件日志
    /// </summary>
    public class EventLog
    {
        public System.Guid EventLogID { get; set; } // EventLogID (Primary key)
        public string Name { get; set; } // 操作人
        public System.DateTime Date { get; set; } // 操作时间
        public string Event { get; set; } // 操作事件

        public EventLog()
        {
            EventLogID = System.Guid.NewGuid();
        }
    }
}
