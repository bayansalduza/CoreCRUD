using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Ekleme işlemi.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Silme işleme.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        
        /// <summary>
        /// id alıp geriye bir entity döner
        /// </summary>
        /// <param name="id">Geriye dönülmesini istediğimiz id paramatresi</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Update işlemi yapar
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Geriye list döner ve bir linq şart alır.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> condition);
    }
}
