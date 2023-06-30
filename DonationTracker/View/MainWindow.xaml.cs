using DonationTracker.Model;
using DonationTracker.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace DonationTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimiseWindowButton(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximiseWindowButton(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void CloseWindowButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChangeViewButton(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
