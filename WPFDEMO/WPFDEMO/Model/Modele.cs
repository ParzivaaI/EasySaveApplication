using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDEMO.Model;

namespace WPFDEMO.Model
{
    public class Modele
    {
        public Modele(string Name,string pathToCopy, string pathToPaste, int leftToTransfer)
        { //Initialisation de chaque variable du modèle en surcharge avec les valeurs de l'utilisateur
            this.pathToCopy = pathToCopy;
            this.pathToPaste = pathToPaste;
            this.name = Name;
            this.leftToTransfer = leftToTransfer;
        }
        public Modele()
        { //Valeurs de base affichées
            this.name = "Backup";
            this.pathToCopy = @"C:\";
            this.pathToPaste = @"C:\Program Files (x86)";
            this.leftToTransfer = 1;
            //BannedProgramms.Black_list();
        }
        BannedProgramm BlockSoftware = new BannedProgramm(); //Initialisation de la blacklist
        public String name { get; set; }
        public String pathToCopy { get; set; }
        public String pathToPaste { get; set; }
        public int leftToTransfer { get; set; }

        Save RunningSave = new Save();

        public void Differentialsave()
        {
            RunningSave.Variables(name, pathToCopy, pathToPaste, leftToTransfer);
            RunningSave.DiffSave();
        }
        public void Completesave()
        {
            RunningSave.Variables(name,pathToCopy,pathToPaste, leftToTransfer);
            RunningSave.CompleteSave();
        }

        public bool BlacklistedPrograms()
        {
            //foreach(BannedProgramms.Black_list in process.) //Verifier parmi les processus en cours si un programme de la blacklist est présent
            return true;
        }
    }
}
