using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class FuturePriceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FuturePrice>
    {
        public FuturePriceConfiguration()
            : this("dbo")
        {
        }

        public FuturePriceConfiguration(string schema)
        {
            ToTable("FuturePrices", schema);
            HasKey(x => x.FuturePriceID);

            Property(x => x.FuturePriceID).HasColumnName(@"FuturePriceID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Price).HasColumnName(@"Price").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Type).HasColumnName(@"Type").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TradeCode).HasColumnName(@"TradeCode").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Date).HasColumnName(@"Date").IsRequired().HasColumnType("datetime");
        }
    }
}
