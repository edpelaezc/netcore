namespace Shared.DataTransferObjects;

public record CompanyDto
{
	public Guid Id { get; init; }
	public string? Name { get; init; }
	public string? FullAddress { get; init; }
}
