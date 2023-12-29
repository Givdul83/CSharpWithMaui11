using AddressbookMobileApp.ViewModels;
using AddressbookMobileApp.Views;
using AppLibrary.Interfaces;
using AppLibrary.Services;
using Microsoft.Extensions.Logging;

namespace AddressbookMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IContactService, ContactService>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<ViewListModel>();
            builder.Services.AddSingleton<SearchViewModel>();
            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<RemoveViewModel>();
            builder.Services.AddSingleton<UpdateViewModel>();
            builder.Services.AddSingleton<ExitViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ListPage>();
            builder.Services.AddSingleton<SearchPage>();
            builder.Services.AddSingleton<AddPage>();
            builder.Services.AddSingleton<RemovePage>();
            builder.Services.AddSingleton<UpdatePage>();
            builder.Services.AddSingleton<ExitPage>();


            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
