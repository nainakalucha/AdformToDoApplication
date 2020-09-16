using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using System.Collections.Generic;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToDoListService
    {
        /// <summary>
        /// Gets to do list.
        /// </summary>
        /// <param name="pagingDto">The paging dto.</param>
        /// <returns></returns>
        List<ToDoListDTO> GetToDoList(PagingDTO pagingDto, long userId);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ToDoListDTO GetById(long id);

        /// <summary>
        /// Adds to do list.
        /// </summary>
        /// <param name="productItem">The product item.</param>
        /// <returns></returns>
        ToDoListDTO AddToDoList(ToDoListDTO productItem);

        /// <summary>
        /// Updates to do list.
        /// </summary>
        /// <param name="productItem">The product item.</param>
        /// <returns></returns>
        ToDoListDTO UpdateToDoList(ToDoListDTO productItem);

        /// <summary>
        /// Deletes to do list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int DeleteToDoList(int id);
    }
}
