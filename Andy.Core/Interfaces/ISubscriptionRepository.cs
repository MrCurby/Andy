using Andy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Core.Interfaces
{
    public partial interface ISubscriptionRepository
    {
        /// <summary>
        /// Asynchronously retrieves all available subscriptions.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see
        /// cref="SubscriptionDto"/> objects representing all subscriptions. The collection is empty if no subscriptions
        /// are found.</returns>
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();

        /// <summary>
        /// Updates the details of an existing subscription asynchronously.
        /// </summary>
        /// <param name="subscriptionDto">An object containing the updated subscription information. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task UpdateSubscriptionAsync(SubscriptionDto subscriptionDto);

        /// <summary>
        /// Asynchronously adds a new subscription using the specified subscription details.
        /// </summary>
        /// <param name="subscriptionDto">An object containing the details of the subscription to add. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a SubscriptionDto representing
        /// the newly created subscription.</returns>
        Task<SubscriptionDto> AddSubscriptionAsync(SubscriptionDto subscriptionDto);
    }
}
