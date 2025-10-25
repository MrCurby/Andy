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
        public partial SubscriptionDto MapToDto(Subscription subscription);

        public partial IEnumerable<SubscriptionDto> MapToDtoList(IEnumerable<Subscription> subscriptions);

        public partial Subscription MapToEntity(SubscriptionDto subscriptionDto);

        public partial IEnumerable<Subscription> MapToEntityList(IEnumerable<SubscriptionDto> subscriptionsDtos);
    }
}