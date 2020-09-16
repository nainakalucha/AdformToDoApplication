using Assignment.Api.Core;
using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Assignment.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDoItemControllerTest
    {
        /// <summary>
        /// The todo item service
        /// </summary>
        private Mock<IToDoItemService> _todoItemService;
        /// <summary>
        /// The logger
        /// </summary>
        private Mock<Framework.Core.ILogger> _logger;
        /// <summary>
        /// The todo item controller
        /// </summary>
        private ToDoItemController todoItemController;

        private Mock<IMapper> _mapper;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.HttpContext.Items["Userid"] = Convert.ToInt64(1);
            _todoItemService = new Mock<IToDoItemService>();
            _logger = new Mock<Framework.Core.ILogger>();
            _mapper = new Mock<IMapper>();
            todoItemController = new ToDoItemController(_logger.Object, _todoItemService.Object, _mapper.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
        }

        /// <summary>
        /// Gets to do item valid data.
        /// </summary>
        [Test]
        public void GetToDoItem_ValidData()
        {
            List<ToDoItemDTO> todoItemlist = new List<ToDoItemDTO>();
            todoItemlist.Add(new ToDoItemDTO { Id = 11, Note = "Note_11", ToDoListId = 1, LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            todoItemlist.Add(new ToDoItemDTO { Id = 12, Note = "Note_12", ToDoListId = 1, LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            PagingDTO pagingDto = new PagingDTO { PageSize = 0, PageIndex = 0, SearchString = string.Empty };
            _todoItemService.Setup(p => p.GetToDoItem(pagingDto,1)).Returns(todoItemlist);
            var returnObj = todoItemController.GetToDoItem(0,0,string.Empty);
            var okResult = returnObj as ObjectResult;
            var valueResult = okResult.Value as List<ToDoItemDTO>;
            Assert.IsTrue(valueResult != null);
        }

        /// <summary>
        /// Adds to do item in valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_InValidData()
        {
            _todoItemService.Setup(p => p.AddToDoItem(null)).Returns(new ToDoItemDTO());
             var returnObj = todoItemController.AddToDoItem(null);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as ToDoItemDTO;
            Assert.IsTrue(valueResult == null);
        }

        /// <summary>
        /// Adds to do item valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_ValidData()
        {
            var toDoItemDto = new ToDoItemDTO { Id = 11, Note = "Note_11", ToDoListId = 1, LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _todoItemService.Setup(p => p.AddToDoItem(toDoItemDto)).Returns(toDoItemDto);
            var returnObj = todoItemController.AddToDoItem(toDoItemDto);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as ToDoItemDTO;
            Assert.AreEqual(11, valueResult.Id);
        }

        /// <summary>
        /// Deletetoes the do item in valid identifier.
        /// </summary>
        [Test]
        public void DeletetoDoItem_InValidId()
        {
            _todoItemService.Setup(p => p.DeleteToDoItem(0)).Returns(0);
            var returnObj = todoItemController.DeleteToDoItem(0);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 0);
        }

        /// <summary>
        /// Addtoes the do item valid identifier.
        /// </summary>
        [Test]
        public void AddtoDoItem_ValidId()
        {
            _todoItemService.Setup(p => p.DeleteToDoItem(11)).Returns(1);
            var returnObj = todoItemController.DeleteToDoItem(11);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 11);
        }

    }
}







