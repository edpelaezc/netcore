using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
	[Route("api/companies/{companyId}/employees")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IServiceManager _service;

		public EmployeesController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetEmployeesForCompany(Guid companyId)
		{
			var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);
			return Ok(employees);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
		{
			var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
			return Ok(employee);
		}
	}
}

