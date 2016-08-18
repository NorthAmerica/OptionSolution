using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class OptionTradeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OptionTrade>
    {
        public OptionTradeConfiguration()
            : this("dbo")
        {
        }

        public OptionTradeConfiguration(string schema)
        {
            ToTable("OptionTrades", schema);
            HasKey(x => x.OptionTradeID);

            Property(x => x.OptionTradeID).HasColumnName(@"OptionTradeID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.BusinessNo).HasColumnName(@"BusinessNo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BusinessInfo).HasColumnName(@"BusinessInfo").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PartnerName).HasColumnName(@"PartnerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ProductName).HasColumnName(@"ProductName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OptionType).HasColumnName(@"OptionType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.CallPriceType).HasColumnName(@"CallPriceType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Deadline).HasColumnName(@"Deadline").IsOptional().HasColumnType("int");
            Property(x => x.TradeNum).HasColumnName(@"TradeNum").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradeCharge).HasColumnName(@"TradeCharge").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradePrice).HasColumnName(@"TradePrice").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradeMargin).HasColumnName(@"TradeMargin").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradeDate).HasColumnName(@"TradeDate").IsOptional().HasColumnType("datetime");
            Property(x => x.BeginDate).HasColumnName(@"BeginDate").IsOptional().HasColumnType("datetime");
            Property(x => x.Contract).HasColumnName(@"Contract").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BeginClose).HasColumnName(@"BeginClose").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.EndClose).HasColumnName(@"EndClose").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.EndDate).HasColumnName(@"EndDate").IsOptional().HasColumnType("datetime");
            Property(x => x.RiseCompensate).HasColumnName(@"RiseCompensate").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.FallCompensate).HasColumnName(@"FallCompensate").IsOptional().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.ManageStatus).HasColumnName(@"ManageStatus").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FundStatus).HasColumnName(@"FundStatus").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SendStatus).HasColumnName(@"SendStatus").IsOptional().HasColumnType("int");
        }
    }
}
