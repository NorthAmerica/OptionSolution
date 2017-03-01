using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class MenuActionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MenuAction>
    {
        public MenuActionConfiguration()
            : this("dbo")
        {
        }

        public MenuActionConfiguration(string schema)
        {
            ToTable("MenuActions", schema);
            HasKey(x => x.MenuActionID);

            Property(x => x.MenuActionID).HasColumnName(@"MenuActionID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.MenuID).HasColumnName(@"MenuID").IsOptional().HasColumnType("int");
            Property(x => x.ActionName).HasColumnName(@"ActionName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ActionUrl).HasColumnName(@"ActionURL").IsOptional().HasColumnType("nvarchar");
        }
    }
}
