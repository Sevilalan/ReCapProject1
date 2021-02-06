using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IEntityRepository<T> where T:class, IEntity, new()   //kısıtlama getirdik 
    {
      //>Bu yapı sayesinde bir standart geliştirmiş  olduk ve böylece kod tekrarına düşmedik.
        List<T> GetAll(Expression<Func<T,bool>>filter=null); // filtereleme yapılıyor null ise filtreleme yapılmamış demektir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); //ekleme yapılıyor
        void Update(T entity); //güncelleme yapılıyor
        void Delete(T entity); //silme yapılıyor

       
    }
}
