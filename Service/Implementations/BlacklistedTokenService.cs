using Assessment_Task.Dtos;
using Assessment_Task.Entities;
using Assessment_Task.Repository.Contracts;
using Assessment_Task.Service.Contracts;
using Mapster;

namespace Assessment_Task.Service.Implementations
{
    public class BlacklistedTokenService : IBlacklistedTokenService
    {
        private readonly IGenericRepository<BlacklistedToken> _repo;

        public BlacklistedTokenService(IGenericRepository<BlacklistedToken>  repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string token)
        {
            var blacklistedToken = new BlacklistedToken{Token = token};
            await _repo.AddAsync(blacklistedToken);
        }

        public async Task<bool> CheckIfTokenIsBlacklisted(string token)
        {
            return await _repo.GetAsync(a => a.Token == token) != null ? true : false;
            
        }

       
    }
}