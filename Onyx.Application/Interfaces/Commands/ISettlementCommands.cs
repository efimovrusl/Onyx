using Onyx.Domain.Enums;

namespace Onyx.Application.Interfaces.Commands;

public interface ISettlementCommands
{
    [Obsolete("Not implemented yet")]
    Task SettleDebt(Guid groupId, Guid payerId, Guid receiverId, decimal amount, Currency currency);
}