using Andy.Core.DTOs;
using Andy.Core.Interfaces;

namespace Andy.Core.Services
{
    public class SubscitionService : ISubscitionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscitionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            try
            {
                return await _subscriptionRepository.GetAllSubscriptionsAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
