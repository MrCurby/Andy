using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Andy.Mapper;
using Andy.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace Andy.Components.Pages
{
    public partial class SubscriptionsPage
    {
        protected IEnumerable<SubscriptionViewModel>? SubscriptionList;
        private SubscriptionViewModel? _selectedSubscription = null;
        private bool _editMode;
        private bool _dialogHidden = true;

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

        private async Task OpenEditorResponsive()
        {
            _editMode = true;
            var width = await JSRuntime.InvokeAsync<int>("eval", "window.innerWidth");

            if (width < 960)
            {
                _dialogHidden = false;
            }
            else
            {
                _dialogHidden = true;
            }
        }

        private async Task NewSubscription()
        {
            _selectedSubscription = new SubscriptionViewModel();
            await this.OpenEditorResponsive();
        }

        private async Task Edit(SubscriptionViewModel subscription)
        {
            _selectedSubscription = subscription;
            await this.OpenEditorResponsive();
        }

        private async Task DeaktivateAsync(SubscriptionViewModel subscription)
        {
            try
            {
                subscription.IsActive = false;
                await this.UpdateSubscriptionAsync(subscription);
                await this.LoadDataAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error deactivating subscription.");
            }
        }

        private async Task AktivateAsync(SubscriptionViewModel subscription)
        {
            try
            {
                subscription.IsActive = true;
                await this.UpdateSubscriptionAsync(subscription);
                await this.LoadDataAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error activating subscription.");
            }
        }

        private async Task SaveAsync()
        {
            if (_selectedSubscription == null) { _editMode = false; return; }

            try
            {
                if (_selectedSubscription.Id <= 0)
                    await this.AddSubscriptionAsync(_selectedSubscription);
                else
                    await this.UpdateSubscriptionAsync(_selectedSubscription);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while saving subscription.");
            }
            finally
            {
                await this.CloseEditor();
            }
        }

        private async Task CancelEdit()
        {
            await this.CloseEditor();
        }

        private async Task CloseEditor()
        {
            _dialogHidden = true;
            _editMode = false;
            _selectedSubscription = null;

            await this.LoadDataAsync();
            await this.InvokeAsync(StateHasChanged);
        }

        private async Task UpdateSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            if (subscription is null) return;
            var dto = SubscriptionMapper.MapToDto(subscription);
            dto.LastUpdated = DateTime.UtcNow;
            await SubscriptionService.UpdateSubscriptionAsync(dto);
        }

        private async Task AddSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            if (subscription is null) return;
            var dto = SubscriptionMapper.MapToDto(subscription);
            await SubscriptionService.AddSubscriptionAsync(dto);
        }

        private async Task DeleteSubscriptionAsync(SubscriptionViewModel? subscription)
        {
            if (subscription == null) return;
            await SubscriptionService.DeleteSubscriptionAsync(subscription.Id);

            if (_selectedSubscription?.Id == subscription.Id)
            {
                await this.CloseEditor();
            }
            else
            {
                await this.InvokeAsync(this.LoadDataAsync);
            }
        }
    }
}
