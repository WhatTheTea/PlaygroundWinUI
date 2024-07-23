using CommunityToolkit.WinUI.Helpers;
using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reactive.Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WhatTheTea.PhotoMaker
{
    public sealed partial class MainWindow : Window
    {
        public SoftwareBitmapSource ImageSource { get; } = new();

        private SynchronizationContext uiContext { get; } = SynchronizationContext.Current;

        public MainWindow()
        {
            this.InitializeComponent();
            // TODO: Replace camera preview with mediacapture
            CameraPreviewControl.PreviewFailed += CameraPreviewControl_PreviewFailed;
            CameraPreviewControl.StartAsync()
                .ToObservable()
                .Subscribe(_ => Observable.FromEventPattern<FrameEventArgs>(CameraPreviewControl.CameraHelper, nameof(CameraHelper.FrameArrived))
                                          .Sample(TimeSpan.FromMilliseconds(50))
                                          .ObserveOn(uiContext)
                                          .Subscribe(x => CameraPreviewControl_FrameArrived(x.Sender, x.EventArgs)));
            // WTF?!
            // Without GC camera freezes .-.
            Observable.Interval(TimeSpan.FromMilliseconds(700))
                .Subscribe(x => GC.Collect());

        }

        private static SoftwareBitmap TransformBitmap(SoftwareBitmap softwareBitmap)
        {
            if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 || softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
            {
                return SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);
            }
            return softwareBitmap;
        }

        private void CameraPreviewControl_FrameArrived(object sender, FrameEventArgs e)
        {
            var videoFrame = e.VideoFrame;
            var softwareBitmap = TransformBitmap(videoFrame.SoftwareBitmap);

            ImageSource.SetBitmapAsync(softwareBitmap)
                    .ToObservable()
                    .Timeout(TimeSpan.FromMilliseconds(50))
                    .ObserveOn(uiContext)
                    .Subscribe();
        }

        private void CameraPreviewControl_PreviewFailed(object sender, PreviewFailedEventArgs e)
        {
            var errorMessage = e.Error;
            this.ErrorTip.Title = "Error";
            this.ErrorTip.Subtitle = errorMessage;
            this.ErrorTip.IsOpen = true;
        }
    }
}
