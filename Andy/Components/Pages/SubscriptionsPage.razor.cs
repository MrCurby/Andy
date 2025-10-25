using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Andy.Components.Pages
{
    public partial class SubscriptionsPage
    {
        [Inject]
        protected ISubscitionService SubscriptionService { get; set; } = default!;

        [Inject]
        protected ILogger<SubscriptionsPage> Logger { get; set; } = default!;
        protected IEnumerable<SubscriptionDto>? Subscriptions;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Subscriptions page initializing.");
            Subscriptions = await SubscriptionService.GetAllSubscriptionsAsync();
        }
    }
}
