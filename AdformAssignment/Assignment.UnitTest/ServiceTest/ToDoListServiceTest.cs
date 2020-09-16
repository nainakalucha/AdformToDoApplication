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
    public class ToDoListServiceTest
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
        /// To do list service
        /// </summary>
        private ToDoListService _toDoListService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IGenericRepository>();
            _mapper = new Mock<IMapper>();
            _toDoListService = new ToDoListService(_repo.Object, _mapper.Object);
        }

        /// <summary>
        /// Gets to do list valid data.
        /// </summary>
        [Test]
        public void GetToDoList_ValidData()
        {
            List<ToDoListEntity> entityList = new List<ToDoListEntity>();
            entityList.Add(new ToDoListEntity { Id = 11, Description = "Des_11", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            entityList.Add(new ToDoListEntity { Id = 12, Description = "Des_12", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            List<ToDoListDTO> dtoList = new List<ToDoListDTO>();
            dtoList.Add(new ToDoListDTO { Id = 11, Description = "Des_11", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            dtoList.Add(new ToDoListDTO { Id = 12, Description = "Des_12", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            _mapper.Setup(p => p.Map<List<ToDoListEntity>, List<ToDoListDTO>>(entityList)).Returns(dtoList);
            _repo.Setup(p => p.Get<ToDoListEntity>()).Returns(entityList);
            PagingDTO pagingDto = new PagingDTO { PageSize = 2, PageIndex = 1, SearchString = null };
            var returnObj = _toDoListService.GetToDoList(pagingDto, 1);
            Assert.IsTrue(returnObj.Count == 2);
        }

        /// <summary>
        /// Adds to do list in valid data.
        /// </summary>
        [Test]
        public void AddToDoList_InValidData()
        {
            ToDoListEntity entity = null;
            ToDoListDTO dto = null;
            _mapper.Setup(p => p.Map<ToDoListDTO, ToDoListEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Add(entity)).Returns(0);
            var returnObj = _toDoListService.AddToDoList(dto);
            Assert.IsTrue(returnObj == null);
        }

        /// <summary>
        /// Adds to do list valid data.
        /// </summary>
        [Test]
        public void AddToDoList_ValidData()
        {
            var dto = new ToDoListDTO { Id = 11, Description = "Desc_11", LabelId = 1,  CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var entity = new ToDoListEntity { Id = 11, Description = "Desc_11", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _mapper.Setup(p => p.Map<ToDoListDTO, ToDoListEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Add(entity)).Returns(1);
            var returnObj = _toDoListService.AddToDoList(dto);
            Assert.AreEqual(11, returnObj.Id);
        }

        /// <summary>
        /// Deletes to do list in valid identifier.
        /// </summary>
        [Test]
        public void DeleteToDoList_InValidId()
        {
            _repo.Setup(p => p.Delete<ToDoListEntity>(0)).Returns(0);
            var returnObj = _toDoListService.DeleteToDoList(0);
            Assert.IsTrue(returnObj == 0);
        }

        /// <summary>
        /// Deletes to do list valid identifier.
        /// </summary>
        [Test]
        public void DeleteToDoList_ValidId()
        {
            _repo.Setup(p => p.Delete<ToDoListEntity>(1)).Returns(1);
            var returnObj = _toDoListService.DeleteToDoList(1);
            Assert.IsTrue(returnObj == 1);
        }


        /// <summary>
        /// Updates to do list valid data.
        /// </summary>
        [Test]
        public void UpdateToDoList_ValidData()
        {
            var dto = new ToDoListDTO { Id = 11, Description = "Desc_11_Update", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var entity = new ToDoListEntity { Id = 11, Description = "Desc_11_Update", LabelId = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _mapper.Setup(p => p.Map<ToDoListDTO, ToDoListEntity>(dto)).Returns(entity);
            _repo.Setup(p => p.Update(entity, entity.Id)).Returns(1);
            var returnObj = _toDoListService.UpdateToDoList(dto);
            Assert.AreEqual(11, returnObj.Id);
        }

    }
}







