using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries.Company;

public sealed record GetCompanyQuery(Guid Id, bool TrackChanges) : IRequest<CompanyDto>;

