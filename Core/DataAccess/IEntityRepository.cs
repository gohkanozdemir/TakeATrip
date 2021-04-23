using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess

{   //class : referans tip olabilirlik
    // IEntity : IEntity ve/veya IEntity implemente eden bir nesne
    // new(): constructor i olanlar 
    public interface IEntityRepository<T> where T:class,IEntity,new()   // Generic constrait
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
