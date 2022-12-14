using System;

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
        public string savename { get; set; }
        public string folderPast { get; set; }
        public string folderCopy { get; set; }
        public string saveComplete { get; set; }
        public string saveDifferential { get; set; }

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

