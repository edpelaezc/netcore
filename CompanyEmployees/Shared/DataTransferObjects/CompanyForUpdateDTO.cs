using System;
namespace Shared.DataTransferObjects
{
    public record CompanyForUpdateDTO(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDTO> Employees);
}

