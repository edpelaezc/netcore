namespace Shared.DataTransferObjects;

public record CompanyForCreationDTO : CompanyForManipulationDTO
{
    public IEnumerable<EmployeeForCreationDTO>? Employees { get; init; }
}
