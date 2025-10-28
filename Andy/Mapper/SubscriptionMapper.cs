using Andy.Core;
using Andy.Core.DTOs;
using Andy.ViewModels;
using Riok.Mapperly.Abstractions;

namespace Andy.Mapper
{
    [Mapper]
    public partial class SubscriptionMapper
    {
        /// <summary>
        /// Maps a SubscriptionDto object to a SubscriptionViewModel instance.
        /// </summary>
        /// <param name="subscriptionDto">The SubscriptionDto object containing subscription data to be mapped. Cannot be null.</param>
        /// <returns>A SubscriptionViewModel instance populated with data from the specified SubscriptionDto.</returns>
        public partial SubscriptionViewModel MapToViewModel(SubscriptionDto subscriptionDto);

        /// <summary>
        /// Maps a collection of subscription data transfer objects to a collection of subscription view models.
        /// </summary>
        /// <param name="subscriptionDto">The collection of subscription data transfer objects to convert. Cannot be null.</param>
        /// <returns>An enumerable collection of subscription view models corresponding to the input data transfer objects.</returns>
        public partial IEnumerable<SubscriptionViewModel> MapToViewModelList(IEnumerable<SubscriptionDto> subscriptionDto);

        /// <summary>
        /// Maps a SubscriptionViewModel object to a SubscriptionDto instance.
        /// </summary>
        /// <param name="subscriptionViewModel">The SubscriptionViewModel object containing subscription data to be mapped. Cannot be null.</param>
        /// <returns>A SubscriptionDto instance populated with data from the specified SubscriptionViewModel.</returns>
        public partial SubscriptionDto MapToDto(SubscriptionViewModel subscriptionViewModel);

        /// <summary>
        /// Maps a collection of subscription view models to a collection of subscription data transfer objects.
        /// </summary>
        /// <param name="subscriptionViewModel">The collection of subscription view models to convert. Cannot be null.</param>
        /// <returns>An enumerable collection of subscription data transfer objects corresponding to the input view models.</returns>
        public partial IEnumerable<SubscriptionDto> MapToDtoList(IEnumerable<SubscriptionViewModel> subscriptionViewModel);
    }
}
