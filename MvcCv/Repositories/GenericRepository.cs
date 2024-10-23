using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();
        // Repository Design Pattern
        // Listeleme
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        // Ekleme
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        // Arama,Bulma
        public T Find(Expression<Func<T,bool>>where)
        {
            // where'den gelen şarta göre ilk değeri döndür
            return db.Set<T>().FirstOrDefault(where);
        }
        // Silme
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        // ID'ye göre getirme,bulma
        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
        // Güncelleme
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
    }
}