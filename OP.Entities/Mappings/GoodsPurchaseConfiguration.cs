using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class GoodsPurchaseConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GoodsPurchase>
    {
        public GoodsPurchaseConfiguration()
            : this("dbo")
        {
        }

        public GoodsPurchaseConfiguration(string schema)
        {
            ToTable("GoodsPurchases", schema);
            HasKey(x => x.GoodsPurchaseID);

            Property(x => x.GoodsPurchaseID).HasColumnName(@"GoodsPurchaseID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CustomerName).HasColumnName(@"CustomerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ContractNo).HasColumnName(@"ContractNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SigningTime).HasColumnName(@"SigningTime").IsRequired().HasColumnType("datetime");
            Property(x => x.ContractType).HasColumnName(@"ContractType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ContractObject).HasColumnName(@"ContractObject").IsOptional().HasColumnType("nvarchar");
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ContractNum).HasColumnName(@"ContractNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TotalPrice).HasColumnName(@"TotalPrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.DeliveryTime).HasColumnName(@"DeliveryTime").IsRequired().HasColumnType("datetime");
            Property(x => x.AlreadyPickingNum).HasColumnName(@"AlreadyPickingNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.AwaitPickdingNum).HasColumnName(@"AwaitPickdingNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPickdingNum).HasColumnName(@"RealityPickdingNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.RealityPrice).HasColumnName("@RealityPrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.LogisticsCost).HasColumnName(@"LogisticsCost").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TonCost).HasColumnName(@"TonCost").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.AllCost).HasColumnName(@"AllCost").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.InvoiceStatus).HasColumnName(@"InvoiceStatus").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PaymentAmount).HasColumnName(@"PaymentAmount").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.AwaitPayment).HasColumnName(@"AwaitPayment").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PaymentTime).HasColumnName(@"PaymentTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Remark).HasColumnName(@"Remark").IsOptional().HasColumnType("nvarchar");
            Property(x => x.RecordTime).HasColumnName(@"RecordTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Noter).HasColumnName(@"Noter").IsOptional().HasColumnType("nvarchar");
        }
    }
}
