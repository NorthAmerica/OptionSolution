using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class PartTypeConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PartType>
    {
        public PartTypeConfiguration()
            : this("dbo")
        {
        }

        public PartTypeConfiguration(string schema)
        {
            ToTable("PartTypes", schema);
            HasKey(x => x.PartTypeID);

            Property(x => x.PartTypeID).HasColumnName(@"PartTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.PartTypeName).HasColumnName(@"PartTypeName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PartTypeDescribe).HasColumnName(@"PartTypeDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
