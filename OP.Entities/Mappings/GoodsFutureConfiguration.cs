using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class GoodsFutureConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GoodsFuture>
    {
        public GoodsFutureConfiguration()
            : this("dbo")
        {
        }

        public GoodsFutureConfiguration(string schema)
        {
            ToTable("GoodsFutures", schema);
            HasKey(x => x.GoodsFuturesID);

            Property(x => x.GoodsFuturesID).HasColumnName(@"GoodsFuturesID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GoodsPurchaseID).HasColumnName(@"GoodsPurchaseID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.Contract).HasColumnName(@"Contract").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FundAccount).HasColumnName(@"FundAccount").IsRequired().HasColumnType("nvarchar");
            Property(x => x.Positions).HasColumnName(@"Positions").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ContractNo).HasColumnName(@"ContractNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BuyOpen).HasColumnName(@"BuyOpen").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.SellClose).HasColumnName(@"SellClose").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.SellOpen).HasColumnName(@"SellOpen").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.BuyClose).HasColumnName(@"BuyClose").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PointCount).HasColumnName(@"PointCount").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Amount).HasColumnName(@"Amount").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RecordTime).HasColumnName(@"RecordTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Noter).HasColumnName(@"Noter").IsOptional().HasColumnType("nvarchar");
        }
    }
}
