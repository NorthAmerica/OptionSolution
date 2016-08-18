using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class RoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
            : this("dbo")
        {
        }

        public RoleConfiguration(string schema)
        {
            ToTable("Roles", schema);
            HasKey(x => x.RoleID);

            Property(x => x.RoleID).HasColumnName(@"RoleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoleName).HasColumnName(@"RoleName").IsRequired().HasColumnType("nvarchar");
            Property(x => x.RoleDescribe).HasColumnName(@"RoleDescribe").IsOptional().HasColumnType("nvarchar");
        }
    }
}
