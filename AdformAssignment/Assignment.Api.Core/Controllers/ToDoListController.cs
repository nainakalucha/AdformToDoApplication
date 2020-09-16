using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private Framework.Core.ILogger _logger;
        /// <summary>
        /// To do list service
        /// </summary>
        private IToDoListService _toDoListService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoListController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="toDoListService">To do list service.</param>
        public ToDoListController(Framework.Core.ILogger logger, IToDoListService toDoListService, IMapper mapper)
        {
            _logger = logger;
            _toDoListService = toDoListService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets to do list.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/todolist")]
        public IActionResult GetToDoList(int pageSize, int pageIndex, string searchString)
        {
             _logger.Info(() => "Api GetToDoList");
             PagingDTO pagingDto = new PagingDTO { PageSize = pageSize, PageIndex = pageIndex, SearchString = searchString };
             return StatusCode((int)HttpStatusCode.OK, _toDoListService.GetToDoList(pagingDto, (long)HttpContext.Request.HttpContext.Items["Userid"]));                          
        }

        /// <summary>
        /// Adds to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        [HttpPost("/api/todolist")]
        public ActionResult<ToDoListDTO> AddToDoList(ToDoListDTO todolist)
        {
            _logger.Info(() => "Api AddProduct");
            todolist.CreatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            todolist.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            _toDoListService.AddToDoList(todolist);
            return StatusCode((int)HttpStatusCode.OK, todolist);
        }

        /// <summary>
        /// Updates to do list.
        /// </summary>
        /// <param name="todolist">The todolist.</param>
        /// <returns></returns>
        [HttpPut("/api/todolist")]
        public ActionResult<ToDoListDTO> UpdateToDoList(ToDoListDTO todolist)
        {
            todolist.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            _toDoListService.UpdateToDoList(todolist);
             return StatusCode((int)HttpStatusCode.OK, todolist);
        }

        /// <summary>
        /// Partials the update to do list.
        /// </summary>
        /// <param name="todoListId">The todo list identifier.</param>
        /// <param name="labelId">The label identifier.</param>
        /// <returns></returns>
        [HttpPatch("/api/ToDoList")]
        public ActionResult<ToDoItemDTO> PartialUpdateToDoList(long todoListId, JsonPatchDocument<ToDoListDTO> itemPatch)
        {
            var todolist = _toDoListService.GetById(todoListId);
            itemPatch.ApplyTo(todolist);
            todolist.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            _toDoListService.UpdateToDoList(todolist);
            return StatusCode((int)HttpStatusCode.OK, todolist);
        }

        /// <summary>
        /// Deletes to do list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("/api/todolist")]
        public ActionResult<int> DeleteToDoList(int id)
        {
             var returnId = _toDoListService.DeleteToDoList(id);
             return StatusCode((int)HttpStatusCode.OK, returnId);
        }
    }
}
