using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Queries.CheckPhoneNumber
{
    public sealed record CheckPhoneNumberQuery(string PhoneNumber) : IQuery;
}
