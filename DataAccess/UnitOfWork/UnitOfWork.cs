using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Context;
        public UnitOfWork(DbContext _context)
        {
            Context = _context;
        }
        public void Dispose()
        {
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
