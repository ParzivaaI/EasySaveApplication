using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            LoadProcess();
        }
        private void LoadProcess()
        {
            Process[] workApp = Process.GetProcessesByName("WPFDEMO");//get in a table all process named WPFDEMO

            if (workApp.Length > 1)
            {
                Window popup = new Window();
                popup.Title = "Warning";
                popup.Height = 200;
                popup.Width = 750;
                popup.FontSize = 15;
                popup.Content = "Ceci est une application en mono-instance, vous ne pouvez pas l'ouvrir deux fois en même temps." + "\n" +
                "This is a single-instance application, you cannot open it twice at the same time.";
                popup.Show(); ;

                Process process = workApp[1];
                process.Kill(); //Kill the process in the second cell of the table workApp.

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
