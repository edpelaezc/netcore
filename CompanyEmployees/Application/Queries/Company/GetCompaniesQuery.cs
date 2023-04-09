using System;
using MediatR;
using Shared.DataTransferObjects;
using Contracts;

namespace Application.Queries.Company;

public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;

