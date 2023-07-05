using Application.People.Commands;
using FluentValidation.Results;
using FluentValidation.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            await _mediator.Send(command);
            

            return NoContent();
        }

        public IActionResult Index()
        {
            try
            {
                // Exception fırlatan bir kod parçası
                int a = 10;
                int b = 0;
                int result = a / b;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata yakalandı: " + ex.Message);
                throw;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            // Örnek doğrulama hataları oluştur
            var failures = new List<ValidationFailure>()
            {
                new ValidationFailure("Property1", "Error 1"),
                new ValidationFailure("Property2", "Error 2"),
                new ValidationFailure("Property2", "Error 3")
            };

            // ValidationException fırlat
            throw new Application.Common.Exceptions.ValidationException(failures);
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}