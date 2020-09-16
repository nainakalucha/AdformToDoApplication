using Assignment.Api.Core;
using Assignment.Contract.Core;
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
    public class LabelControllerTest
    {
        /// <summary>
        /// The label service
        /// </summary>
        private Mock<ILabelService> _labelService;
        /// <summary>
        /// The logger
        /// </summary>
        private Mock<Framework.Core.ILogger> _logger;
        /// <summary>
        /// The label controller
        /// </summary>
        private LabelController labelController;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _labelService = new Mock<ILabelService>();
            _logger = new Mock<Framework.Core.ILogger>();
            labelController = new LabelController(_logger.Object, _labelService.Object);
        }

        /// <summary>
        /// Gets the label valid data.
        /// </summary>
        [Test]
        public void GetLabel_ValidData()
        {
            List<LabelDTO> labelList = new List<LabelDTO>();
            labelList.Add(new LabelDTO { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            labelList.Add(new LabelDTO { Id = 12, Description = "Label_12", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            _labelService.Setup(p => p.GetLabels()).Returns(labelList);
            var returnObj = labelController.GetLabels();
            var okResult = returnObj as ObjectResult;
            var valueResult = okResult.Value as List<LabelDTO>;
            Assert.IsTrue(valueResult.Count == 2);
        }

        /// <summary>
        /// Adds the label in valid data.
        /// </summary>
        [Test]
        public void AddLabel_InValidData()
        {
            _labelService.Setup(p => p.AddLabel(null)).Returns(new LabelDTO());
             var returnObj = labelController.AddLabel(null);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as LabelDTO;
            Assert.IsTrue(valueResult == null);
        }

        /// <summary>
        /// Adds the label valid data.
        /// </summary>
        [Test]
        public void AddLabel_ValidData()
        {
            var labelDto = new LabelDTO { Id = 11, Description = "Label_11", CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            _labelService.Setup(p => p.AddLabel(labelDto)).Returns(labelDto);
            var returnObj = labelController.AddLabel(labelDto);
            var okResult = returnObj.Result as ObjectResult;
            var valueResult = okResult.Value as LabelDTO;
            Assert.AreEqual(11, valueResult.Id);
        }

        /// <summary>
        /// Deletes the label in valid identifier.
        /// </summary>
        [Test]
        public void DeleteLabel_InValidId()
        {
            _labelService.Setup(p => p.DeleteLabel(0)).Returns(0);
            var returnObj = labelController.DeleteLabel(0);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 0);
        }

        /// <summary>
        /// Deletes the label valid identifier.
        /// </summary>
        [Test]
        public void DeleteLabel_ValidId()
        {
            _labelService.Setup(p => p.DeleteLabel(11)).Returns(1);
            var returnObj = labelController.DeleteLabel(11);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((int)okResult.Value == 1);
        }

    }
}







