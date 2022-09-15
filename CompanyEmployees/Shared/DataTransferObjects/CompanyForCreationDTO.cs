using System;
namespace Shared.DataTransferObjects
{
    public record CompanyForCreationDTO(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDTO> Employees);
}

