using DataAccess.Context;
using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcreteRepository
{
    //<T> yerlşetirince generic bir yapıya döüştürdüm.
    //where T:class diyerek generic yapının class olması zorunluluğunu ifade ettim
    //Bu gelen classların IBaseEntity tipinde olması gerektiğini söyledim.

    //BaseRepository CRUD işlemlerimizi üstlenir.
    public class BaseRepository<T> where T:class,IBaseEntity
    {
        private readonly CodeFirstDbContext _codeFirstDbContext; //CRUD işlemleri için buna ihtiyacım vardı.
        private DbSet<T> _table;
        public BaseRepository(CodeFirstDbContext codeFirstDbContext)
        {
            _codeFirstDbContext = codeFirstDbContext;
            _table = _codeFirstDbContext.Set<T>(); //School gelirse _table-->DbSet<School> 
                                                   //Teacher gelirse _table-->DbSet<Teacher>        
        }
        public bool Add(T entity)
        {
            _table.Add(entity);
            return Save() > 0;
        }
        public bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return Save() > 0;
        }
        public bool Delete(T entity)
        {
            //Veritabanında biz verilerin silinmeyeceğini status'unu deleted olarak vereceğimizi söylediğimizden metodu böyle yazdık.
            entity.status=Status.Deleted;
            return Update(entity);
            
            //Normalde silme işlemi böyle yapılırdı.
            //_table.Remove(entity);
            //return Save() > 0;
        }
        public bool Update(T entity)
        {
            //Senin change tracker ile durum kontrolü yapmamı sağlıyor.
            _codeFirstDbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save() > 0;
        }
        public int Save()
        {
            return _codeFirstDbContext.SaveChanges();
        }
        public List<T> GetAll()
        {
            return _table.Where(x => x.status == Status.Active || x.status == Status.Modified).ToList();
        }
        public T GetById(int id)
        {
            return _table.Find(id);
        }
       
    }
}
