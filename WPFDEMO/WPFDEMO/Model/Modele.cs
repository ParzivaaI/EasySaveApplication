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
        public Modele(string Name, string pathToCopy, string pathToPaste, int leftToTransfer, long maxSize, string bannedApps,string extensionCrypt,int cryptKey)
        {
            this.pathToCopy = pathToCopy;
            this.pathToPaste = pathToPaste;
            this.name = Name;
            this.leftToTransfer = leftToTransfer;
            this.maxSize = maxSize;
            this.bannedApp = bannedApps;
            this.extensionCrypt = extensionCrypt;
            this.cryptKey = cryptKey;
        }
        public Modele()
        {
            this.name = "Backup";
            this.pathToCopy = @"C:\";
            this.pathToPaste = @"C:\Program Files (x86)";
            this.leftToTransfer = 1;
            this.maxSize = 100000;
        }
       /* BlackList BannedProgramms = new BlackList(); *///Initialisation de la blacklist
        public String name { get; set; }
        public String pathToCopy { get; set; }
        public String pathToPaste { get; set; }
        public int leftToTransfer { get; set; }
        public long maxSize { get; set; }
        public string bannedApp { get; set; }
        public string extensionCrypt { get; set; }
        public int cryptKey { get; set; }
        

        Save RunningSave = new Save();

        public void completesave()
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
