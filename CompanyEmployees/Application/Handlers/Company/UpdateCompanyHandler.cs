using System;
using MediatR;
using Application.Commands.Company;
using Contracts;
using AutoMapper;
using Entities.Exceptions;

namespace Application.Handlers.Company
{
	internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
	{
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

		public UpdateCompanyHandler(IRepositoryManager repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _repository.Company.GetCompanyAsync(request.Id, request.TrackChanges);

            if (companyEntity is null)
            {
                throw new CompanyNotFoundException(request.Id);
            }

            _mapper.Map(request.Company, companyEntity);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}

