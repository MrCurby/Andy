using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Andy.Mapper;
using Andy.ViewModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Andy.Components.Pages
{
    public partial class SubscriptionsPage
    {
        [Inject] protected ISubscitionService SubscriptionService { get; set; } = default!;
        [Inject] protected ILogger<SubscriptionsPage> Logger { get; set; } = default!;
        [Inject] protected SubscriptionMapper SubscriptionMapper { get; set; } = default!;
        protected IEnumerable<SubscriptionViewModel>? SubscriptionList;
        private SubscriptionViewModel? _selectedSubscription;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Subscriptions page initializing.");
            await this.LoadData();
        }

        private async Task LoadData()
        {
            var Subs = await SubscriptionService.GetAllSubscriptionsAsync();
            SubscriptionList = SubscriptionMapper.MapToViewModelList(Subs);
            this.StateHasChanged();
        }

        private async Task UpdateSubscriptionAsync(SubscriptionViewModel? subscription)
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

                await this.LoadData();

                Logger.LogInformation("Subscription Id {Id} updated successfully.", subscription.Id);
                this.StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while updating subscription Id {Id}.", subscription.Id);
            }
        }

        private async Task AddSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            if (subscription is null)
            {
                Logger.LogWarning("AddSubscriptionAsync called with null subscription.");
                return;
            }

            try
            {
                Logger.LogInformation("Adding new subscription with Name '{Name}'.", subscription.Name);

                var dto = SubscriptionMapper.MapToDto(subscription);
                var createdDto = await SubscriptionService.AddSubscriptionAsync(dto);

                Logger.LogInformation("Subscription created with Id {Id}.", createdDto?.Id);
                await this.LoadData();

                Logger.LogInformation("New subscription added successfully.");
                this.StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while adding new subscription with Name '{Name}'.", subscription.Name);
            }
        }
    }
}
