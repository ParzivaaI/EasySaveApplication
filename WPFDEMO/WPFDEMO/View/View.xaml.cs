using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace WPFDEMO.View
{
    /// <summary>
    /// Interaktionslogik für View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            
            
            LoadProcess();

            InitializeComponent();

                       
            
        }
        private void LoadProcess()
        {
            Process[] workApp = Process.GetProcessesByName("WPFDEMO");//get in a table all process named WPFDEMO          

            if(workApp.Length > 1) 
            { 
                
                Process process= workApp[1]; 
                process.Kill(); 

            }                      

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
