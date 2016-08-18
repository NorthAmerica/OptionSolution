using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class OptionsProductConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OptionsProduct>
    {
        public OptionsProductConfiguration()
            : this("dbo")
        {
        }

        public OptionsProductConfiguration(string schema)
        {
            ToTable("OptionsProducts", schema);
            HasKey(x => x.OptionsProductID);

            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PartnerName).HasColumnName(@"PartnerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductName).HasColumnName(@"ProductName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductDescription).HasColumnName(@"ProductDescription").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductDesc).HasColumnName(@"ProductDesc").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductDtlDesc).HasColumnName(@"ProductDtlDesc").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ClosingPriceDesc).HasColumnName(@"ClosingPriceDesc").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Formula).HasColumnName(@"Formula").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductUrl).HasColumnName(@"ProductUrl").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Contract).HasColumnName(@"Contract").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ContractChs).HasColumnName(@"ContractChs").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OptionType).HasColumnName(@"OptionType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.EndType).HasColumnName(@"EndType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AddDate).HasColumnName(@"AddDate").IsOptional().HasColumnType("datetime");
            Property(x => x.BeginDate).HasColumnName(@"BeginDate").IsOptional().HasColumnType("datetime");
            Property(x => x.EndDate).HasColumnName(@"EndDate").IsOptional().HasColumnType("datetime");
            Property(x => x.Deadline).HasColumnName(@"Deadline").IsRequired().HasColumnType("int");
            Property(x => x.Unit).HasColumnName(@"Unit").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Charge).HasColumnName(@"Charge").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ChargeType).HasColumnName(@"ChargeType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Price).HasColumnName(@"Price").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.PriceType).HasColumnName(@"PriceType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AmountType).HasColumnName(@"AmountType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.MaxNum).HasColumnName(@"MaxNum").IsRequired().HasColumnType("int");
            Property(x => x.Status).HasColumnName(@"Status").IsRequired().HasColumnType("int");
            Property(x => x.IsUpLoad).HasColumnName(@"IsUpLoad").IsRequired().HasColumnType("bit");
            Property(x => x.CallPriceType).HasColumnName(@"CallPriceType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OrderID).HasColumnName(@"OrderID").IsOptional().HasColumnType("int");
        }
    }
}
