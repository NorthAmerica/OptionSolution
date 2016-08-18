using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class UserRoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
            : this("dbo")
        {
        }

        public UserRoleConfiguration(string schema)
        {
            ToTable("UserRoles", schema);
            HasKey(x => x.UserRoleID);

            Property(x => x.UserRoleID).HasColumnName(@"UserRoleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserID).HasColumnName(@"UserID").IsRequired().HasColumnType("int");
            Property(x => x.RoleID).HasColumnName(@"RoleID").IsRequired().HasColumnType("int");
        }
    }
}
