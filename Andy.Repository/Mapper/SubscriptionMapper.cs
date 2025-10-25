using Riok.Mapperly.Abstractions;
using Andy.Core.DTOs;
using Andy.Core;
using System.Collections.Generic;
using System.Linq;

namespace Andy.Persistent.Mapper
{
    [Mapper]
    public partial class SubscriptionMapper
    {
        /// <summary>
        /// Converts a Subscription domain model instance to its corresponding SubscriptionDto data transfer object.
        /// </summary>
        /// <param name="subscription">The Subscription instance to convert. Cannot be null.</param>
        /// <returns>A SubscriptionDto object that represents the data from the specified Subscription instance.</returns>
        public partial SubscriptionDto MapToDto(Subscription subscription);

        /// <summary>
        /// Maps a collection of Subscription domain entities to their corresponding SubscriptionDto data transfer
        /// objects.
        /// </summary>
        /// <param name="subscriptions">The collection of Subscription entities to be mapped. Cannot be null.</param>
        /// <returns>An enumerable collection of SubscriptionDto objects representing the mapped data from the input
        /// subscriptions. The collection will be empty if the input contains no elements.</returns>
        public partial IEnumerable<SubscriptionDto> MapToDtoList(IEnumerable<Subscription> subscriptions);

        /// <summary>
        /// Converts a SubscriptionDto object to its corresponding Subscription entity.
        /// </summary>
        /// <param name="subscriptionDto">The data transfer object containing subscription information to be mapped. Cannot be null.</param>
        /// <returns>A Subscription entity populated with values from the specified SubscriptionDto.</returns>
        public partial Subscription MapToEntity(SubscriptionDto subscriptionDto);

        /// <summary>
        /// Maps a collection of subscription data transfer objects to a collection of subscription entities.
        /// </summary>
        /// <param name="subscriptionsDtos">The collection of subscription data transfer objects to convert. Cannot be null.</param>
        /// <returns>An enumerable collection of subscription entities mapped from the provided data transfer objects.</returns>
        public partial IEnumerable<Subscription> MapToEntityList(IEnumerable<SubscriptionDto> subscriptionsDtos);
    }
}