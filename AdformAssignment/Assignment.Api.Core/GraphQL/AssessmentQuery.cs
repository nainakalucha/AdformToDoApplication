using Assignment.Contract.Core;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AssessmentQuery
    {
        /// <summary>
        /// The todoitem service
        /// </summary>
        private readonly IToDoItemService _todoitemService;
        /// <summary>
        /// The label service
        /// </summary>
        private readonly ILabelService _labelService;
        /// <summary>
        /// The todolist service
        /// </summary>
        private readonly IToDoListService _todolistService;

        private readonly IUserService _userService;
        /// <summary>
        /// The paging dto
        /// </summary>
        private Contract.Core.Contract.PagingDTO pagingDto;


        /// <summary>
        /// Initializes a new instance of the <see cref="AssessmentQuery"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="labelService">The label service.</param>
        /// <param name="todoListService">The todo list service.</param>
        public AssessmentQuery(IToDoItemService service, ILabelService labelService, IToDoListService todoListService, IUserService userService)
        {
            _todoitemService = service;
            _labelService = labelService;
            _todolistService = todoListService;
            _userService = userService;
            pagingDto = new Contract.Core.Contract.PagingDTO { PageIndex = 0, PageSize = 0, SearchString = null };
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <returns></returns>
        [UseFiltering]
        public List<LabelDTO> GetLabels() => _labelService.GetLabels().ToList();

        /// <summary>
        /// Gets to do items.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [UseFiltering]
        public List<ToDoItemDTO> GetToDoItems(Contract.Core.Contract.PagingDTO dto, [Service] IHttpContextAccessor contextAccessor)
        {
            AuthorizeHeader(contextAccessor);
            long userId = contextAccessor.HttpContext.Request.HttpContext.Items["Userid"] == null ? 0 : (long)contextAccessor.HttpContext.Request.HttpContext.Items["Userid"];
            var itemList = _todoitemService.GetToDoItem(pagingDto, userId);
            return itemList;
        }
        /// <summary>
        /// Gets to do list.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [UseFiltering]
        public List<ToDoListDTO> GetToDoList(Contract.Core.Contract.PagingDTO dto, [Service] IHttpContextAccessor contextAccessor)
        {
            AuthorizeHeader(contextAccessor);
            long userId = contextAccessor.HttpContext.Request.HttpContext.Items["Userid"] == null ? 0 : (long)contextAccessor.HttpContext.Request.HttpContext.Items["Userid"];
            var itemList = _todolistService.GetToDoList(pagingDto, userId);
            return itemList;
        }

        private void AuthorizeHeader([Service] IHttpContextAccessor contextAccessor)
        {
            string authHeader = contextAccessor.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                int seperatorIndex = authHeader.IndexOf(':');

                var username = authHeader.Substring(0, seperatorIndex);
                var password = authHeader.Substring(seperatorIndex + 1);
                var validUser = _userService.AuthenticateUser(username, password);
                if (validUser != null)
                {
                    contextAccessor.HttpContext.Request.HttpContext.Items["Userid"] = validUser.Id;
                }
            }
        }
        
    }
}
