using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Andy.Core.Services
{
    public class SubscitionService(ISubscriptionRepository subscriptionRepository, 
                                   ILogger<SubscitionService> logger) : ISubscitionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository = subscriptionRepository;
        private readonly ILogger<SubscitionService> _logger = logger;

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(GetAllSubscriptionsAsync));

            try
            {
                var result = await _subscriptionRepository.GetAllSubscriptionsAsync();
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(GetAllSubscriptionsAsync));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(GetAllSubscriptionsAsync));
                throw;
            }
        }
    }
}
