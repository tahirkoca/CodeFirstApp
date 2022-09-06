using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class SchoolMapping:EntityTypeConfiguration<School>
    {
        public SchoolMapping()
        {
            this.HasKey(s => s.ID);
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(s => s.Name).HasMaxLength(100).HasColumnType("nvarchar").IsUnicode(true);

            //Öğretmen ile çoka 1 bağlantı
            //1-Okulun birden fazla öğretmeni olur.
            //2-Öğretmenin 1 tane okulu olur.
            //3-Bunlar öğretmen içerisindeki SchoolID ile birbirine bağlanırlar. 
            this.HasMany(s => s.Teachers)
                .WithRequired(t => t.School)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
