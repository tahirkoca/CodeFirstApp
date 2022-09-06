using DataAccess.Mapping;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class CodeFirstDbContext:DbContext
    {
        public CodeFirstDbContext():base("Server = DESKTOP-6A8IQ3D\\MSSQLSERVER2019;Database =KD12CodeFirstAppTekrarDB;Uid = sa ; pwd=1234;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CodeFirstDbContext>());
            //Veritabanımız database'de yoksa gidip onu yaratır.
        }
        public DbSet<Teacher> Teachers { get; set; } //Database'de tablo oluşması için
        public DbSet<School> Schools { get; set; } //Database'de tablo oluşması için

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database düzenleme işlemlerini buraya ekleyeceğim.
            modelBuilder.Configurations.Add(new TeacherMapping());
            modelBuilder.Configurations.Add(new SchoolMapping());
            //Az önce ayarlamış olduğum düzenlemeleri veritabanına yansıtacağımı söyledim.
        }
    }
}
