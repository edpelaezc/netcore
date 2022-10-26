namespace Shared.DataTransferObjects;

public record CompanyForUpdateDTO : CompanyForManipulationDTO
{
    public IEnumerable<EmployeeForCreationDTO>? Employees { get; init; }
}
