using System;
using Application.Notifications;
using Contracts;
using MediatR;

namespace Application.Handlers.Company
{
    internal sealed class EmailHandler : INotificationHandler<CompanyDeletedNotification>
    {
        private readonly ILoggerManager _logger;

		public EmailHandler(ILoggerManager logger)
		{
            _logger = logger;
		}

        public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogWarn($"Delete action was completed for company with id: {notification.Id}");

            await Task.CompletedTask;
        }
    }
}

