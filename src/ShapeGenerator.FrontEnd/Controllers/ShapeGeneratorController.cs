using System;
using System.IO;
using Core.Domain.DTOs;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShapeGenerator.FrontEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShapeGeneratorController : ControllerBase
    {
        private readonly ILogger<ShapeGeneratorController> _logger;
        private readonly INaturalLanguageService naturalLanguageService;

        // Center 400,400 for a 800,800 svg canvas
        private const int center_x = 400;
        private const int center_y = 400;

        public ShapeGeneratorController(ILogger<ShapeGeneratorController> logger, INaturalLanguageService naturalLanguageService)
        {
            _logger = logger;
            this.naturalLanguageService = naturalLanguageService;
        }

        [HttpGet]
        public ApiResult<string> Get([FromQuery] string query)
        {
            try
            {
                var shape = naturalLanguageService.Compile(query, center_x, center_y);
                return new ApiResult<string> { Success = true, Value = shape.ToSvgString() };
            }
            catch (InvalidDataException e)
            {
                return new ApiResult<string> { Success = false, Value = e.Message };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception in ShapeGeneratorController.Get");
                return new ApiResult<string> { Success = false, Value = "The input is invalid" };
            }
        }
    }
}
