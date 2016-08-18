using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class EventLogConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EventLog>
    {
        public EventLogConfiguration()
            : this("dbo")
        {
        }

        public EventLogConfiguration(string schema)
        {
            ToTable("EventLogs", schema);
            HasKey(x => x.EventLogID);

            Property(x => x.EventLogID).HasColumnName(@"EventLogID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Date).HasColumnName(@"Date").IsRequired().HasColumnType("datetime");
            Property(x => x.Event).HasColumnName(@"Event").IsOptional().HasColumnType("nvarchar");
        }
    }
}
