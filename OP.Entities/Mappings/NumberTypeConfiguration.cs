using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class NumberTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NumberType>
    {
        public NumberTypeConfiguration()
            : this("dbo")
        {
        }

        public NumberTypeConfiguration(string schema)
        {
            ToTable("NumberTypes", schema);
            HasKey(x => x.NumberTypeID);

            Property(x => x.NumberTypeID).HasColumnName(@"NumberTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NumberTypeName).HasColumnName(@"NumberTypeName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.NumberTypeDescribe).HasColumnName(@"NumberTypeDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
