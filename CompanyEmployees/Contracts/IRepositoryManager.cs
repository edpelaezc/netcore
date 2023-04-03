namespace Contracts;

public interface IRepositoryManager
{
	ICompanyRepository Company { get; }
	Task SaveAsync();
}
