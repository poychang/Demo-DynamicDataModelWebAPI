using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoDynamicDataModelWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }

        // POST /form/{type}/
        [HttpPost]
        [Route("{type}")]
        public IActionResult Data([FromRoute] string type, [FromBody] dynamic query)
        {
            return type switch
            {
                "BForm" => Ok($"{(string)query.Title} - {(string)query.Description}"),
                "AForm" => Ok($"{(string)query.Name} {query.Number}"),
                _ => Ok("Not support this form."),
            };
        }
    }
}
