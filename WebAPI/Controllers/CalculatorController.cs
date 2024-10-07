using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;
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
            var result = _calculatorService.Add(double.Parse(request.X), double.Parse(request.Y));
            return Ok(result);
        }
        // GET: api/<CalculatorController>/substract
        [HttpGet("substract")]
        public IActionResult Substract([FromQuery] CalculatorRequest request)
        {
            var result = _calculatorService.Substract(double.Parse(request.X), double.Parse(request.Y));
            return Ok(result);
        }
    }
}
