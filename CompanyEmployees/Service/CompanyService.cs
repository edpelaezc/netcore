using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
	internal sealed class CompanyService : ICompanyService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

		public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
            _mapper = mapper;
		}

        public IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges)
        {
			var companies = _repository.Company.GetAllCompanines(trackChanges);

			var companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);

			return companiesDTO;
		}

		public CompanyDTO GetCompany(Guid id, bool trackChanges)
        {
			var company = _repository.Company.GetCompany(id, trackChanges);

			if (company is null)
				throw new CompanyNotFoundException(id);

			var companyDTO = _mapper.Map<CompanyDTO>(company);
			return companyDTO;
        }
    }
}

