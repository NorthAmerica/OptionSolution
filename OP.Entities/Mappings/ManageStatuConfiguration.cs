using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class ManageStatuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ManageStatus>
    {
        public ManageStatuConfiguration()
            : this("dbo")
        {
        }

        public ManageStatuConfiguration(string schema)
        {
            ToTable("ManageStatus", schema);
            HasKey(x => x.ManageStatusID);

            Property(x => x.ManageStatusID).HasColumnName(@"ManageStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ManageStatusName).HasColumnName(@"ManageStatusName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ManageStatusNum).HasColumnName(@"ManageStatusNum").IsRequired().HasColumnType("int");
        }
    }
}
