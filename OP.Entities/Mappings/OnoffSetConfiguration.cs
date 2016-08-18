using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    class OnoffSetConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ONOFFSet>
    {
        public OnoffSetConfiguration()
            : this("dbo")
        {
        }

        public OnoffSetConfiguration(string schema)
        {
            ToTable("ONOFFSets", schema);
            HasKey(x => x.ONOFFSetID);

            Property(x => x.ONOFFSetID).HasColumnName(@"ONOFFSetID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ONOFFMode).HasColumnName(@"ONOFFMode").IsRequired().HasColumnType("int");
            Property(x => x.HandSwitch).HasColumnName(@"HandSwitch").IsRequired().HasColumnType("bit");
        }
    }
}
