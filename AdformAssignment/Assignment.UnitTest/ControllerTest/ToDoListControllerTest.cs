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
using System.Net;


namespace Assignment.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDoListControllerTest
    {
        private Mock<IMapper> _mapper;
        /// <summary>
        /// The todo list service
        /// </summary>
        private Mock<IToDoListService> _todoListService;
        /// <summary>
        /// The logger
        /// </summary>
        private Mock<Framework.Core.ILogger> _logger;
        /// <summary>
        /// The todo list controller
        /// </summary>
        private ToDoListController todoListController;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.HttpContext.Items["Userid"] = Convert.ToInt64(1);
            _todoListService = new Mock<IToDoListService>();
            _logger = new Mock<Framework.Core.ILogger>();
            _mapper = new Mock<IMapper>();
            todoListController = new ToDoListController(_logger.Object, _todoListService.Object, _mapper.Object) {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
        }

        /// <summary>
        /// Gets to do list valid data.
        /// </summary>
        [Test]
        public void GetToDoList_ValidData()
        {
            
            List<ToDoListDTO> list = new List<ToDoListDTO>();
            list.Add(new ToDoListDTO { Id = 11, Description = "List_11", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            list.Add(new ToDoListDTO { Id = 12, Description = "List_12", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            PagingDTO pagingDto = new PagingDTO { PageSize = 0, PageIndex = 0, SearchString = null };
            _todoListService.Setup(p => p.GetToDoList(pagingDto, 1)).Returns(list);
            var returnObj = todoListController.GetToDoList(0, 0, null);
            var okResult = returnObj as ObjectResult;
            var valueResult = okResult.Value as List<ToDoListDTO>;
            Assert.IsTrue(valueResult != null);
        }

        /// <summary>
        /// Adds to do item in valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_InValidData()
        {
            _todoListService.Setup(p => p.AddToDoList(null)).Returns(new ToDoListDTO());
             var returnObj = todoListController.AddToDoList(null);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as ToDoListDTO;
            Assert.IsTrue(valueResult == null);
        }

        /// <summary>
        /// Adds to do item valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_ValidData()
        {
            var dto = new ToDoListDTO { Id = 11, Description = "List_11", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _todoListService.Setup(p => p.AddToDoList(dto)).Returns(dto);
            var returnObj = todoListController.AddToDoList(dto);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as ToDoListDTO;
            Assert.AreEqual(11, valueResult.Id);
        }

        /// <summary>
        /// Deletetoes the do list in valid identifier.
        /// </summary>
        [Test]
        public void DeletetoDoList_InValidId()
        {
            _todoListService.Setup(p => p.DeleteToDoList(0)).Returns(0);
            var returnObj = todoListController.DeleteToDoList(0);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 0);
        }

        /// <summary>
        /// Addtoes the do list valid identifier.
        /// </summary>
        [Test]
        public void AddtoDoList_ValidId()
        {
            _todoListService.Setup(p => p.DeleteToDoList(11)).Returns(1);
            var returnObj = todoListController.DeleteToDoList(11);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 1);
        }

    }
}







