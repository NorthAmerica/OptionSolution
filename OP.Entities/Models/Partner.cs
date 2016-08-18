using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 合作者
    /// </summary>
    public class Partner
    {
        public int PartnerID { get; set; } // PartnerID (Primary key)
        public string PartnerName { get; set; } // 合作者名称
        public string PartnerDescribe { get; set; } // 合作者描述
    }
}
