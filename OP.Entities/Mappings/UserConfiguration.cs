using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP.Entities.Models;

namespace OP.Entities.Mappings
{
    public class UserConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserConfiguration()
            : this("dbo")
        {
        }

        public UserConfiguration(string schema)
        {
            ToTable("Users", schema);
            HasKey(x => x.UserID);

            Property(x => x.UserID).HasColumnName(@"UserID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName(@"UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.UserPassword).HasColumnName(@"UserPassword").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Enable).HasColumnName(@"Enable").IsRequired().HasColumnType("bit");
            Property(x => x.IsAdmin).HasColumnName(@"IsAdmin").IsRequired().HasColumnType("bit");
            Property(x => x.Date).HasColumnName(@"Date").IsOptional().HasColumnType("nvarchar");
        }
    }
}
