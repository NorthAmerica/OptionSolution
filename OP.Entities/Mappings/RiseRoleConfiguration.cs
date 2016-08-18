using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class RiseRoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RiseRole>
    {
        public RiseRoleConfiguration()
            : this("dbo")
        {
        }

        public RiseRoleConfiguration(string schema)
        {
            ToTable("RiseRoles", schema);
            HasKey(x => x.RiseRoleID);

            Property(x => x.RiseRoleID).HasColumnName(@"RiseRoleID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RiseRoleName).HasColumnName(@"RiseRoleName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Up).HasColumnName(@"Up").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Down).HasColumnName(@"Down").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.UpDownType).HasColumnName(@"UpDownType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PartType).HasColumnName(@"PartType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.DividendNum).HasColumnName(@"DividendNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.DividendType).HasColumnName(@"DividendType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TopDividendNum).HasColumnName(@"TopDividendNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TopDividendType).HasColumnName(@"TopDividendType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("uniqueidentifier");
        }
    }
}
