using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDEMO.Model
{
    public class French
    {
        public French(string savename, string folderCopy, string folderPast, string saveComplete, string saveDifferential)
        {
            this.savename = savename;
            this.folderPast = folderPast;
            this.folderCopy = folderCopy;
            this.saveComplete = saveComplete;
            this.saveDifferential = saveDifferential;
        }
        public String savename { get; set; }
        public String folderPast { get; set; }
        public String folderCopy { get; set; }
        public String saveComplete { get; set; }
        public String saveDifferential { get; set; }

        public French()
        {
            this.savename = "Ajouter un nom à la sauvgarde :";
            this.folderCopy = "Ajouter le chemin d'accès du dossier :";
            this.folderPast = "Ajouter le dossier de déstination :";
            this.saveComplete = "Sauvgarde Complete";
            this.saveDifferential = "Sauvgarde Differentialle";
        }
    }
}