using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
	[Route("api/companies")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		private readonly IServiceManager _service;

		public CompaniesController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetCompanies()
        {
            try
            {
				var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
				return Ok(companies);
            }
            catch
            {
				return StatusCode(500, "Internal server error");
            }
        }
	}
}

