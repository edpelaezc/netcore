using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

		[HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
		public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
		{
			var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
			return Ok(employee);
		}

		[HttpPost]
		public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDTO employee)
        {
			if (employee is null)
				return BadRequest("EmployeeForCreationDTO object is null");

			// atributte validations
			if (!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

			var employeeResponse = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, false);

			return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeResponse.Id}, employeeResponse);
        }

		[HttpDelete("{id:guid}")]
		public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
		{
			_service.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges: false);
			return NoContent();
		}

        [HttpPut("{id:guid}")]
		public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDTO employee)
		{
			if (employee is null)
				return BadRequest("EmployeeForUpdateDTO object is null");

			if (!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

			_service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);

			return NoContent();
		}

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id,
		[FromBody] JsonPatchDocument<EmployeeForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.EmployeeService.GetEmployeeForPatch(companyId, id, compTrackChanges: false,
                empTrackChanges: true);

            patchDoc.ApplyTo(result.employeeToPatch, ModelState);

			// validate correct objects before to save in db
			TryValidateModel(result.employeeToPatch);

			if (!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

            _service.EmployeeService.SaveChangesForPatch(result.employeeToPatch, result.employeeEntity);

            return NoContent();
        }
    }
}

