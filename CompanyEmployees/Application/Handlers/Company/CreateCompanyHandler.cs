using System;
using Application.Commands.Company;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObjects;
using Entities.Models;

namespace Application.Handlers.Company;

internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    private readonly IRepositoryManager _repository; 
    private readonly IMapper _mapper;

    public CreateCompanyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyEntity = _mapper.Map<Entities.Models.Company>(request.Company);

        _repository.Company.CreateCompany(companyEntity);
        await _repository.SaveAsync();

        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
        return companyToReturn;
    }
}

