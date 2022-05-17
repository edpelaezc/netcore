using System;
using Service.Contracts;
using Contracts;
using AutoMapper;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<ICompanyService> _companyService;
		private readonly Lazy<IEmployeeService> _employeeService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			_companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
		}

		public ICompanyService CompanyService => _companyService.Value;
		public IEmployeeService EmployeeService => _employeeService.Value;
	}
}

