using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDEMO.Model;
using System.Threading;
using Microsoft.SqlServer.Server;
using System.Diagnostics;


namespace WPFDEMO.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
     
        Modele currentModele;
        public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            //MessageBox.Show("Hello"+ propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Modele CurrentModele
        {
            get { return currentModele; }
            set { currentModele = value; RaisePropertyChanged("currentModele"); }
        }

        public ICommand MajusculeCommand { get; set; }
        public ICommand MinusculeCommand { get; set; }
        public ICommand Save { get; set; }

        //Constructeur
        public ViewModel()
        {
            currentModele = new Modele();
            MajusculeCommand = new RelayCommand(toUppercase);
            MinusculeCommand = new RelayCommand(toLowercase);
            Save = new RelayCommand(CompleteSaveFunction);
        }

        private void CompleteSaveFunction()
        {
            currentModele.completesave();
            CurrentModele = new Modele(currentModele.name, currentModele.pathToCopy, currentModele.pathToPaste, 0);
        }
        private void toUppercase()
        {
            CurrentModele = new Modele(currentModele.name, currentModele.pathToCopy, currentModele.pathToCopy.ToUpper(), 0);
        }
        private void toLowercase()
        {
            currentModele.minuscule();
            CurrentModele = new Modele(currentModele.name, currentModele.pathToCopy, currentModele.pathToPaste, 0);
        }

     


}
}