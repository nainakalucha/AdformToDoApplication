using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class ToDoItemController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private Framework.Core.ILogger _logger;
        /// <summary>
        /// To do item service
        /// </summary>
        private IToDoItemService _toDoItemService;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoItemController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ToDoItemService">To do item service.</param>
        public ToDoItemController(Framework.Core.ILogger logger, IToDoItemService toDoItemService, IMapper mapper)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets to do item.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/ToDoItem")]
        public IActionResult GetToDoItem(int pageSize, int pageIndex, string searchString)
        {
            
              _logger.Info(() => "Api GetToDoItem");            
              PagingDTO pagingDto = new PagingDTO { PageSize = pageSize, PageIndex = pageIndex, SearchString = searchString };
              return StatusCode((int)HttpStatusCode.OK, _toDoItemService.GetToDoItem(pagingDto, (long)HttpContext.Request.HttpContext.Items["Userid"]));               
            
        }

        /// <summary>
        /// Adds to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        [HttpPost("/api/ToDoItem")]
        public ActionResult<ToDoItemDTO> AddToDoItem(ToDoItemDTO ToDoItem)
        {
             _logger.Info(() => "Api AddProduct");
             ToDoItem.CreatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
             ToDoItem.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
             _toDoItemService.AddToDoItem(ToDoItem);
             return StatusCode((int)HttpStatusCode.OK, ToDoItem);
        }

        /// <summary>
        /// Updates to do item.
        /// </summary>
        /// <param name="ToDoItem">To do item.</param>
        /// <returns></returns>
        [HttpPut("/api/ToDoItem")]
        public ActionResult<ToDoItemDTO> UpdateToDoItem(ToDoItemDTO ToDoItem)
        {
            ToDoItem.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            _toDoItemService.UpdateToDoItem(ToDoItem);
            return StatusCode((int)HttpStatusCode.OK, ToDoItem);
            
        }

        /// <summary>
        /// Partials the update to do item.
        /// </summary>
        /// <param name="todoItemId">The todo item identifier.</param>
        /// <param name="labelId">The label identifier.</param>
        /// <returns></returns>
        [HttpPatch("/api/ToDoItem")]
        public ActionResult<ToDoItemDTO> PartialUpdateToDoItem(long todoItemId, JsonPatchDocument<ToDoItemDTO> itemPatch)
        {
            var toDoItem = _toDoItemService.GetById(todoItemId);
            itemPatch.ApplyTo(toDoItem);
            toDoItem.UpdatedBy = (long)HttpContext.Request.HttpContext.Items["Userid"];
            _toDoItemService.UpdateToDoItem(toDoItem);
              return StatusCode((int)HttpStatusCode.OK, toDoItem);
        }

        /// <summary>
        /// Deletes to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("/api/ToDoItem")]
        public ActionResult<int> DeleteToDoItem(int id)
        {            
            return StatusCode((int)HttpStatusCode.OK, _toDoItemService.DeleteToDoItem(id));
        }
    }
}
