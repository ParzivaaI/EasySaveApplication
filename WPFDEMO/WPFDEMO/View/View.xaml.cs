using System.Windows;

namespace WPFDEMO.View
{
    /// <summary>
    /// Interaktionslogik für View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            SettingView SettingsWindow = new SettingView();
            this.Visibility = Visibility.Visible;
            SettingsWindow.Show();
        }

        private void OpenRUN(object sender, RoutedEventArgs e)
        {
            RunView SettingsWindow = new RunView();
            this.Visibility = Visibility.Visible;
            SettingsWindow.Show();
        }
    }
}
