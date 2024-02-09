﻿using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Queries.CheckEmail
{
    public sealed record CheckEmailQuery(string Email) : IQuery;
}
