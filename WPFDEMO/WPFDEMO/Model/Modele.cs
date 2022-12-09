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
        {
            this.pathToCopy = pathToCopy;
            this.pathToPaste = pathToPaste;
            this.name = Name;
            this.leftToTransfer = leftToTransfer;
        }
        public Modele()
        {
            this.name = "Backup";
            this.pathToCopy = @"C:\";
            this.pathToPaste = @"C:\Program Files (x86)";
            this.leftToTransfer = 1;
        }
        BlackList BannedProgramms = new BlackList();
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
    }
}
