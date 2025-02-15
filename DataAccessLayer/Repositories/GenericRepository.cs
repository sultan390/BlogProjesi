using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id); // aşağıdaki gibi burda aynı yöntemi kullandık. 
        }

        public List<T> GetListAll()
        {
            using var c = new Context(); // burda tolist veya c.T gibi bir şey olmaz  kullanmayız.
            return c.Set<T>().ToList();   // sete bağlı olarak kullanabiliriz. burda kullanıbiliecek bir entity adı vermedik dışardan alacağımız için böyle bir yöntem kullandık. 

        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();   // filter dan  gelen değere göre where ile listeler 

        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
