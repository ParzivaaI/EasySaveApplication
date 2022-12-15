using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPFDEMO.Commands;
using WPFDEMO.Model;

namespace WPFDEMO.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        private object currentView;
        ViewModelSetting CurrentSettingsView;
        Langues currentLangues;
        Modele currentModele;
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            //MessageBox.Show("Hello"+ propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; RaisePropertyChanged("currenView"); }
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
        public ICommand Save { get; set; }
        public ICommand Francais { get; set; }
        public ICommand English { get; set; }
        public ICommand Settings { get; set; }
        //Constructeur
        public ViewModel()
        {
            CurrentSettingsView = new ViewModelSetting();
            CurrentView = CurrentSettingsView;
            currentLangues = new Langues();
            currentModele = new Modele();
            Save = new RelayCommand(CompleteSaveFunction);
            Francais = new RelayCommand(Addfrench);
            English = new RelayCommand(AddEnglish);
            Settings = new RelayCommand(SettingsView);
        }
        private void CompleteSaveFunction()
        {
            currentModele.completesave();
            CurrentModele = new Modele(currentModele.name, currentModele.pathToCopy, currentModele.pathToPaste, 0,currentModele.maxSize, currentModele.bannedApp,currentModele.extensionCrypt,currentModele.cryptKey) ;
        }
        private void AddEnglish() 
        { 
            CurrentLangues = new Langues("Add a new save name :", "Add the folder location :", "Add the folder destination :", "Complete Save", "Differential Save", "Banned app :", "Max file size :", "Extensions to crypt :", "Manual crypting key :", "Home", "Settings", "Save");
        }
        private void Addfrench()
        {
            CurrentLangues = new Langues( "Ajouter un nom à la sauvegarde :", "Ajouter le chemin d'accès du dossier :", "Ajouter le dossier de déstination :", "Sauvegarde Complete", "Sauvegarde Differentialle", "Logiciel de travail :", "Taille maximal :", "Clé de cryptage Manuelle :", "Extensions à crypter :", "Accueil", "Paramètres", "Sauvegarder");
        }
        private void SettingsView()
        {
            CurrentView = new ViewModelSetting();
        }
    }
}

