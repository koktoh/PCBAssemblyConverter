using Microsoft.AspNetCore.Components;
using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Localization;
using Radzen.Blazor;

namespace PCBAssemblyConverter.Components.DataGrid
{
    public partial class ConversionRuleGrid
    {
        [Inject]
        LocalizationService LocalizationService { get; set; } = default!;

        [Parameter]
        public IEnumerable<ConversionRule> Rules { get; set; } = default!;

        [Parameter]
        public EventCallback<IEnumerable<ConversionRule>> RulesChanged { get; set; }

        private RadzenDataGrid<ConversionRule> RulesGridRef { get; set; } = default!;

        private bool _isEditing = false;

        private List<ConversionRule> _editingRules = [];

        private async Task RefreshGrid()
        {
            await this.RulesGridRef.Reload();
        }

        private async Task EditButtonClick()
        {
            this._editingRules = this.Rules.Select(x => x with { }).ToList();
            this._isEditing = true;
            await this.RefreshGrid();
        }

        private async Task SaveButtonClick()
        {
            await this.RulesChanged.InvokeAsync(this._editingRules.Select(x => x with { }).ToList());

            this._isEditing = false;

            await this.RefreshGrid();
        }

        private async Task CancelButtonClick()
        {
            this._isEditing = false;

            await this.RefreshGrid();
        }

        private async Task DeleteRow(ConversionRule rule)
        {
            if (!this._editingRules.Contains(rule)) return;

            this._editingRules.Remove(rule);

            await this.RefreshGrid();
        }

        private async Task InsertAfterRow(ConversionRule row)
        {
            if (row is null) return;

            var index = this._editingRules.IndexOf(row);
            this._editingRules.Insert(index + 1, new ConversionRule());
            await this.RefreshGrid();
        }
    }
}
