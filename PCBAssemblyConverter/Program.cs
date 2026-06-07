using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PCBAssemblyConverter;
using PCBAssemblyConverter.Core.Converters;
using PCBAssemblyConverter.Core.Converters.JLC;
using PCBAssemblyConverter.Core.Converters.KiCad;
using PCBAssemblyConverter.Localization;
using PCBAssemblyConverter.Services.IO;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddRadzenComponents();

builder.Services.AddSingleton(new LocalizationService());

var converterProvider = new ConverterProvider();
converterProvider.Register(new KiCadToCommonBomConverter());
converterProvider.Register(new KiCadToCommonPosConverter());
converterProvider.Register(new CommonToJlcBomConverter());
converterProvider.Register(new CommonToJlcPosConverter());

builder.Services.AddSingleton(converterProvider);
builder.Services.AddSingleton<IImportService, EdaFileImportService>();
builder.Services.AddSingleton<IExportService, ManufacturerFileExportService>();

await builder.Build().RunAsync();
