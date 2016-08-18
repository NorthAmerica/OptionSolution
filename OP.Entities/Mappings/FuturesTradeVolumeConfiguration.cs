using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class FuturesTradeVolumeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FuturesTradeVolume>
    {
        public FuturesTradeVolumeConfiguration()
            : this("dbo")
        {
        }

        public FuturesTradeVolumeConfiguration(string schema)
        {
            ToTable("FuturesTradeVolumes", schema);
            HasKey(x => x.FuturesTradeVolumeID);

            Property(x => x.FuturesTradeVolumeID).HasColumnName(@"FuturesTradeVolumeID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ZH).HasColumnName(@"ZH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.JYR).HasColumnName(@"JYR").IsOptional().HasColumnType("nvarchar");
            Property(x => x.WTH).HasColumnName(@"WTH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CJH).HasColumnName(@"CJH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.QQH).HasColumnName(@"QQH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.JYS).HasColumnName(@"JYS").IsOptional().HasColumnType("nvarchar");
            Property(x => x.HY).HasColumnName(@"HY").IsOptional().HasColumnType("nvarchar");
            Property(x => x.MM).HasColumnName(@"MM").IsOptional().HasColumnType("nvarchar");
            Property(x => x.KP).HasColumnName(@"KP").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TB).HasColumnName(@"TB").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CJJ).HasColumnName(@"CJJ").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CJL).HasColumnName(@"CJL").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CJJE).HasColumnName(@"CJJE").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.SJRQ).HasColumnName(@"SJRQ").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CJSJ).HasColumnName(@"CJSJ").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ZZH).HasColumnName(@"ZZH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.XTH).HasColumnName(@"XTH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SXF).HasColumnName(@"SXF").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PCFDYK).HasColumnName(@"PCFDYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PCYK).HasColumnName(@"PCYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.JCSXF).HasColumnName(@"JCSXF").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
        }
    }
}
