using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class FallRoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FallRole>
    {
        public FallRoleConfiguration()
            : this("dbo")
        {
        }

        public FallRoleConfiguration(string schema)
        {
            ToTable("FallRoles", schema);
            HasKey(x => x.FallRoleID);

            Property(x => x.FallRoleID).HasColumnName(@"FallRoleID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FallRoleName).HasColumnName(@"FallRoleName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Up).HasColumnName(@"Up").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Down).HasColumnName(@"Down").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.UpDownType).HasColumnName(@"UpDownType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PartType).HasColumnName(@"PartType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CompensateNum).HasColumnName(@"CompensateNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CompensateType).HasColumnName(@"CompensateType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TopCompensateNum).HasColumnName(@"TopCompensateNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TopCompensateType).HasColumnName(@"TopCompensateType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("uniqueidentifier");
        }
    }
}
