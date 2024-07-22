using Microsoft.UI.Xaml;
using Microsoft.Windows.AppLifecycle;

using System.IO;

using Windows.ApplicationModel.Activation;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WhatTheTea.ImageViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public string ImagePath { get; private set; } = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledPath, "Assets/StoreLogo.png");
        public MainWindow()
        {
            this.InitializeComponent();

            var args = AppInstance.GetCurrent().GetActivatedEventArgs();
            if (args.Kind == ExtendedActivationKind.File 
                && args.Data is IFileActivatedEventArgs fileArgs)
            {
                IStorageItem file = fileArgs.Files[0];
                ImagePath = file.Path;
            }
            else
            {
                this.UsageTip.IsOpen = true;
            }
        }
    }
}
