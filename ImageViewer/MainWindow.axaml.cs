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
            "images/image1.png",
            "images/image2.png",
            "images/image3.png",
            "images/image4.png",
            "images/image5.png",
            "images/image6.png",
            "images/image7.png",
            "images/image8.png",
            "images/image9.png",
            "images/image10.png",
            "images/image11.png",
            "images/image12.png",
            "images/image13.png",
            "images/image14.png",
            "images/image15.png",
            "images/image16.png",
            "images/image17.png",
            "images/image18.png",
        };
        
        private void LogMessage(string message) {
            using (var streamWriter = new StreamWriter("logs.txt", true)) {
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
