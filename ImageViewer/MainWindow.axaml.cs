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
        private long _currentImageIndex;
        private string _imageBasePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images/";
        
        private void LogMessage(string message) {
            using (var streamWriter = new StreamWriter("logfile.txt", true)) {
                streamWriter.WriteLine(DateTime.Now + ": " + message);
            }
        }

        public MainWindow() {
            InitializeComponent();
            _imageControl = this.FindControl<Image>("ImageControl");
            _currentImageIndex = 1;
            UpdateImage();
            LogMessage("MainWindow initialized");
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void NextImageButton_Click(object sender, RoutedEventArgs e) {
            _currentImageIndex++;
            if (_currentImageIndex >= Directory.GetFiles(_imageBasePath).Length) {
                _currentImageIndex = 1;
            }

            UpdateImage();
        }

        private void PreviousImageButton_Click(object sender, RoutedEventArgs e) {
            _currentImageIndex--;
            if (_currentImageIndex < 0) {
                _currentImageIndex = new FileInfo(_imageBasePath).Length - 1;
            }

            UpdateImage();
        }

        private void UpdateImage() {
            _imageControl.Source = new Bitmap($"{_imageBasePath}image{_currentImageIndex}.png");
        }
    }
