using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 上涨规则
    /// </summary>
    public class RiseRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid RiseRoleID { get; set; }
        [DisplayName("上涨规则名称")]
        public string RiseRoleName { get; set; }
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
        /// 部分类型 分为《按上涨下跌部分》《按超过上涨下跌部分》
        /// </summary>
        [DisplayName("部分类型")]
        public string PartType { get; set; }
        [DisplayName("分红数")]
        public decimal DividendNum { get; set; }
        /// <summary>
        /// 分红类型 分为《百分比》
        /// </summary>
        [DisplayName("分红类型")]
        public string DividendType { get; set; }
        [DisplayName("最高分红数")]
        public decimal TopDividendNum { get; set; }
        /// <summary>
        /// 最高赔付类型 分为《固定值》
        /// </summary>
        [DisplayName("最高分红类型")]
        public string TopDividendType { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid OptionsProductID { get; set; }
    }
}
