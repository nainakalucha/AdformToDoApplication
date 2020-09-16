using Assignment.Api.Core;
using Assignment.Contract.Core;
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
    public class LabelsServiceTest
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
        /// The label service
        /// </summary>
        private LabelService labelService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IGenericRepository>();
            _mapper = new Mock<IMapper>();
            labelService = new LabelService(_repo.Object, _mapper.Object);
        }

        /// <summary>
        /// Gets the label in valid data.
        /// </summary>
        [Test]
        public void GetLabel_InValidData()
        {
            List<LabelEntity> labelList = new List<LabelEntity>();
            labelList.Add(new LabelEntity { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            labelList.Add(new LabelEntity { Id = 12, Description = "Label_12", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            List<LabelDTO> dtoList = new List<LabelDTO>();
            dtoList.Add(new LabelDTO { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            dtoList.Add(new LabelDTO { Id = 12, Description = "Label_12", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            _mapper.Setup(p => p.Map<List<LabelEntity>, List<LabelDTO>>(labelList)).Returns(dtoList);
            _repo.Setup(p => p.Get<LabelEntity>()).Returns(labelList);
            var returnObj = labelService.GetLabels();
            Assert.IsTrue(returnObj.Count == 2);
        }

        /// <summary>
        /// Adds the label in valid data.
        /// </summary>
        [Test]
        public void AddLabel_InValidData()
        {
            LabelEntity labelEntity = null;
            LabelDTO labelDTO = null;
            _mapper.Setup(p => p.Map<LabelDTO, LabelEntity>(labelDTO)).Returns(labelEntity);
            _repo.Setup(p => p.Add(labelEntity)).Returns(0);
            var returnObj = labelService.AddLabel(labelDTO);
            Assert.IsTrue(returnObj == null);
        }

        /// <summary>
        /// Adds the label valid data.
        /// </summary>
        [Test]
        public void AddLabel_ValidData()
        {
            var labelDto = new LabelDTO { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            var labelEntity = new LabelEntity { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _mapper.Setup(p => p.Map<LabelDTO, LabelEntity>(labelDto)).Returns(labelEntity);
            _repo.Setup(p => p.Add(labelEntity)).Returns(1);
            var returnObj = labelService.AddLabel(labelDto);
            Assert.AreEqual(11, returnObj.Id);
        }

        /// <summary>
        /// Deletes the label in valid identifier.
        /// </summary>
        [Test]
        public void DeleteLabel_InValidId()
        {
            _repo.Setup(p => p.Delete<LabelEntity>(0)).Returns(0);
            var returnObj = labelService.DeleteLabel(0);
            Assert.IsTrue(returnObj == 0);
        }

        /// <summary>
        /// Deletes the label valid identifier.
        /// </summary>
        [Test]
        public void DeleteLabel_ValidId()
        {
            _repo.Setup(p => p.Delete<LabelEntity>(1)).Returns(1);
            var returnObj = labelService.DeleteLabel(1);
            Assert.IsTrue(returnObj == 1);
        }


    }
}







