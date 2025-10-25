using Andy.Core;
using Andy.Core.DTOs;
using Andy.Persistent.Mapper;
using Andy.Persistent;
using Andy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Andy.Persistent.Repositorys
{
    public class SubscriptionRepository(AndyDbContext dbContext, SubscriptionMapper mapper) : ISubscriptionRepository
    {
        private readonly AndyDbContext _dbContext = dbContext;
        private readonly SubscriptionMapper _mapper = mapper;

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subs = await _dbContext.Subscriptions.ToListAsync();
            return _mapper.MapToDtoList(subs);
        }

        public async Task UpdateSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            var entity = await _dbContext.Subscriptions.FindAsync(subscriptionDto.Id);

            if (entity == null)
            {
                return;
            }
                
            var mapped = _mapper.MapToEntity(subscriptionDto) ?? throw new InvalidOperationException("Mapping returned null for the provided DTO.");
            _dbContext.Entry(entity).CurrentValues.SetValues(mapped);

            await _dbContext.SaveChangesAsync();
        }
    }
}