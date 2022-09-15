using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

		public CompanyDTO CreateCompany(CompanyForCreationDTO company)
        {
			var companyEntity = _mapper.Map<Company>(company);

			_repository.Company.CreateCompany(companyEntity);
			_repository.Save();

			var companyToReturn = _mapper.Map<CompanyDTO>(companyEntity);

			return companyToReturn;
        }

		public IEnumerable<CompanyDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
			if (ids is null)
				throw new IdParametersBadRequestException();

			var companyEntities = _repository.Company.GetByIds(ids, trackChanges);

            if (ids.Count() != companyEntities.Count())
				throw new CollectionByIdsBadRequestException();

			var companiesToReturn = _mapper.Map<IEnumerable<CompanyDTO>>(companyEntities);
			return companiesToReturn;
		}

		public (IEnumerable<CompanyDTO> companies, string ids) CreateCompanyCollection
			(IEnumerable<CompanyForCreationDTO> companyCollection)
        {
			if (companyCollection is null)
				throw new CompanyCollectionBadRequest();

			var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);

            foreach (var company in companyEntities)
            {
				_repository.Company.CreateCompany(company);
            }

			_repository.Save();

			var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDTO>>(companyEntities);

			var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

			return(companies: companyCollectionToReturn, ids: ids);
		}

		public void DeleteCompany(Guid companyId, bool trackChanges)
        {
			var company = _repository.Company.GetCompany(companyId, trackChanges);

			if (company is null)
				throw new CompanyNotFoundException(companyId);

			_repository.Company.DeleteCompany(company);
			_repository.Save();
        }
	}
}

