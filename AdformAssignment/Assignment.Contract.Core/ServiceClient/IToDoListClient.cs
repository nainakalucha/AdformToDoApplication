using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToDoListClient
    {
        /// <summary>
        /// Gets to do list.
        /// </summary>
        /// <returns></returns>
        [Get("/api/todolist")]
        Task<HttpResponseMessage> GetToDoList();

        /// <summary>
        /// Adds to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        [Post("/api/todolist")]
        Task<HttpResponseMessage> AddToDoList(ToDoListDTO todolist);

        /// <summary>
        /// Updates to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        [Put("/api/todolist")]
        Task<HttpResponseMessage> UpdateToDoList(ToDoListDTO todolist);

        /// <summary>
        /// Deletes to do list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Delete("/api/todolist")]
        Task<HttpResponseMessage> DeleteToDoList(int id);
    }
}
