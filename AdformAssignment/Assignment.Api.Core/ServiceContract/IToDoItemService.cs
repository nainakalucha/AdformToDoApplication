using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using System.Collections.Generic;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToDoItemService
    {
        /// <summary>
        /// Gets to do item.
        /// </summary>
        /// <returns></returns>
        List<ToDoItemDTO> GetToDoItem(PagingDTO pagingDto, long userId);

        ToDoItemDTO GetById(long id);

        /// <summary>
        /// Adds to do item.
        /// </summary>
        /// <param name="productItem">The item.</param>
        /// <returns></returns>
        ToDoItemDTO AddToDoItem(ToDoItemDTO item);

        /// <summary>
        /// Updates to do item.
        /// </summary>
        /// <param name="productItem">The item.</param>
        /// <returns></returns>
        ToDoItemDTO UpdateToDoItem(ToDoItemDTO item);

        /// <summary>
        /// Deletes to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int DeleteToDoItem(int id);
    }
}
