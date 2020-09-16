using Assignment.Api.Core;
using Assignment.Contract.Core;
using Assignment.Contract.Core.Contract;
using Assignment.DAL.Core;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assignment.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDoItemServiceTest
    {
        /// <summary>
        /// The repo
        /// </summary>
        private Mock<IGenericRepository> _repo;
        /// <summary>
        /// The mapper
        /// </summary>
        private Mock<IMapper> _mapper;
        /// <summary>
        /// The todoitem service
        /// </summary>
        private ToDoItemService todoitemService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IGenericRepository>();
            _mapper = new Mock<IMapper>();
            todoitemService = new ToDoItemService(_repo.Object, _mapper.Object);
        }

        /// <summary>
        /// Gets to do item valid data.
        /// </summary>
        [Test]
        public void GetToDoItem_ValidData()
        {
            List<ToDoItemEntity> entityList = new List<ToDoItemEntity>();
            entityList.Add(new ToDoItemEntity { Id = 11, Note = "Note_11", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            entityList.Add(new ToDoItemEntity { Id = 12, Note = "Note_12", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            List<ToDoItemDTO> dtoList = new List<ToDoItemDTO>();
            dtoList.Add(new ToDoItemDTO { Id = 11, Note = "Note_11", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            dtoList.Add(new ToDoItemDTO { Id = 12, Note = "Note_12", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            _mapper.Setup(p => p.Map<List<ToDoItemEntity>, List<ToDoItemDTO>>(entityList)).Returns(dtoList);
            _repo.Setup(p => p.Get<ToDoItemEntity>()).Returns(entityList);
            PagingDTO pagingDto = new PagingDTO { PageSize = 2, PageIndex = 1, SearchString = null};
            var returnObj = todoitemService.GetToDoItem(pagingDto, 1);
            Assert.IsTrue(returnObj.Count == 2);
        }


        /// <summary>
        /// Adds to do item in valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_InValidData()
        {
            ToDoItemEntity entity = null;
            ToDoItemDTO dto = null;
            _mapper.Setup(p => p.Map<ToDoItemDTO, ToDoItemEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Add(entity)).Returns(0);
            var returnObj = todoitemService.AddToDoItem(dto);
            Assert.IsTrue(returnObj == null);
        }

        /// <summary>
        /// Adds to do item valid data.
        /// </summary>
        [Test]
        public void AddToDoItem_ValidData()
        {
            var dto = new ToDoItemDTO { Id = 11, Note = "Note_11", LabelId = 1, ToDoListId =1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var entity = new ToDoItemEntity { Id = 11, Note = "Note_11", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _mapper.Setup(p => p.Map<ToDoItemDTO, ToDoItemEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Add(entity)).Returns(1);
            var returnObj = todoitemService.AddToDoItem(dto);
            Assert.AreEqual(11, returnObj.Id);
        }

        /// <summary>
        /// Deletes to do item in valid identifier.
        /// </summary>
        [Test]
        public void DeleteToDoItem_InValidId()
        {
            _repo.Setup(p => p.Delete<ToDoItemEntity>(0)).Returns(0);
            var returnObj = todoitemService.DeleteToDoItem(0);
            Assert.IsTrue(returnObj == 0);
        }

        /// <summary>
        /// Deletes to do item valid identifier.
        /// </summary>
        [Test]
        public void DeleteToDoItem_ValidId()
        {
            _repo.Setup(p => p.Delete<ToDoItemEntity>(1)).Returns(1);
            var returnObj = todoitemService.DeleteToDoItem(1);
            Assert.IsTrue(returnObj == 1);
        }


        /// <summary>
        /// Updates to do item valid data.
        /// </summary>
        [Test]
        public void UpdateToDoItem_ValidData()
        {
            var dto = new ToDoItemDTO { Id = 11, Note = "Note_11_Update", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var entity = new ToDoItemEntity { Id = 11, Note = "Note_11_Update", LabelId = 1, ToDoListId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _mapper.Setup(p => p.Map<ToDoItemDTO, ToDoItemEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Update(entity, entity.Id)).Returns(1);
            var returnObj = todoitemService.UpdateToDoItem(dto);
            Assert.AreEqual(11, returnObj.Id);
        }

    }
}







