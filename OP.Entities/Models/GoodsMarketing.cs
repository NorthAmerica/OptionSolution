using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 现货销售合同
    /// </summary>
    public class GoodsMarketing
    {
        public Guid GoodsMarketingID { get; set; } // GoodsMarketingID (Primary key)
        public Guid GoodsPurchaseID { get; set; } // GoodsPurchaseID
        public string CustomerName { get; set; } // 客户名
        public string ContractNo { get; set; } // 合同号
        public DateTime SigningTime { get; set; } // 签订时间
        public string ContractObject { get; set; } // 合同标的

        ///<summary>
        /// 提货方式
        ///</summary>
        public string PickingType { get; set; } // PickingType

        ///<summary>
        /// 合同单价
        ///</summary>
        public decimal UnitPrice { get; set; } // UnitPrice

        ///<summary>
        /// 合同数量
        ///</summary>
        public decimal ContractNum { get; set; } // ContractNum

        ///<summary>
        /// 合同总金额=合同单价+合同数量
        ///</summary>
        public decimal TotalPrice { get; set; } // TotalPrice
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime DeliveryTime { get; set; } // DeliveryTime

        ///<summary>
        /// 已交货数量
        ///</summary>
        public decimal AlreadyDeliveryNum { get; set; } // AlreadyDeliveryNum

        ///<summary>
        /// 待交货数量=合同数量-已交货数量
        ///</summary>
        public decimal AwaitDeliveryNum { get; set; } // AwaitDeliveryNum

        ///<summary>
        /// 实际发货量
        ///</summary>
        public decimal RealityDeliveryNum { get; set; } // RealityDeliveryNum

        ///<summary>
        /// 物流成本
        ///</summary>
        public decimal LogisticsCost { get; set; } // LogisticsCost

        ///<summary>
        /// 销项发票
        ///</summary>
        public string InvoiceStatus { get; set; } // InvoiceStatus

        ///<summary>
        /// 已收货款
        ///</summary>
        public decimal AlreadyPayment { get; set; } // AlreadyPayment

        ///<summary>
        /// 待收货款=应收货款-已收货款
        ///</summary>
        public decimal AwaitPayment { get; set; } // AwaitPayment

        ///<summary>
        /// 应收货款=实际发货量*合同单价
        ///</summary>
        public decimal RealityPayment { get; set; } // RealityPayment
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } // Remark

        ///<summary>
        /// 记录时间
        ///</summary>
        public DateTime RecordTime { get; set; } // RecordTime

        ///<summary>
        /// 记录人
        ///</summary>
        public string Noter { get; set; } // Noter

        public GoodsMarketing()
        {
            GoodsMarketingID = System.Guid.NewGuid();
        }
    }
}
