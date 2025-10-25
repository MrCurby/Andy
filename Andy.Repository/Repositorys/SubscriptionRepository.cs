using Andy.Core;
using Andy.Core.DTOs;
using Andy.Persistent.Mapper;
using Andy.Persistent;
using Andy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
            entity.LastUpdated = DateTime.UtcNow;

            var mapped = _mapper.MapToEntity(subscriptionDto) ?? throw new InvalidOperationException("Mapping returned null for the provided DTO.");
            _dbContext.Entry(entity).CurrentValues.SetValues(mapped);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            if (subscriptionDto == null)
            {
                throw new ArgumentNullException(nameof(subscriptionDto));
            }

            var entity = _mapper.MapToEntity(subscriptionDto) ?? throw new InvalidOperationException("Mapping returned null for the provided DTO.");

            if (entity.CreatedOn == null || entity.CreatedOn == default)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
            entity.LastUpdated = DateTime.UtcNow;

            await _dbContext.Subscriptions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.MapToDto(entity);
        }
    }
}