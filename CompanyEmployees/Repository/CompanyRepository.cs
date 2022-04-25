using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{
		}
	}
}

