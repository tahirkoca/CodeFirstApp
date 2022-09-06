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
    public class TeacherMapping:EntityTypeConfiguration<Teacher>
    {
        //TeacherMapping classında biz Teacher classında tanımlamış olduğumuz prop'ların özelliklerinin ayarlanmasını sağladığımız yerdir.Yani bir kolonun Identity olması,Maksimum 50 karakter girilmesi gibi özellikleri mapping classı içinde ayarlarız.
        public TeacherMapping()
        {
            this.HasKey(t => t.ID);//Teacher classı içinde ID prop'u PrimaryKey olarak ayarladım.
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            //ID kolonunu identity olarak ayarlayıp boş geçilemeyeceğini söyledim.

            //ColumnType SQL'e göre yazılacak
            this.Property(t => t.FirstName).HasMaxLength(25).HasColumnType("nvarchar");

            //1 Öğretmen Kısmı
            //1-Öğretmenin bir okulu olur.
            //2-Oklun birden fazla öğretmeni olur.
            //3-Bunlarda gidip SchoolID üzerinden bağlanır.
            this.HasRequired(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
