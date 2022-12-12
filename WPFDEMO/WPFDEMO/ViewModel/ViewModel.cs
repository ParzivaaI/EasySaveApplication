using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDEMO.Commands;
using WPFDEMO.Model;

namespace WPFDEMO.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        Langues currentLangues;
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
        public Langues CurrentLangues
        {
            get { return currentLangues; }
            set { currentLangues = value; RaisePropertyChanged("currentLangues"); }
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
        private void AddEnglish()
        {
            CurrentLangues = new Langues("Add a new save name :", "Add the location of the folder :", "Add the destination of the folder :", "Complete Save", "Differential Save");
        }
        private void Addfrench()
        {
            CurrentLangues = new Langues("Ajouter un nom à la sauvgarde :", "Ajouter le chemin d'accès du dossier :", "Ajouter le dossier de déstination :", "Sauvgarde Complete", "Sauvgarde Differentialle");
        }
    }
}
