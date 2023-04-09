using System;
using MediatR;

namespace Application.Commands.Company;

public record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest<Unit>;

