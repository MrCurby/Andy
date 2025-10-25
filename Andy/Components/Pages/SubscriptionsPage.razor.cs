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

        protected async Task UpdateSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            if (subscription is null)
            {
                Logger.LogWarning("UpdateSubscriptionAsync called with null subscription.");
                return;
            }

            try
            {
                Logger.LogInformation("Updating subscription Id {Id}.", subscription.Id);
                var dto = SubscriptionMapper.MapToDto(subscription);
                await SubscriptionService.UpdateSubscriptionAsync(dto);

                var subs = await SubscriptionService.GetAllSubscriptionsAsync();
                Subscriptions = SubscriptionMapper.MapToViewModelList(subs);

                Logger.LogInformation("Subscription Id {Id} updated successfully.", subscription.Id);
                this.StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while updating subscription Id {Id}.", subscription.Id);
            }
        }
    }
}
