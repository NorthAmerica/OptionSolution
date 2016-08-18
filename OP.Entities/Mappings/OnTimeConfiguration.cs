using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class OnTimeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ONTime>
    {
        public OnTimeConfiguration()
            : this("dbo")
        {
        }

        public OnTimeConfiguration(string schema)
        {
            ToTable("ONTimes", schema);
            HasKey(x => x.ONTimeID);

            Property(x => x.ONTimeID).HasColumnName(@"ONTimeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.BeginTime).HasColumnName(@"BeginTime").IsRequired().HasColumnType("datetime");
            Property(x => x.EndTime).HasColumnName(@"EndTime").IsRequired().HasColumnType("datetime");
        }
    }
}
