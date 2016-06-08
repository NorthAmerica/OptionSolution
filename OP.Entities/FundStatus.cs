using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 资金状态
    /// 0:资金未接收 1：资金已接收 2：资金已核对 3：资金已结算 4：资金已发送
    /// </summary>
    public class FundStatus
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int FundStatusID { get; set; }
        [DisplayName("资金状态名称")]
        public string FundStatusName { get; set; }
        [DisplayName("资金状态标志")]
        public int FundStatusNum { get; set; }
    }
}
