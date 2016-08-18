using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class TdayConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Tday>
    {
        public TdayConfiguration()
            : this("dbo")
        {
        }

        public TdayConfiguration(string schema)
        {
            ToTable("Tdays", schema);
            HasKey(x => x.TdayID);

            Property(x => x.TdayID).HasColumnName(@"TdayID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Tdays).HasColumnName(@"Tdays").IsOptional().HasColumnType("nvarchar");
            Property(x => x.Tyear).HasColumnName(@"Tyear").IsRequired().HasColumnType("int");
            Property(x => x.Tnum).HasColumnName(@"Tnum").IsRequired().HasColumnType("int");
        }
    }
}
