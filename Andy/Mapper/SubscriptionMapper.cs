using Andy.Core;
using Andy.Core.DTOs;
using Andy.ViewModels;
using Riok.Mapperly.Abstractions;

namespace Andy.Mapper
{
    [Mapper]
    public partial class SubscriptionMapper
    {
        public partial SubscriptionViewModel MapToViewModel(SubscriptionDto subscriptionDto);

        public partial IEnumerable<SubscriptionViewModel> MapToViewModelList(IEnumerable<SubscriptionDto> subscriptionDto);
    }
}
