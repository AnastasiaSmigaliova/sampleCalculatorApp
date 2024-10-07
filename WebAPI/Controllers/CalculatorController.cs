using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;
using WebAPI.Responses;
using WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        // GET: api/<CalculatorController>/add
        [HttpGet("add")]
        public IActionResult Add([FromQuery] CalculatorRequest request)
        {
            try
            {
                var result = _calculatorService.Add(double.Parse(request.X), double.Parse(request.Y));
                return Ok(result);
            }
            catch (OverflowException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        // GET: api/<CalculatorController>/subtract
        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] CalculatorRequest request)
        {
            try
            {
                var result = _calculatorService.Subtract(double.Parse(request.X), double.Parse(request.Y));
                return Ok(result);
            }
            catch (OverflowException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}
