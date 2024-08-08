using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using WhatTheTea.LearnWinUI.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WhatTheTea.LearnWinUI.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WinUIEx.WindowEx
    {
        public MainViewModel ViewModel { get; } = App.Container.Services.GetRequiredService<MainViewModel>();

        public MainWindow()
        {
            this.InitializeComponent();
        }
    }
}
