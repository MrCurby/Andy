using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Andy.Components.Pages
{
    public partial class Subscriptions
    {
        [Inject]
        protected ISubscitionService SubscriptionService { get; set; } = default!;

        [Inject]
        protected ILogger<Subscriptions> Logger { get; set; } = default!;
        protected IEnumerable<SubscriptionDto>? subscriptions;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Subscriptions page initializing.");
            subscriptions = await SubscriptionService.GetAllSubscriptionsAsync();
        }
    }
}
