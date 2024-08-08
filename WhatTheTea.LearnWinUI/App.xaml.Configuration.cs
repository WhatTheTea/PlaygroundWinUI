using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WhatTheTea.LearnWinUI.Contracts;
using WhatTheTea.LearnWinUI.Services;
using WhatTheTea.LearnWinUI.ViewModels;

namespace WhatTheTea.LearnWinUI
{
    public partial class App
    {
        public static IHost Container { get; private set; } = null!;
       
        private static void RegisterComponents()
        {
            Container = Host.CreateDefaultBuilder()
                          .ConfigureServices(services =>
                          {
                              services.AddTransient<IBookService, DummyBookService>();
                          })
                          .ConfigureViewModels()
                          .Build();
        }

    }

    public static class HostEx
    {
        public static IHostBuilder ConfigureViewModels(this IHostBuilder hostBuilder) => 
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
            });
    }
}
