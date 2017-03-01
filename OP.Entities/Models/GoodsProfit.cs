using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 利润核算表
    /// </summary>
    public class GoodsProfit
    {
        public System.Guid GoodsProfitID { get; set; } // GoodsProfitID (Primary key)

        ///<summary>
        /// 现货销售合同ID
        ///</summary>
        public System.Guid? GoodsMarketingID { get; set; } // GoodsPurchaseID

        ///<summary>
        /// 签订时间（销售合同）
        ///</summary>
        public System.DateTime? SigningTime { get; set; } // SigningTime

        ///<summary>
        /// 采购方（采购表客户名称）
        ///</summary>
        public string PurchaseName { get; set; } // PurchaseName

        ///<summary>
        /// 销售方（销售表客户名称）
        ///</summary>
        public string MarketingName { get; set; } // MarketingName

        ///<summary>
        /// 合同类型（采购表）
        ///</summary>
        public string ContractType { get; set; } // ContractType

        ///<summary>
        /// 合同标的（采购表）
        ///</summary>
        public string ContractObject { get; set; } // ContractObject

        ///<summary>
        /// 采购价（采购表合同单价）
        ///</summary>
        public decimal? PurchaseUnitPrice { get; set; } // PurchaseUnitPrice

        ///<summary>
        /// 销售价（销售表合同单价）
        ///</summary>
        public decimal? MarketingUnitPrice { get; set; } // MarketingUnitPrice

        ///<summary>
        /// 合同数量（销售表合同数量）
        ///</summary>
        public decimal? ContractNum { get; set; } // ContractNum

        ///<summary>
        /// 合同总金额（采购价*合同数量）
        ///</summary>
        public decimal? TotalPrice { get; set; } // TotalPrice

        ///<summary>
        /// 实际提货数量（手工填写）
        ///</summary>
        public decimal? RealityPickdingNum { get; set; } // RealityPickdingNum

        ///<summary>
        /// 实际采购成本（采购价*实际提货数量）
        ///</summary>
        public decimal? RealityPrice { get; set; } // RealityPrice

        ///<summary>
        /// 实际销售收入（销售价*实际提货数量）
        ///</summary>
        public decimal? RealityPayment { get; set; } // RealityPayment

        ///<summary>
        /// 采销价差（销售价-采购价）
        ///</summary>
        public decimal? Spread { get; set; } // Spread

        ///<summary>
        /// 利润（实际提货数量*采销价差）
        ///</summary>
        public decimal? Profit { get; set; } // Profit

        ///<summary>
        /// 单笔利润率（利润/实际采购成本）*100%
        ///</summary>
        public decimal? ProfitPercentage { get; set; } // ProfitPercentage

        ///<summary>
        /// 资金回笼时间
        ///</summary>
        public decimal? ReflowTime { get; set; } // ReflowTime

        ///<summary>
        /// 状态(已完结/未完结)
        ///</summary>
        public string Status { get; set; } // Status (length: 50)

        ///<summary>
        /// 备注
        ///</summary>
        public string Remark { get; set; } // Remark

        ///<summary>
        /// 记录时间
        ///</summary>
        public System.DateTime? RecordTime { get; set; } // RecordTime

        ///<summary>
        /// 记录人
        ///</summary>
        public string Noter { get; set; } // Noter

        public GoodsProfit()
        {
            GoodsProfitID = System.Guid.NewGuid();
        }
    }
}
