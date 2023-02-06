using Calculator.Common.Helpers.Converter.RomanNumeral;
using Calculator.Domain.Contracts;
using Calculator.Web.Models.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Web.Controllers.Calculator
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _calculatorService.AddNumbers(model.FirstNumber, model.SecoundNumber);
                    model.Result = result;
                    return View(model);
                }
                catch (InvalidRomanNumeralException Ex)
                {
                    model.Result = Ex.Message;
                    return View(model);
                }
            }
            return View(model);
        }

    }
}
