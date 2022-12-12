using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDEMO.Model
{
    class Langues
    {
        public Langues(string savename, string folderCopy, string folderPast, string saveComplete, string saveDifferential)
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

        public Langues()
        {
            this.savename = "Add a new save name :";
            this.folderCopy = "Add the folder location :";
            this.folderPast = "Add the folder destination :";
            this.saveComplete = "Complete save";
            this.saveDifferential = "Differential save";
        }
    }
}

