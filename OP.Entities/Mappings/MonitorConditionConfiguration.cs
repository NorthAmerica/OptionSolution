using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class MonitorConditionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MonitorCondition>
    {
        public MonitorConditionConfiguration()
            : this("dbo")
        {
        }
        public MonitorConditionConfiguration(string schema)
        {
            ToTable("MonitorConditions", schema);
            HasKey(x => x.MonitorConditionID);

            Property(x => x.MonitorConditionID).HasColumnName(@"MonitorConditionID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            Property(x => x.Contract).HasColumnName(@"Contract").IsOptional().HasColumnType("nvarchar");
            Property(x => x.MonitorDate).HasColumnName(@"MonitorDate").IsRequired().HasColumnType("datetime");
            Property(x => x.MainPosition).HasColumnName(@"MainPosition").IsOptional().HasColumnType("int");
            Property(x => x.MinPosition).HasColumnName(@"MinPosition").IsOptional().HasColumnType("int");
            Property(x => x.MaxPosition).HasColumnName(@"MaxPosition").IsOptional().HasColumnType("int");
            Property(x => x.MinPrice).HasColumnName(@"MinPrice").IsOptional().HasColumnType("int");
            Property(x => x.MaxPrice).HasColumnName(@"MaxPrice").IsOptional().HasColumnType("int");
        }
    }
}
