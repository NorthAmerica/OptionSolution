using System;

namespace OP.Entities.Models
{
    /// <summary>
    /// 现货采购合同
    /// </summary>
    public class GoodsPurchase
    {
        public Guid GoodsPurchaseID { get; set; }
        public string CustomerName { get; set; } //客户名称
        public string ContractNo { get; set; } //合同号
        public DateTime SigningTime { get; set; } //签订时间
        public string ContractType { get; set; } //合同类型
        public string ContractObject { get; set; } //合同标的
        public decimal UnitPrice { get; set; } //合同单价
        public decimal ContractNum { get; set; } //合同数量
        public decimal TotalPrice { get; set; } //合同总金额 = 合同数量*合同单价
        public DateTime DeliveryTime { get; set; } //交货时间
        public decimal AlreadyPickingNum { get; set; } //已提货数量
        public decimal AwaitPickdingNum { get; set; } //待提货数量=合同数量-已提货数量
        public decimal RealityPickdingNum { get; set; } //实际提货数量
        public decimal LogisticsCost { get; set; } //物流成本
        public decimal TonCost { get; set; } //每顿成本=合同单价+物流成本
        public decimal AllCost { get; set; } //总成本=每顿成本*总合同数量
        public string InvoiceStatus { get; set; } //发票状态
        public decimal PaymentAmount { get; set; } //付款金额
        public DateTime PaymentTime { get; set; } //付款时间
        public string Remark { get; set; } //备注
        public DateTime RecordTime { get; set; } //记录时间
        public string Noter { get; set; } //记录人

        public GoodsPurchase()
        {
            GoodsPurchaseID = Guid.NewGuid();
        }
    }
}
