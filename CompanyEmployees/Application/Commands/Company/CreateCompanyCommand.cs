using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands.Company;

public sealed record CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;
