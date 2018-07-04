using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class MonitorConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Monitor>
    {
        public MonitorConfiguration()
            : this("dbo")
        {
        }
        public MonitorConfiguration(string schema)
        {
            ToTable("MonitorConditions", schema);
            HasKey(x => x.MonitorID);

            Property(x => x.MonitorID).HasColumnName(@"MonitorID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.MonitorName).HasColumnName(@"MonitorName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Contract).HasColumnName(@"Contract").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Account).HasColumnName(@"Account").IsOptional().HasColumnType("nvarchar");
            Property(x => x.MonitorDate).HasColumnName(@"MonitorDate").IsRequired().HasColumnType("datetime");
            Property(x => x.Editor).HasColumnName(@"Editor").IsOptional().HasColumnType("nvarchar");
            Property(x => x.EditTime).HasColumnName(@"EditTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Auditor).HasColumnName(@"Auditor").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AuditTime).HasColumnName(@"AuditTime").IsOptional().HasColumnType("datetime");
            Property(x => x.IsAudit).HasColumnName(@"IsAudit").IsRequired().HasColumnType("bit");
            Property(x => x.IsActive).HasColumnName(@"IsActive").IsRequired().HasColumnType("bit");
        }
    }
}
