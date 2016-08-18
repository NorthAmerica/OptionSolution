using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class MenuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
            : this("dbo")
        {
        }

        public MenuConfiguration(string schema)
        {
            ToTable("Menus", schema);
            HasKey(x => x.MenuID);

            Property(x => x.MenuID).HasColumnName(@"MenuID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.MenuName).HasColumnName(@"MenuName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.MenuURL).HasColumnName(@"MenuURL").IsOptional().HasColumnType("nvarchar");
            Property(x => x.OrderNum).HasColumnName(@"OrderNum").IsRequired().HasColumnType("int");
            Property(x => x.FMenuID).HasColumnName(@"FMenuID").IsRequired().HasColumnType("int");
        }
    }
}
