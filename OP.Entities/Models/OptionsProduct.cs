using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 期权产品
    /// </summary>
    public class OptionsProduct
    {
        public System.Guid OptionsProductID { get; set; } // OptionsProductID (Primary key)
        public string PartnerName { get; set; } // 合作者名称
        public string ProductName { get; set; } // 产品名称
        public string ProductDescription { get; set; } // 产品特征
        public string ProductDesc { get; set; } // 产品描述（显示在提交订单中一段产品简单描述）
        public string ProductDtlDesc { get; set; } // 产品详细描述（显示在保单详情，分行）
        public string ClosingPriceDesc { get; set; } // 收盘价描述（显示在第三方收盘价行情走势图下面）
        public string Formula { get; set; } // （基准价-结算价）* 50% * 购买量,收益计算公式
        public string ProductUrl { get; set; } // 产品说明链接
        public string Contract { get; set; } // 合约名称
        public string ContractChs { get; set; } // 合约名称(中文)
        public string OptionType { get; set; } // 期权类型《看涨期权》《看跌期权》
        public string EndType { get; set; } // 结算日类型《欧式期权》《美式期权》
        public System.DateTime? AddDate { get; set; } // 新增日期
        public System.DateTime? BeginDate { get; set; } // 启动日期
        public System.DateTime? EndDate { get; set; } // 暂停日期
        public int Deadline { get; set; } // 产品期限(天)
        public string Unit { get; set; } // 产品单位
        public decimal Charge { get; set; } // 产品手续费
        public string ChargeType { get; set; } // 手续费类型 分为《固定值》《单位值》
        public decimal Price { get; set; } // 产品费用
        public string PriceType { get; set; } // 金额类型 分为《固定值》《单位值》
        public string AmountType { get; set; } // 产品费用类型 分为《保证金》《保费》
        public int MaxNum { get; set; } // 最大购买份数
        public int Status { get; set; } // 状态分为 0初始化 1启用 2停用
        public bool IsUpLoad { get; set; } // 是否上传
        public string CallPriceType { get; set; } // 结算价类型《结算日期货合约收盘价》《产品期限内所有交易日收盘价的均价》
        public int? OrderID { get; set; } // 排序号

        public OptionsProduct()
        {
            OptionsProductID = System.Guid.NewGuid();
        }
    }
}
