using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<ICompanyRepository> _companyRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		_companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
	}

	public ICompanyRepository Company => _companyRepository.Value;

	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
