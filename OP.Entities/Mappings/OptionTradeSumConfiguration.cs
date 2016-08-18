using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class OptionTradeSumConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OptionTradeSum>
    {
        public OptionTradeSumConfiguration()
            : this("dbo")
        {
        }

        public OptionTradeSumConfiguration(string schema)
        {
            ToTable("OptionTradeSums", schema);
            HasKey(x => x.OptionTradeSumID);

            Property(x => x.OptionTradeSumID).HasColumnName(@"OptionTradeSumID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsRequired().HasColumnType("int");
            Property(x => x.ProductName).HasColumnName(@"ProductName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TradeNumSum).HasColumnName(@"TradeNumSum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.TradeAmountSum).HasColumnName(@"TradeAmountSum").IsRequired().HasColumnType("decimal").HasPrecision(18, 2);
            Property(x => x.BeginDate).HasColumnName(@"BeginDate").IsOptional().HasColumnType("nvarchar");
            Property(x => x.EndDate).HasColumnName(@"EndDate").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ManageStatus).HasColumnName(@"ManageStatus").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FundStatus).HasColumnName(@"FundStatus").IsOptional().HasColumnType("nvarchar");
        }
    }
}
