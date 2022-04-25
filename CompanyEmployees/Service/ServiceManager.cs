using System;
using Service.Contracts;
using Contracts;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<ICompanyService> _companyService;
		private readonly Lazy<IEmployeeService> _employeeService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
		{
			_companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger));
		}

		public ICompanyService CompanyService => _companyService.Value;
		public IEmployeeService EmployeeService => _employeeService.Value;
	}
}

