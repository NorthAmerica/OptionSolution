using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 下跌规则
    /// </summary>
    public class FallRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid FallRoleID { get; set; }
        [DisplayName("下跌规则名称")]
        public string FallRoleName { get; set; }
        [DisplayName("创建时间")]
        public string CreateDate { get; set; }
        [DisplayName("上区间")]
        public decimal Up { get; set; }
        [DisplayName("下区间")]
        public decimal Down { get; set; }
        /// <summary>
        /// 区间类型 分为《固定值》
        /// </summary>
        [DisplayName("区间类型")]
        public string UpDownType { get; set; }
        /// <summary>
        /// 部分类型 分为《按下跌部分》《按超过下跌部分》
        /// </summary>
        [DisplayName("部分类型")]
        public string PartType { get; set; }
        [DisplayName("赔付数")]
        public decimal CompensateNum { get; set; }
        /// <summary>
        /// 赔付类型 分为《百分比》
        /// </summary>
        [DisplayName("赔付类型")]
        public string CompensateType { get; set; }
        [DisplayName("最高赔付数")]
        public decimal TopCompensateNum { get; set; }
        /// <summary>
        /// 最高赔付类型 分为《固定值》
        /// </summary>
        [DisplayName("最高赔付类型")]
        public string TopCompensateType { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid OptionsProductID { get; set; }

    }
}
