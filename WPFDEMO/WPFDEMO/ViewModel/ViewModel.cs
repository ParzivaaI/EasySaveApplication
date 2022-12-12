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
        public ICommand CryptingFunction { get; set; }

        //Constructeur
        public ViewModel()  
        {
            currentModele = new Modele(); //On initialise le modèle et les différents relais
            MajusculeCommand = new RelayCommand(ToUppercase);
            DifferentialSave = new RelayCommand(DifferentialSaveFunction);
            CompleteSave = new RelayCommand(CompleteSaveFunction);
            CryptingFunction = new RelayCommand(Crypting);;

        }
        private void Crypting()
        {
            
        }
        private void CompleteSaveFunction()
        {
            try
            {           
                if(CurrentModele.BlacklistedPrograms()) //On verifie si un programme de la blacklist est actif
                { 
                currentModele.Completesave(); //Si non, on fait la sauvegarde et met a jour le modèle
                CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToPaste,0);
                }
            }
            catch(Exception)
            {
            }
        }
        private void ToUppercase()
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
