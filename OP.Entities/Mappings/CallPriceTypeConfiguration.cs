using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class CallPriceTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CallPriceType>
    {
        public CallPriceTypeConfiguration()
            : this("dbo")
        {
        }

        public CallPriceTypeConfiguration(string schema)
        {
            ToTable("CallPriceTypes", schema);
            HasKey(x => x.CallPriceTypeID);

            Property(x => x.CallPriceTypeID).HasColumnName(@"CallPriceTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CallPriceTypeName).HasColumnName(@"CallPriceTypeName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CallPriceTypeDescribe).HasColumnName(@"CallPriceTypeDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
