using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OP.Entities
{
    public class EventLog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid EventLogID { get; set; }
        [DisplayName("操作人")]
        public string Name { get; set; }
        [DisplayName("操作时间")]
        public DateTime Date { get; set; }
        [DisplayName("操作事件")]
        public string Event { get; set; }
    }
}
