using Andy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Core.Interfaces
{
    public interface ISubscitionService
    {
        /// <summary>
        /// Asynchronously retrieves all subscriptions.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains an <see cref="IEnumerable{T}"/> of <see cref="SubscriptionDto"/>.
        /// </returns>
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();

        /// <summary>
        /// Asynchronously updates the details of an existing subscription.
        /// </summary>
        /// <param name="subscriptionDto">An object containing the updated subscription information. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task UpdateSubscriptionAsync(SubscriptionDto subscriptionDto);
    }
}
