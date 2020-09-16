using Assignment.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment.DAL.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.DAL.Core.IGenericRepository" />
    public class GenericSQLRepository : IGenericRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly AssignmentSqlDbContext _context = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSQLRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericSQLRepository(AssignmentSqlDbContext context)
        {
          this. _context = context;          

        }

        /// <summary>
        /// Adds the specified collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public int Add<T>(T collection) where T : class
        {
            var dbSet= _context.Set<T>();
            dbSet.Add(collection);
            return _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public int Update<T>(T collection, long Id = 0) where T:class
        {
            var dbSet = _context.Set<T>();
            var local = dbSet.Find(Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(collection).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int Delete<T>(long id) where T:class
        {
            var dbSet = _context.Set<T>();
            var item = dbSet.Find(id);
            dbSet.Remove(item);
            return _context.SaveChanges();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Get<T>() where T:class
        {
            var dbSet = _context.Set<T>();
            var result = dbSet.ToList();
            return result;
        }

        /// <summary>
        /// Gets the with condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<T> GetWithCondition<T>(Expression<Func<T, bool>> filter) where T : class
        {
            var dbSet = _context.Set<T>();
            return dbSet.Where(filter).ToList();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
