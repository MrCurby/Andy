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
        private SubscriptionViewModel? _selectedSubscription = null;
        private bool _editMode;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Subscriptions page initializing.");
            await this.LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Logger.LogInformation("Loading data...");
                var Subs = await SubscriptionService.GetAllSubscriptionsAsync();
                SubscriptionList = SubscriptionMapper.MapToViewModelList(Subs);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while loading data.");
            }
            this.StateHasChanged();
        }

        private void NewSubscription()
        {
            _selectedSubscription = new SubscriptionViewModel();
            _editMode = true;
            this.StateHasChanged();
        }

        private void Edit(SubscriptionViewModel subscription)
        { 
            _selectedSubscription = subscription;
            _editMode = true;
            this.StateHasChanged();
        }

        private async Task DeaktivateAsync(SubscriptionViewModel subscription)
        {
            try
            {
                Logger.LogInformation("Deactivating subscription Id {Id}.", subscription.Id);
                subscription.IsActive = false;
                await this.UpdateSubscriptionAsync(subscription);
                Logger.LogInformation("Subscription Id {Id} deactivated successfully.", subscription.Id);
                await this.LoadDataAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while deactivating subscription Id {Id}.", subscription.Id);
            }
        }

        private async Task AktivateAsync(SubscriptionViewModel subscription)
        {
            try
            {
                Logger.LogInformation("activating subscription Id {Id}.", subscription.Id);
                subscription.IsActive = true;
                await this.UpdateSubscriptionAsync(subscription);
                Logger.LogInformation("Subscription Id {Id} activated successfully.", subscription.Id);
                await this.LoadDataAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while activating subscription Id {Id}.", subscription.Id);
            }
        }

        private async Task Save()
        {
            if (_selectedSubscription == null)
            {
                _editMode = false;
                this.StateHasChanged();
                return;
            }

            try
            {
                await this.LoadDataAsync();

                bool subscriptionExists = SubscriptionList?.Any(s => s.Id == _selectedSubscription.Id) ?? false;

                if (subscriptionExists)
                {
                    await this.UpdateSubscriptionAsync(_selectedSubscription);
                }
                else
                {
                    await this.AddSubscriptionAsync(_selectedSubscription);
                }
            }
            finally
            {
                _editMode = false;

                this.StateHasChanged();

                _selectedSubscription = null;

                await this.LoadDataAsync();

                this.StateHasChanged();
            }
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
                dto.LastUpdated = DateTime.UtcNow;
                await SubscriptionService.UpdateSubscriptionAsync(dto);

                Logger.LogInformation("Subscription Id {Id} updated successfully.", subscription.Id);
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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while adding new subscription with Name '{Name}'.", subscription.Name);
            }
        }

        private async Task DeleteSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            await SubscriptionService.DeleteSubscriptionAsync(subscription?.Id ?? 0);
            _selectedSubscription = null;
            await InvokeAsync(this.LoadDataAsync);
        }

        private void CancelEdit(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
        {
            _selectedSubscription = null;
            _editMode = false;
        }
    }
}
