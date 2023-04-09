using System;
using MediatR;

namespace Application.Notifications;

public sealed record CompanyDeletedNotification(Guid Id, bool TrackChanges) : INotification;