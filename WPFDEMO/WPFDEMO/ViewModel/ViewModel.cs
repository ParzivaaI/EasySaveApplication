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
        public ICommand DifferentialSave { get; set; }
        public ICommand CompleteSave { get; set; }

        //Constructeur
        public ViewModel()  
        {
            currentModele = new Modele();
            MajusculeCommand = new RelayCommand(toUppercase);
            DifferentialSave = new RelayCommand(DifferentialSaveFunction);
            CompleteSave = new RelayCommand(CompleteSaveFunction);
        }

        private void CompleteSaveFunction()
        {
            currentModele.Completesave();
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToPaste,0);
        }
        private void toUppercase()
        {
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToCopy.ToUpper(),0);
        }
        private void DifferentialSaveFunction()
        {
            currentModele.Differentialsave();
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToPaste,0);
        }

    }
}
