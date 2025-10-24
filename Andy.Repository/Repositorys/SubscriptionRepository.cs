using Andy.Core;
using Andy.Core.DTOs;
using Andy.Core.Mappers;
using Andy.Persistent;
using Andy.Core.Interfaces;
namespace Andy.Persistent.Repositorys
{
    public class SubscriptionRepository(AndyDbContext dbContext, SubscriptionMapper mappers) : ISubscriptionRepository
    {
        private readonly AndyDbContext _dbContext = dbContext;
        private readonly SubscriptionMapper _mapper = mappers;

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subs = _dbContext.Subscriptions;
            return _mapper.MapToDtoList(subs);
        }
    }
}