using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Models
{
    /// <summary>
    /// 资金收支情况表
    /// </summary>
    public class GoodsPayment
    {
        public System.Guid GoodsPaymentID { get; set; } // GoodsPaymentID (Primary key)

        ///<summary>
        /// 时间
        ///</summary>
        public System.DateTime? PaymentDate { get; set; } // PaymentDate

        ///<summary>
        /// 对应合同号
        ///</summary>
        public string ContractNo { get; set; } // ContractNo

        ///<summary>
        /// 客户名称
        ///</summary>
        public string CustomerName { get; set; } // CustomerName

        ///<summary>
        /// 收取金额
        ///</summary>
        public decimal? Get { get; set; } // Get

        ///<summary>
        /// 支付金额
        ///</summary>
        public decimal? Pay { get; set; } // Pay

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

        public GoodsPayment()
        {
            GoodsPaymentID = System.Guid.NewGuid();
        }
    }
}
