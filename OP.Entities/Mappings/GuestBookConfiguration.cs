using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class GuestBookConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GuestBook>
    {
        public GuestBookConfiguration()
            : this("dbo")
        {
        }

        public GuestBookConfiguration(string schema)
        {
            ToTable("GuestBooks", schema);
            HasKey(x => x.GuestBookID);

            Property(x => x.GuestBookID).HasColumnName(@"GuestBookID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GuestName).HasColumnName(@"GuestName").IsOptional().HasColumnType("nvarchar");
            Property(x => x.GuestMobile).HasColumnName(@"GuestMobile").IsOptional().HasColumnType("nvarchar");
            Property(x => x.GuestContent).HasColumnName(@"GuestContent").IsOptional().HasColumnType("nvarchar");
            Property(x => x.GuestDate).HasColumnName(@"GuestDate").IsRequired().HasColumnType("datetime");
        }
    }
}
