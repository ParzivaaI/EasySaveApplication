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

            /*var pr = System.Diagnostics.Process.GetProcessesByName(
              System.IO.Path.GetFileNameWithoutExtension(typeof(Process).Assembly.Location));
            var Id = System.Diagnostics.Process.GetCurrentProcess().Id;
            foreach (var p in pr.Where(x => x.Id != Id))
            {
                p.Kill();
            }*/
            
            
        }
        private void LoadProcess()
        {
            Process[] workApp = Process.GetProcessesByName("WPFDEMO");//get all process            

            if(workApp.Length > 1) 
            { 
                  foreach (Process process in workApp) 
                    {
                        process.Kill();            
                    }
            }                      

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
