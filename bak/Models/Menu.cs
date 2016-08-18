using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OP.Entities
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int MenuID { get; set; }
        [Required(ErrorMessage = "请输入菜单名")]
        [StringLength(50, ErrorMessage = "菜单名长度不能超过50")]
        [DisplayName("菜单名")]
        public string MenuName { get; set; }
        [DisplayName("菜单链接")]
        public string MenuURL { get; set; }
        [DisplayName("排序号")]
        public int OrderNum { get; set; }
        [DisplayName("父节点")]
        public int FMenuID { get; set; }
    }
}
