using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerWithASPNETCore.WebAPI.Dtos;
using System;

namespace SwaggerWithASPNETCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SandboxController : ControllerBase
    {
        private readonly ILogger<SandboxController> _logger;
        public SandboxController(ILogger<SandboxController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetInitiatedRequestById")]
        public ActionResult GetInitiatedRequestById(int Id)
        {
            try
            {
                //This code was delibrately written to throw exception
                var myIntegerArray = new int[] { 3, 4, 12, 4 };
                var myNumber = myIntegerArray[5];

                return Ok(myNumber);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.InnerException == null ? "" : ex.InnerException.ToString());
                _logger.LogError(ex.StackTrace);

                return BadRequest("An error occurred");
            }
        }

        [HttpPost("InitiatedRequest")]
        public ActionResult InitiatedRequest(RequestDto requestDto)
        {
            try
            {
                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.InnerException == null ? "" : ex.InnerException.ToString());
                _logger.LogError(ex.StackTrace);

                return BadRequest("An error occurred");
            }
        }
    }
}