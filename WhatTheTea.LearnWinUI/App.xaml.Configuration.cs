using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                              services.AddSingleton<MainViewModel>();
                          })
                          .Build();
        }

    }
}
