using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Andy.Mapper;
using Andy.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Andy.Components.Pages
{
    public partial class SubscriptionsPage
    {
        [Inject]
        protected ISubscitionService SubscriptionService { get; set; } = default!;

        [Inject]
        protected ILogger<SubscriptionsPage> Logger { get; set; } = default!;

        [Inject]
        protected SubscriptionMapper SubscriptionMapper { get; set; } = default!;

        protected IEnumerable<SubscriptionViewModel>? Subscriptions;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Subscriptions page initializing.");
            var Subs = await SubscriptionService.GetAllSubscriptionsAsync();
            Subscriptions = SubscriptionMapper.MapToViewModelList(Subs);
        }
    }
}
