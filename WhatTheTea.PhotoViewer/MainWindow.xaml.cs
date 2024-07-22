using Microsoft.UI.Xaml;
//using Microsoft.Windows.AppLifecycle;

using System.IO;

using Windows.ApplicationModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WhatTheTea.PhotoViewer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public string ImagePath { get; private set; } = Path.Combine(Package.Current.InstalledPath, "Assets/StoreLogo.png");
        public MainWindow()
        {
            this.InitializeComponent();

            var args = AppInstance.GetActivatedEventArgs();
            if (args.Kind == Windows.ApplicationModel.Activation.ActivationKind.File)
            {
                
            } 
            else
            {
                this.UsageTip.IsOpen = true;
            }
        }

    }
}
