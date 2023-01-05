using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using WPFDEMO.Commands;
using WPFDEMO.Model;

namespace WPFDEMO.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        private string _selectedFilePath;
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
        public string SelectedFilePathTarget
        {
            get { return _selectedFilePath; }
            set
            {
                _selectedFilePath = value;
                RaisePropertyChanged();
            }
        }
        public string SelectedFilePathSource
        {
            get { return _selectedFilePath; }
            set
            {
                _selectedFilePath = value;
                RaisePropertyChanged();
            }
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

        public ICommand MajusculeCommand { get; set; }
        public ICommand MinusculeCommand { get; set; }
        public ICommand Save { get; set; }
        public ICommand Francais { get; set; }
        public ICommand English { get; set; }
        public ICommand Settings { get; set; }
        public ICommand BrowseCommandSource { get; set; }
        public ICommand BrowseCommandTarget { get; set; }
        //Constructeur
        public ViewModel()
        {
            CurrentSettingsView = new ViewModelSetting();
            CurrentView = CurrentSettingsView;
            currentLangues = new Langues();
            currentModele = new Modele();
            MajusculeCommand = new RelayCommand(toUppercase);
            MinusculeCommand = new RelayCommand(toLowercase);
            Save = new RelayCommand(CompleteSaveFunction);
            Francais = new RelayCommand(Addfrench);
            English = new RelayCommand(AddEnglish);
            Settings = new RelayCommand(SettingsView);
            BrowseCommandSource = new RelayCommand(BrowseSource);
            BrowseCommandTarget = new RelayCommand(BrowseTarget);
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
        private void AddEnglish() 
        { 
            CurrentLangues = new Langues("HOME","Add a new save name :", "Add the folder location :", "Add the folder destination :", "Complete Save", "Differential Save", "Banned app :", "Max file size :", "Extensions to crypt :", "Manual crypting key :", "List of saves", "Settings");
        }
        private void Addfrench()
        {
            CurrentLangues = new Langues("Accueil", "Ajouter un nom à la sauvegarde :", "Ajouter le chemin d'accès du dossier :", "Ajouter le dossier de déstination :", "Sauvegarde Complete", "Sauvegarde Differentialle", "Logiciel de travail :", "Taille maximal :", "Clé de cryptage Manuelle :", "Extensions à crypter :", "Liste des sauvgardes", "Paramètres");
        }
        private void SettingsView()
        {
            CurrentView = new ViewModelSetting();
        }
        private void BrowseSource()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFilePathSource = openFileDialog.FileName;
                }
            }
        }
        private void BrowseTarget()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFilePathTarget = openFileDialog.FileName;
                }
            }
        }
    }
}

