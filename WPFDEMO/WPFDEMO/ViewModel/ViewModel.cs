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
        Langues currentLangues;
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
        public Langues CurrentLangues
        {
            get { return currentLangues; }
            set { currentLangues = value; RaisePropertyChanged("currentLangues"); }
        }

        public ICommand MajusculeCommand { get; set; }
        public ICommand MinusculeCommand { get; set; }
        public ICommand Save { get; set; }
        public ICommand Francais { get; set; }
        public ICommand English { get; set; }
        //Constructeur
        public ViewModel()  
        {
            currentLangues = new Langues();
            currentModele = new Modele();
            MajusculeCommand = new RelayCommand(toUppercase);
            MinusculeCommand = new RelayCommand(toLowercase);
            Save = new RelayCommand(CompleteSaveFunction);
            Francais = new RelayCommand(Addfrench);
            English = new RelayCommand(AddEnglish);
        }

        private void CompleteSaveFunction()
        {
            currentModele.completesave();
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToPaste,0);
        }
        private void toUppercase()
        {
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToCopy.ToUpper(),0);
        }
        private void toLowercase()
        {
            currentModele.minuscule();
            CurrentModele = new Modele(currentModele.name,currentModele.pathToCopy, currentModele.pathToPaste,0);
        }
        private void AddEnglish()
        {
            CurrentLangues = new Langues("Add a new save name :", "Add the folder location :", "Add the folder destination :", "Complete Save", "Differential Save");
        }
        private void Addfrench()
        {
            CurrentLangues = new Langues("Ajouter un nom à la sauvgarde :", "Ajouter le chemin d'accès du dossier :", "Ajouter le dossier de déstination :", "Sauvgarde Complete", "Sauvgarde Differentialle");
        }
    }
}
