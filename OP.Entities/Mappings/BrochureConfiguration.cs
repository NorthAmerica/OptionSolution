using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class BrochureConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Brochure>
    {
        public BrochureConfiguration()
            : this("dbo")
        {
        }

        public BrochureConfiguration(string schema)
        {
            ToTable("Brochures", schema);
            HasKey(x => x.BrochureID);

            Property(x => x.BrochureID).HasColumnName(@"BrochureID").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OptionsProductID).HasColumnName(@"OptionsProductID").IsOptional().HasColumnType("uniqueidentifier");
            Property(x => x.IsTemp).HasColumnName(@"IsTemp").IsRequired().HasColumnType("bit");
            Property(x => x.TempName).HasColumnName(@"TempName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TempDescrip).HasColumnName(@"TempDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TempDate).HasColumnName(@"TempDate").IsRequired().HasColumnType("datetime");
            Property(x => x.AddDate).HasColumnName(@"AddDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ContractDescrip).HasColumnName(@"ContractDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BuyBegin).HasColumnName(@"BuyBegin").IsOptional().HasColumnType("nvarchar");
            Property(x => x.BuyTime).HasColumnName(@"BuyTime").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PayDescrip).HasColumnName(@"PayDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SettlementFormula).HasColumnName(@"SettlementFormula").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SFPic).HasColumnName(@"SFPic").IsOptional().HasColumnType("varbinary");
            Property(x => x.StartDateDescrip).HasColumnName(@"StartDateDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.EndDateDescrip).HasColumnName(@"EndDateDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.TradeDateDescrip).HasColumnName(@"TradeDateDescrip").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ExamplePic).HasColumnName(@"ExamplePic").IsOptional().HasColumnType("varbinary");
            Property(x => x.RiskAnnouncementURL).HasColumnName(@"RiskAnnouncementURL").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PurchaseAgreementURL).HasColumnName(@"PurchaseAgreementURL").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FAQ).HasColumnName(@"FAQ").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ExampleDescrip).HasColumnName(@"ExampleDescrip").IsOptional().HasColumnType("nvarchar");
        }
    }
}
