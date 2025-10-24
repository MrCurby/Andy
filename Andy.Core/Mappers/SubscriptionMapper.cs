using Riok.Mapperly.Abstractions;
using Andy.Core.DTOs;
using Andy.Core;
using System.Collections.Generic;
using System.Linq;

namespace Andy.Core.Mappers
{
    [Mapper]
    public partial class SubscriptionMapper
    {
        public partial SubscriptionDto MapToDto(Subscription subscription);

        public partial IEnumerable<SubscriptionDto> MapToDtoList(IEnumerable<Subscription> subscriptions);
    }
}