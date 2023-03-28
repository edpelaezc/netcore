using System;
using Service.Contracts;
using Contracts;
using AutoMapper;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Entities.Models;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<ICompanyService> _companyService;
		private readonly Lazy<IEmployeeService> _employeeService;
		private readonly Lazy<IAuthenticationService> _authenticationService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IEmployeeLinks employeeLinks, UserManager<User> userManager, IConfiguration configuration)
		{
			_companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
			_employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
			_authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, logger, mapper, configuration));
		}

		public ICompanyService CompanyService => _companyService.Value;
		public IEmployeeService EmployeeService => _employeeService.Value;
		public IAuthenticationService AuthenticationService => _authenticationService.Value;
	}
}

