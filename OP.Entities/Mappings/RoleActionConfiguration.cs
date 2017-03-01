using OP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Entities.Mappings
{
    public class RoleActionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RoleAction>
    {
        public RoleActionConfiguration()
            : this("dbo")
        {
        }

        public RoleActionConfiguration(string schema)
        {
            ToTable("RoleActions", schema);
            HasKey(x => x.RoleActionID);

            Property(x => x.RoleActionID).HasColumnName(@"RoleActionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.MenuActionID).HasColumnName(@"MenuActionID").IsOptional().HasColumnType("int");
            Property(x => x.RoleID).HasColumnName(@"RoleID").IsOptional().HasColumnType("int");
        }
    }
}
