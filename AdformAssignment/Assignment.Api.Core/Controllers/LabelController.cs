using Assignment.Contract.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v1/label")]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private Framework.Core.ILogger _logger;
        /// <summary>
        /// The label service
        /// </summary>
        private ILabelService _labelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="labelService">The label service.</param>
        public LabelController(Framework.Core.ILogger logger, ILabelService labelService)
        {
            _logger = logger;
            _labelService = labelService;
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <returns></returns>      
        [HttpGet]
        public IActionResult GetLabels()
        {          
                _logger.Info(() => "Api GetLabel");
                return StatusCode((int)HttpStatusCode.OK, _labelService.GetLabels());
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<LabelDTO> AddLabel(LabelDTO label)
        {
            _logger.Info(() => "Api AddLabel");
            _labelService.AddLabel(label);
            return StatusCode((int)HttpStatusCode.OK, label);
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<int> DeleteLabel(int id)
        {
            _logger.Info(() => "Api DeleteLabel");           
            return StatusCode((int)HttpStatusCode.OK, _labelService.DeleteLabel(id));
        }
    }
}
