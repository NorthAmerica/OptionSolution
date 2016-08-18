using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 宣传册数据
    /// </summary>
    public class Brochure
    {
        public System.Guid BrochureID { get; set; } // BrochureID (Primary key)
        public System.Guid? OptionsProductID { get; set; } // 期权产品ID
        public bool IsTemp { get; set; } // 是否为模板
        public string TempName { get; set; } // 模板名称
        public string TempDescrip { get; set; } // 模板描述
        public System.DateTime TempDate { get; set; } // 新增修改模板时间
        public System.DateTime? AddDate { get; set; } // 新增宣传册时间
        public string ContractDescrip { get; set; } // 标的合约
        public string BuyBegin { get; set; } // 购买起点
        public string BuyTime { get; set; } // 购买时间
        public string PayDescrip { get; set; } // 补偿说明
        public string SettlementFormula { get; set; } // 结算公式
        public byte[] SFPic { get; set; } // 结算公式图(盈亏结构图)
        public string StartDateDescrip { get; set; } // 生效日
        public string EndDateDescrip { get; set; } // 到期日
        public string TradeDateDescrip { get; set; } // 交易日
        public byte[] ExamplePic { get; set; } // 示例图
        public string RiskAnnouncementURL { get; set; } // 风险揭示书链接
        public string PurchaseAgreementURL { get; set; } // 价格补偿服务购买协议
        public string FAQ { get; set; } // 常见问题
        public string ExampleDescrip { get; set; } // 示例说明

        public Brochure()
        {
            BrochureID = System.Guid.NewGuid();
        }
    }
}
