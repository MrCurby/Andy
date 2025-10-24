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
    }
}
