using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class RoleMenuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuConfiguration()
            : this("dbo")
        {
        }

        public RoleMenuConfiguration(string schema)
        {
            ToTable("RoleMenus", schema);
            HasKey(x => x.RoleMenuID);

            Property(x => x.RoleMenuID).HasColumnName(@"RoleMenuID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoleID).HasColumnName(@"RoleID").IsRequired().HasColumnType("int");
            Property(x => x.MenuID).HasColumnName(@"MenuID").IsRequired().HasColumnType("int");
        }
    }
}
