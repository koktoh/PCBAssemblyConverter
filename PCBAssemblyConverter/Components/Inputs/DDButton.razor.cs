using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Radzen;

namespace PCBAssemblyConverter.Components.Inputs
{
    public partial class DDButton : RadzenComponent
    {
        [Parameter]
        public Orientation Orientation { get; set; } = Orientation.Vertical;

        [Parameter]
        public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Light;

        [Parameter]
        public bool IsBusy { get; set; }

        [Parameter]
        public bool Multiple { get; set; }

        [Parameter]
        public string Icon { get; set; } = "upload_file";

        [Parameter]
        public string Text { get; set; } = string.Empty;

        [Parameter]
        public string Description { get; set; } = "Drop files here or click to select";

        [Parameter]
        public string SubDescription { get; set; } = string.Empty;

        [Parameter]
        public string Accept { get; set; } = ".*";

        [Parameter]
        public EventCallback<InputFileChangeEventArgs> OnChange { get; set; }

        private InputFile InputFileRef { get; set; } = default!;

        private string ManinLabelTextSize { get; set; } = "font-size: 1.2rem;";

        private string SubDescriptionLabelTextSize { get; set; } = "font-size: 0.9rem;";

        private string ErrorMessage { get; set; } = string.Empty;

        private string BorderStyle()
        {
            var styleBase = "border: dashed 2px ";
            return this.ButtonStyle switch
            {
                ButtonStyle.Primary => styleBase + "var(--rz-primary);",
                ButtonStyle.Secondary => styleBase + "var(--rz-secondary);",
                ButtonStyle.Base => styleBase + "var(--rz-base-700);",
                ButtonStyle.Info => styleBase + "var(--rz-info);",
                ButtonStyle.Success => styleBase + "var(--rz-success);",
                ButtonStyle.Warning => styleBase + "var(--rz-warning);",
                ButtonStyle.Danger => styleBase + "var(--rz-danger);",
                ButtonStyle.Light => styleBase + "var(--rz-base-dark);",
                ButtonStyle.Dark => styleBase + "var(--rz-base-light);",
                _ => styleBase + "var(--rz-primary);"
            };
        }

        private async Task OnClickAsync()
        {
            if (this.JSRuntime is null) return;

            await this.JSRuntime.InvokeVoidAsync("triggerClick", this.InputFileRef.Element);
        }

        private async Task OnInputFileChangeAsync(InputFileChangeEventArgs e)
        {
            if (this.IsBusy) return;

            try
            {
                this.ErrorMessage = string.Empty;
                this.IsBusy = true;
                await this.OnChange.InvokeAsync(e);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
