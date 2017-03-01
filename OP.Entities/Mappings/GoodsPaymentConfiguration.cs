using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class GoodsPaymentConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GoodsPayment>
    {
        public GoodsPaymentConfiguration()
            : this("dbo")
        {
        }

        public GoodsPaymentConfiguration(string schema)
        {
            ToTable("GoodsPayments", schema);
            HasKey(x => x.GoodsPaymentID);

            Property(x => x.GoodsPaymentID).HasColumnName(@"GoodsPaymentID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PaymentDate).HasColumnName(@"PaymentDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ContractNo).HasColumnName(@"ContractNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CustomerName).HasColumnName(@"CustomerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Get).HasColumnName(@"Get").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Pay).HasColumnName(@"Pay").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Remark).HasColumnName(@"Remark").IsOptional().HasColumnType("nvarchar");
            Property(x => x.RecordTime).HasColumnName(@"RecordTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Noter).HasColumnName(@"Noter").IsOptional().HasColumnType("nvarchar");
        }
    }
}
