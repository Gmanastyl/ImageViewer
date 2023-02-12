using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace ImageViewer;

public partial class MainWindow : Window {
        private Image _imageControl;
        private int _currentImageIndex;
        private string[] _imagePaths = new[] {
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image1.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image2.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image3.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image4.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image5.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image6.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image7.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image8.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image9.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image10.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image11.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image12.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image13.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image14.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image15.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image16.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image17.png",
            @"C:\Users\leant\Desktop\ImageViewer\ImageViewer\ImageViewer\images\image18.png",
        };
        
        private void LogMessage(string message) {
            using (var streamWriter = new StreamWriter("logfile.txt", true)) {
                streamWriter.WriteLine(DateTime.Now + ": " + message);
            }
        }

        public MainWindow() {
            InitializeComponent();
            _imageControl = this.FindControl<Image>("ImageControl");
            _currentImageIndex = 0;
            UpdateImage();
            LogMessage("MainWindow initialized");
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void NextImageButton_Click(object sender, RoutedEventArgs e) {
            _currentImageIndex++;
            if (_currentImageIndex >= _imagePaths.Length) {
                _currentImageIndex = 0;
            }

            UpdateImage();
        }

        private void PreviousImageButton_Click(object sender, RoutedEventArgs e) {
            _currentImageIndex--;
            if (_currentImageIndex < 0) {
                _currentImageIndex = _imagePaths.Length - 1;
            }

            UpdateImage();
        }

        private void UpdateImage() {
            _imageControl.Source = new Bitmap(_imagePaths[_currentImageIndex]);
        }
    }
