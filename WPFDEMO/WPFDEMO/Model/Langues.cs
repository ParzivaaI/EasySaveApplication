using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDEMO.Model
{
    class Langues
    {
        public Langues(string savename, string folderCopy, string folderPast, string saveComplete, string saveDifferential, string BannedAppText, string MaxFileText, string ExtToCrypt, string CryptKey)
        {
            this.CryptKey = CryptKey;
            this.ExtToCrypt = ExtToCrypt;
            this.MaxFileText = MaxFileText;
            this.BannedAppText = BannedAppText;
            this.savename = savename;
            this.folderPast = folderPast;
            this.folderCopy = folderCopy;
            this.saveComplete = saveComplete;
            this.saveDifferential = saveDifferential;
        }
        public String CryptKey { get; set; }
        public String ExtToCrypt { get; set; }
        public String MaxFileText { get; set; }
        public String BannedAppText { get; set; }
        public String savename { get; set; }
        public String folderPast { get; set; }
        public String folderCopy { get; set; }
        public String saveComplete { get; set; }
        public String saveDifferential { get; set; }

        public Langues()
        {
            this.savename = "Add a new save name :";
            this.folderCopy = "add the location of the folder :";
            this.folderPast = "add the destination of the folder :";
            this.saveComplete = "complete saving";
            this.saveDifferential = "differential saving";
            this.CryptKey = "Manual crypting key :";
            this.ExtToCrypt = "Extensions to crypt :";
            this.MaxFileText = "Max file size :";
            this.BannedAppText = "Banned app :";

        }
    }
}

