using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

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

        public async Task UpdateSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(UpdateSubscriptionAsync));

            try
            {
                await _subscriptionRepository.UpdateSubscriptionAsync(subscriptionDto);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(UpdateSubscriptionAsync));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(UpdateSubscriptionAsync));
                throw;
            }
        }

        public async Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(AddSubscriptionAsync));

            if (subscriptionDto == null)
            {
                throw new ArgumentNullException(nameof(subscriptionDto));
            }

            try
            {
                var created = await _subscriptionRepository.AddSubscriptionAsync(subscriptionDto);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(AddSubscriptionAsync));
                return created;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(AddSubscriptionAsync));
                throw;
            }
        }

        public async Task DeleteSubscriptionAsync(int subscriptionId)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(DeleteSubscriptionAsync));
            try
            {
                await _subscriptionRepository.DeleteSubscriptionAsync(subscriptionId);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(DeleteSubscriptionAsync));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(DeleteSubscriptionAsync));
                throw;
            }
        }
    }
}
