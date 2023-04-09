using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Shared.DataTransferObjects;
using Application.Queries.Company;
using Application.Commands.Company;
using Application.Notifications;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public CompaniesController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _sender.Send(new GetCompaniesQuery(TrackChanges: false));

        return Ok(companies);
    }

    [HttpGet("{id:guid}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _sender.Send(new GetCompanyQuery(id, false));

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreationDto)
    {
        var company = await _sender.Send(new CreateCompanyCommand(companyForCreationDto));

        return CreatedAtRoute("CompanyById", new { id = company.Id }, company);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto companyForUpdateDto)
    {
        if (companyForUpdateDto is null)
        {
            return BadRequest("CompanyForUpdateDto is null");
        }

        await _sender.Send(new UpdateCompanyCommand(id, companyForUpdateDto, true));

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _publisher.Publish(new CompanyDeletedNotification(id, TrackChanges: false));
        return NoContent();
    }
}
