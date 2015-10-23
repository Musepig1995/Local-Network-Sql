namespace Harrison.Database.DataAccess
{
    using Model;
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> List { get; }
        int Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T FindById(int id);
    }
}
