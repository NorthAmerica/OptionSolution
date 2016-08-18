using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class OptionTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OptionType>
    {
        public OptionTypeConfiguration()
            : this("dbo")
        {
        }

        public OptionTypeConfiguration(string schema)
        {
            ToTable("OptionTypes", schema);
            HasKey(x => x.OptionTypeID);

            Property(x => x.OptionTypeID).HasColumnName(@"OptionTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OptionTypeName).HasColumnName(@"OptionTypeName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OptionTypeDescribe).HasColumnName(@"OptionTypeDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
