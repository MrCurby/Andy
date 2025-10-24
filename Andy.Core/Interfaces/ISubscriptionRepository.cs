using Andy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Core.Interfaces
{
    public partial interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
    }
}
