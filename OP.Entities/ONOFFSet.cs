using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 产品全局开关设置
    /// </summary>
    public class ONOFFSet
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ONOFFSetID { get; set; }
        /// <summary>
        /// 0：手动设置 1：时间自动设置
        /// </summary>
        [DisplayName("开关模式")]
        public int ONOFFMode { get; set; }

        [DisplayName("手动开关设置")]
        public bool HandSwitch { get; set; }
    }
}
