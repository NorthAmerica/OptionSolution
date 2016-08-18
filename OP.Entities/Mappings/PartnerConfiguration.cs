using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class PartnerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Partner>
    {
        public PartnerConfiguration()
            : this("dbo")
        {
        }

        public PartnerConfiguration(string schema)
        {
            ToTable("Partners", schema);
            HasKey(x => x.PartnerID);

            Property(x => x.PartnerID).HasColumnName(@"PartnerID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PartnerName).HasColumnName(@"PartnerName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PartnerDescribe).HasColumnName(@"PartnerDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
