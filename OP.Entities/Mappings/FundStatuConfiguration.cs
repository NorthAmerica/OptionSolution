using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class FundStatuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FundStatus>
    {
        public FundStatuConfiguration()
            : this("dbo")
        {
        }

        public FundStatuConfiguration(string schema)
        {
            ToTable("FundStatus", schema);
            HasKey(x => x.FundStatusID);

            Property(x => x.FundStatusID).HasColumnName(@"FundStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FundStatusName).HasColumnName(@"FundStatusName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.FundStatusNum).HasColumnName(@"FundStatusNum").IsRequired().HasColumnType("int");
        }
    }
}
