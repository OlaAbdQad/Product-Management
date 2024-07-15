using Assessment_Task.Dtos;
using Assessment_Task.Entities;

namespace Assessment_Task.Service.Contracts
{
    public interface IBlacklistedTokenService
    {
        Task<bool> CheckIfTokenIsBlacklisted(string token);
        Task AddAsync(string token);
        
    }
}