using System;
using MediatR;
using Application.Commands.Company;
using Contracts;
using Entities.Exceptions;
using Application.Notifications;

namespace Application.Handlers.Company
{
	internal sealed class DeleteCompanyHandler : INotificationHandler<CompanyDeletedNotification>
	{
        private readonly IRepositoryManager _repository;

		public DeleteCompanyHandler(IRepositoryManager repository)
		{
            _repository = repository;
		}

        public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
        {
            var company = await _repository.Company.GetCompanyAsync(notification.Id, notification.TrackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(notification.Id);
            }

            _repository.Company.DeleteCompany(company);
            await _repository.SaveAsync();
        }
    }
}

