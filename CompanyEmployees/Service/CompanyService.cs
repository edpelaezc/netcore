using System;
using AutoMapper;
using Contracts;
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
    }
}

