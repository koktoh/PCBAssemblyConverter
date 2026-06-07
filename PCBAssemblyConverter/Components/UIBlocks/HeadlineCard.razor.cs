using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace PCBAssemblyConverter.Components.UIBlocks
{
    public partial class HeadlineCard : RadzenCard
    {
        [Parameter]
        public string Header { get; set; } = string.Empty;

        [Parameter]
        public TextStyle HeaderStyle { get; set; } = TextStyle.H5;

        [Parameter]
        public bool ShowInfoButton { get; set; } = false;

        [Parameter]
        public EventCallback InfoButtonClick { get; set; } = EventCallback.Empty;

        private async Task OnInfoButtonClick()
        {
            await this.InfoButtonClick.InvokeAsync(null);
        }
    }
}
