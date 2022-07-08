using System;
namespace Shared.DataTransferObjects
{
    public record EmployeeDTO
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public int Age { get; init; }
        public string? Position { get; init; }
    }
}

