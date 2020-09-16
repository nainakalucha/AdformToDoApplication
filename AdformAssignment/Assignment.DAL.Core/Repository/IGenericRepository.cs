using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Assignment.DAL.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenericRepository
    {
        /// <summary>
        /// Adds the specified collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        int Add<T>(T collection) where T : class;
        /// <summary>
        /// Updates the specified collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        int Update<T>(T collection, long Id = 0) where T : class;
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int Delete<T>(long id) where T : class;
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> Get<T>() where T : class;
        /// <summary>
        /// Gets the with condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<T> GetWithCondition<T>(Expression<Func<T,bool>> filter) where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
