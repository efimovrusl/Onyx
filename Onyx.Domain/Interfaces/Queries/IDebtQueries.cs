using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Queries;

public interface IDebtQueries
{
    Task<decimal> GetTotalGroupDebt(Guid userId, Guid groupId);
    Task<decimal> GetTotalGroupOwed(Guid userId, Guid groupId);
    
    Task<List<(User user, decimal debt)>> GetGroupDebts(Guid groupId, Guid userId);
    // Task<List<(User user, decimal debt)>> GetGlobalDebts(Guid userId);
}