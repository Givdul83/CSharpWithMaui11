using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AppLibrary.Interfaces;
using AppLibrary.Services;
using ConsoleApp.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<MenuService>();

}).Build();

builder.Start();
Console.Clear();


var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.MainMenu();

