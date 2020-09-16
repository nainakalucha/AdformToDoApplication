using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToDoItemClient
    {
        /// <summary>
        /// Gets to do item.
        /// </summary>
        /// <returns></returns>
        [Get("/api/ToDoItem")]
        Task<HttpResponseMessage> GetToDoItem();

        /// <summary>
        /// Adds to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        [Post("/api/ToDoItem")]
        Task<HttpResponseMessage> AddToDoItem(ToDoItemDTO ToDoItem);

        /// <summary>
        /// Updates to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        [Put("/api/ToDoItem")]
        Task<HttpResponseMessage> UpdateToDoItem(ToDoItemDTO ToDoItem);

        /// <summary>
        /// Deletes to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Delete("/api/ToDoItem")]
        Task<HttpResponseMessage> DeleteToDoItem(int id);
    }
}
