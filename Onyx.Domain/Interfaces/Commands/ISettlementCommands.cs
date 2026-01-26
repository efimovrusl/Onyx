using Onyx.Domain.Enums;

namespace Onyx.Domain.Interfaces.Commands;

public interface ISettlementCommands
{
    Task SettleDebt(Guid groupId, Guid payerId, Guid receiverId, decimal amount, Currency currency);
}