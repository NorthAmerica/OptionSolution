using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class GoodsMarketingConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GoodsMarketing>
    {
        public GoodsMarketingConfiguration()
            : this("dbo")
        {
        }

        public GoodsMarketingConfiguration(string schema)
        {
            ToTable("GoodsMarketings", schema);
            HasKey(x => x.GoodsMarketingID);

            Property(x => x.GoodsMarketingID).HasColumnName(@"GoodsMarketingID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GoodsPurchaseID).HasColumnName(@"GoodsPurchaseID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.CustomerName).HasColumnName(@"CustomerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ContractNo).HasColumnName(@"ContractNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SigningTime).HasColumnName(@"SigningTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ContractObject).HasColumnName(@"ContractObject").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PickingType).HasColumnName(@"PickingType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ContractNum).HasColumnName(@"ContractNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TotalPrice).HasColumnName(@"TotalPrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.DeliveryTime).HasColumnName(@"DeliveryTime").IsRequired().HasColumnType("datetime");
            Property(x => x.AlreadyDeliveryNum).HasColumnName(@"AlreadyDeliveryNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.AwaitDeliveryNum).HasColumnName(@"AwaitDeliveryNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityDeliveryNum).HasColumnName(@"RealityDeliveryNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.LogisticsCost).HasColumnName(@"LogisticsCost").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.InvoiceStatus).HasColumnName(@"InvoiceStatus").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AlreadyPayment).HasColumnName(@"AlreadyPayment").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.AwaitPayment).HasColumnName(@"AwaitPayment").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPayment).HasColumnName(@"RealityPayment").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Remark).HasColumnName(@"Remark").IsOptional().HasColumnType("nvarchar");
            Property(x => x.RecordTime).HasColumnName(@"RecordTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Noter).HasColumnName(@"Noter").IsOptional().HasColumnType("nvarchar");
        }
    }
}
