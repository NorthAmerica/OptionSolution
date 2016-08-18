using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class TradeOrderConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TradeOrder>
    {
        public TradeOrderConfiguration()
            : this("dbo")
        {
        }

        public TradeOrderConfiguration(string schema)
        {
            ToTable("TradeOrders", schema);
            HasKey(x => x.TradeOrderID);

            Property(x => x.TradeOrderID).HasColumnName(@"TradeOrderID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.PartnerName).HasColumnName(@"PartnerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BusinessNo).HasColumnName(@"BusinessNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BusinessInfo).HasColumnName(@"BusinessInfo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PayTime).HasColumnName(@"PayTime").IsRequired().HasColumnType("datetime");
            Property(x => x.TradeNum).HasColumnName(@"TradeNum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.Charge).HasColumnName(@"Charge").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradePrice).HasColumnName(@"TradePrice").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.IsWindInsert).HasColumnName(@"IsWindInsert").IsRequired().HasColumnType("bit");
            Property(x => x.IsReturnOK).HasColumnName(@"IsReturnOK").IsRequired().HasColumnType("bit");
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").IsOptional().HasColumnType("datetime");
        }
    }
}
