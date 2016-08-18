using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class FuturesFundConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FuturesFund>
    {
        public FuturesFundConfiguration()
            : this("dbo")
        {
        }

        public FuturesFundConfiguration(string schema)
        {
            ToTable("FuturesFunds", schema);
            HasKey(x => x.FuturesFundID);

            Property(x => x.FuturesFundID).HasColumnName(@"FuturesFundID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ZH).HasColumnName(@"ZH").IsOptional().HasColumnType("nvarchar");
            Property(x => x.KSRQ).HasColumnName(@"KSRQ").IsOptional().HasColumnType("nvarchar");
            Property(x => x.JSRQ).HasColumnName(@"JSRQ").IsOptional().HasColumnType("nvarchar");
            Property(x => x.QCQY).HasColumnName(@"QCQY").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.QMQY).HasColumnName(@"QMQY").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.KYZJ).HasColumnName(@"KYZJ").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.BZJ).HasColumnName(@"BZJ").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.JCSXF).HasColumnName(@"JCSXF").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.FJSXF).HasColumnName(@"FJSXF").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ZSXF).HasColumnName(@"ZSXF").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CCFDYK).HasColumnName(@"CCFDYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CCDSYK).HasColumnName(@"CCDSYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PCFDYK).HasColumnName(@"PCFDYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PCDSYK).HasColumnName(@"PCDSYK").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RJ).HasColumnName(@"RJ").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.CJ).HasColumnName(@"CJ").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.FXD).HasColumnName(@"FXD").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
        }
    }
}
