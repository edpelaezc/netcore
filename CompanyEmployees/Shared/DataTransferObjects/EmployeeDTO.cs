using System;
namespace Shared.DataTransferObjects
{
    public record EmployeeDTO(Guid Id, string Name, int Age, string Position);
}

