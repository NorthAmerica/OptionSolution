using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class GoodsProfitConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GoodsProfit>
    {
        public GoodsProfitConfiguration()
            : this("dbo")
        {
        }

        public GoodsProfitConfiguration(string schema)
        {
            ToTable("GoodsProfits", schema);
            HasKey(x => x.GoodsProfitID);

            Property(x => x.GoodsProfitID).HasColumnName(@"GoodsProfitID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GoodsMarketingID).HasColumnName(@"GoodsMarketingID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.SigningTime).HasColumnName(@"SigningTime").IsOptional().HasColumnType("datetime");
            Property(x => x.PurchaseName).HasColumnName(@"PurchaseName").IsRequired().HasColumnType("nvarchar");
            Property(x => x.MarketingName).HasColumnName(@"MarketingName").IsRequired().HasColumnType("nvarchar");
            Property(x => x.ContractType).HasColumnName(@"ContractType").IsRequired().HasColumnType("nvarchar");
            Property(x => x.ContractObject).HasColumnName(@"ContractObject").IsRequired().HasColumnType("nvarchar");
            Property(x => x.PurchaseUnitPrice).HasColumnName(@"PurchaseUnitPrice").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.MarketingUnitPrice).HasColumnName(@"MarketingUnitPrice").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ContractNum).HasColumnName(@"ContractNum").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TotalPrice).HasColumnName(@"TotalPrice").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPickdingNum).HasColumnName(@"RealityPickdingNum").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPrice).HasColumnName(@"RealityPrice").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPayment).HasColumnName(@"RealityPayment").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Spread).HasColumnName(@"Spread").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Profit).HasColumnName(@"Profit").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ProfitPercentage).HasColumnName(@"ProfitPercentage").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ReflowTime).HasColumnName(@"ReflowTime").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Status).HasColumnName(@"Status").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Remark).HasColumnName(@"Remark").IsRequired().HasColumnType("nvarchar");
            Property(x => x.RecordTime).HasColumnName(@"RecordTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Noter).HasColumnName(@"Noter").IsOptional().HasColumnType("nvarchar");
        }
    }
}
