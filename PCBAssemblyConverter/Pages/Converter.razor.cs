using System.IO.Compression;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Core.Serializers.Csv;
using PCBAssemblyConverter.Core.Serializers.Json;
using PCBAssemblyConverter.Localization;
using PCBAssemblyConverter.Presentation.Csv;
using PCBAssemblyConverter.Presentation.Roles;
using PCBAssemblyConverter.Presentation.Web.Mime;
using PCBAssemblyConverter.Services.IO;
using PCBAssemblyConverter.Shared;
using Radzen;

namespace PCBAssemblyConverter.Pages
{
    public partial class Converter
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; } = default!;
        [Inject]
        LocalizationService LocalizationService { get; set; } = default!;
        [Inject]
        IImportService ImportService { get; set; } = default!;
        [Inject]
        IExportService ExportService { get; set; } = default!;
        [Inject]
        NotificationService NotificationService { get; set; } = default!;
        [Inject]
        DialogService DialogService { get; set; } = default!;

        private EdaTool SelectedEdaTool { get; set; } = EdaTool.KiCad;
        private Manufacturer SelectedManufacturer { get; set; } = Manufacturer.JLC;

        private IEnumerable<IMediaType> EdaBomMediaTypes { get; set; } = [];
        private IEnumerable<IMediaType> EdaPosMediaTypes { get; set; } = [];
        private IMediaType ConversionRuleMediaType { get; set; } = MediaTypes.Json;

        private string SrcBomFileName { get; set; } = string.Empty;
        private string SrcPosFileName { get; set; } = string.Empty;

        private CsvTable SrcBomCsv { get; set; } = new CsvTable();
        private CsvTable SrcPosCsv { get; set; } = new CsvTable();

        private CsvTable DstBomCsv { get; set; } = new CsvTable();
        private CsvTable DstPosCsv { get; set; } = new CsvTable();

        private IEnumerable<Core.Formats.Common.BomEntry> BomEntries { get; set; } = [];
        private IEnumerable<Core.Formats.Common.PosEntry> PosEntries { get; set; } = [];

        private string ConversionRuleFileName { get; set; } = string.Empty;
        private IEnumerable<ConversionRule> ConversionRules { get; set; } = [];

        private bool IsErroredOnBomConverting { get; set; } = false;
        private bool IsErroredOnPosConverting { get; set; } = false;
        private bool IsErroredOnDownloading { get; set; } = false;

        private bool CanConvert()
        {
            return this.BomEntries.Any() && this.PosEntries.Any();
        }

        private bool CanDownload()
        {
            return this.CanConvert() && this.ConversionRules.Any();
        }

        private bool IsValidFile(IBrowserFile browserFile, params IMediaType[] mediaTypes)
        {
            return browserFile.IsAllowedExtension(mediaTypes);
        }

        private bool IsValidFile<TCategory>(IBrowserFile browserFile)
            where TCategory : IDataCategory
        {
            var mediaTypes = this.SelectedEdaTool.ResolveMediaType<TCategory>();

            return this.IsValidFile(browserFile, mediaTypes.ToArray());
        }

        private void OnEdaToolChange(EdaTool tool)
        {
            this.EdaBomMediaTypes = tool.ResolveMediaType<IBomEntry>();
            this.EdaPosMediaTypes = tool.ResolveMediaType<IPosEntry>();
        }

        private async Task ImportFileAsync<TCategory>(IBrowserFile browserFile)
            where TCategory : IDataCategory
        {
            var categoryType = typeof(TCategory);

            if (categoryType != typeof(IBomEntry) && categoryType != typeof(IPosEntry)) throw new ArgumentException($"{categoryType} {this.LocalizationService.Localize.Converter_Error_Message_is_not_supported}", nameof(TCategory));

            if (!this.IsValidFile<TCategory>(browserFile)) throw new Exception($"{browserFile.Name} {this.LocalizationService.Localize.Converter_Error_Message_is_not_supported}");

            try
            {
                var options = CsvOptionsResolver.Resolve(this.SelectedEdaTool.ResolveDataCategory<TCategory>());

                var csvParser = new PlainCsvParser(options);

                using var stream = browserFile.OpenReadStream();

                var buffer = new byte[browserFile.Size];
                buffer.Initialize();
                await stream.ReadExactlyAsync(buffer);

                using var memoryStream = new MemoryStream(buffer);

                if (categoryType == typeof(IBomEntry))
                {
                    this.BomEntries = await this.ImportService.ImportBomEntriesAsync(memoryStream, this.SelectedEdaTool).ToListAsync();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.SrcBomCsv = await csvParser.ParseAsync(memoryStream);

                    this.SrcBomFileName = browserFile.Name;

                    this.NotificationService.Notify(summary: $"{this.LocalizationService.Localize.Converter_Notice_Message_Bom_loaded}");
                }
                else
                {
                    this.PosEntries = await this.ImportService.ImportPosEntriesAsync(memoryStream, this.SelectedEdaTool).ToListAsync();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.SrcPosCsv = await csvParser.ParseAsync(memoryStream);

                    this.SrcPosFileName = browserFile.Name;

                    this.NotificationService.Notify(summary: $"{this.LocalizationService.Localize.Converter_Notice_Message_Pos_loaded}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{this.LocalizationService.Localize.Converter_Error_Message_file_load_failed}", ex);
            }
        }

        private async Task OnInputBomFileChangeAsync(InputFileChangeEventArgs e)
        {
            var file = e.File;

            try
            {
                await this.ImportFileAsync<IBomEntry>(file);
            }
            catch (Exception)
            {
                throw;
            }

            if (!this.ConversionRules.Any())
            {
                var rules = new List<ConversionRule>();

                foreach (var footprint in this.BomEntries.Select(x => x.Footprint).Distinct())
                {
                    rules.Add(new ConversionRule
                    {
                        Name = footprint,
                        Key = footprint,
                        MatchingStrategy = MatchingStrategy.Exact,
                        RuleAction = RuleAction.Convert,
                    });
                }

                this.ConversionRules = rules;
            }
        }

        private async Task OnInputPosFileChangeAsync(InputFileChangeEventArgs e)
        {
            var file = e.File;

            try
            {
                await this.ImportFileAsync<IPosEntry>(file);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task OnInputConversionRuleChangeAsync(InputFileChangeEventArgs e)
        {
            var file = e.File;
            var serializer = new JsonSerializer();

            if (!this.IsValidFile(file, MediaTypes.Json)) throw new Exception($"{this.LocalizationService.Localize.Converter_Error_Message_should_select_json}");

            try
            {
                using var stream = file.OpenReadStream();

                var buffer = new byte[file.Size];
                buffer.Initialize();
                await stream.ReadExactlyAsync(buffer);

                using var memoryStream = new MemoryStream(buffer);
                this.ConversionRules = await serializer.DeserializeAsync<IEnumerable<ConversionRule>>(memoryStream) ?? Enumerable.Empty<ConversionRule>();

                this.ConversionRuleFileName = file.Name;

                this.NotificationService.Notify(summary: $"{this.LocalizationService.Localize.Converter_Notice_Message_ConversionRule_loaded}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{this.LocalizationService.Localize.Converter_Error_Message_ConversionRule_load_failed}", ex);
            }
        }

        private async Task OnConvertAsync()
        {
            if (!this.BomEntries.Any() && !this.PosEntries.Any()) return;

            try
            {
                await this.ExportBomAsync();
                await this.ExportPosAsync();

                if (!this.IsErroredOnBomConverting && !this.IsErroredOnPosConverting)
                {
                    this.NotificationService.Notify(summary: $"{this.LocalizationService.Localize.Converter_Notice_Message_convert_finished}");
                }
            }
            catch
            {
            }
        }

        private async Task ExportBomAsync()
        {
            if (!this.BomEntries.Any()) return;

            try
            {
                this.IsErroredOnBomConverting = false;

                var rules = new ConversionRuleSet(this.ConversionRules);

                using var stream = new MemoryStream();

                await this.ExportService.ExportBomEntriesAsync(stream, this.SelectedManufacturer, this.BomEntries, rules);

                stream.Seek(0, SeekOrigin.Begin);

                var options = CsvOptionsResolver.Resolve(this.SelectedManufacturer.ResolveDataCategory<IBomEntry>());
                var csvParser = new PlainCsvParser(options);
                this.DstBomCsv = await csvParser.ParseAsync(stream);
            }
            catch (Exception ex)
            {
                this.IsErroredOnBomConverting = true;
                this.NotificationService.Notify(NotificationSeverity.Error, $"{this.LocalizationService.Localize.Converter_Error_Message_Bom_convert_failed}", ex.ToString());
                throw;
            }
        }

        private async Task ExportPosAsync()
        {
            if (!this.PosEntries.Any()) return;

            try
            {
                this.IsErroredOnPosConverting = false;

                var rules = new ConversionRuleSet(this.ConversionRules);

                using var stream = new MemoryStream();

                await this.ExportService.ExportPosEntriesAsync(stream, this.SelectedManufacturer, this.PosEntries, rules);

                stream.Seek(0, SeekOrigin.Begin);

                var options = CsvOptionsResolver.Resolve(this.SelectedManufacturer.ResolveDataCategory<IPosEntry>());
                var csvParser = new PlainCsvParser(options);
                this.DstPosCsv = await csvParser.ParseAsync(stream);
            }
            catch (Exception ex)
            {
                this.IsErroredOnPosConverting = true;
                this.NotificationService.Notify(NotificationSeverity.Error, $"{this.LocalizationService.Localize.Converter_Error_Message_Pos_convert_failed}", ex.ToString());
                throw;
            }
        }

        private async Task OnDownloadAsync()
        {
            if (!this.BomEntries.Any() && !this.PosEntries.Any()) return;

            var rules = new ConversionRuleSet(this.ConversionRules);
            var jsonSerializer = new JsonSerializer();

            try
            {
                this.IsErroredOnDownloading = false;

                using var ms = new MemoryStream();

                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var bomEntry = zip.CreateEntry("bom.csv", CompressionLevel.Fastest);
                    await using (var entryStream = bomEntry.Open())
                    {
                        await this.ExportService.ExportBomEntriesAsync(entryStream, this.SelectedManufacturer, this.BomEntries, rules);
                    }

                    var posEntry = zip.CreateEntry("pos.csv", CompressionLevel.Fastest);
                    await using (var entryStream = posEntry.Open())
                    {
                        await this.ExportService.ExportPosEntriesAsync(entryStream, this.SelectedManufacturer, this.PosEntries, rules);
                    }

                    var rulesEntry = zip.CreateEntry("rules.json", CompressionLevel.Fastest);
                    await using (var entryStream = rulesEntry.Open())
                    {
                        await jsonSerializer.SerializeAsync(entryStream, this.ConversionRules);
                    }
                }

                using var streamRef = new DotNetStreamReference(new MemoryStream(ms.ToArray()));
                await JSRuntime.InvokeVoidAsync("downloadFileFromStream", $"converted_{DateTime.Now:yyyyMMddHHmmss}.zip", streamRef);
            }
            catch (Exception ex)
            {
                this.IsErroredOnDownloading = true;
                this.NotificationService.Notify(NotificationSeverity.Error, $"{this.LocalizationService.Localize.Converter_Error_Message_download_file_create_failed}", ex.ToString());
            }
        }

        private async Task OnInfoButtonClick()
        {
            await this.DialogService.OpenAsync<ConversionRuleSpecTable>(
                $"{this.LocalizationService.Localize.ConversionRule_Description_Header}",
                null,
                new DialogOptions
                {
                    CloseDialogOnOverlayClick = true,
                    Width = "80%",
                });
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.SelectedEdaTool = EdaTool.KiCad;
            this.SelectedManufacturer = Manufacturer.JLC;

            this.OnEdaToolChange(EdaTool.KiCad);

            this.LocalizationService.OnLanguageChanged += this.StateHasChanged;
        }
    }
}
