using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Timers;

namespace WPFDEMO.Model

{
    public class StateFunction
    {
        public string FName { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public long FileSize { get; set; }
        public string Time { get; set; }
        public bool StateActive { get; set; }
        private string CurrentDirectory
        {
            get;
            set;
        }

        private string FileName
        {
            //File Name
            get;
            set;
        }

        private string FilePath
        {
            get;
            set;
        }
        public int FileLength
        {
            get;
            set;
        }

        public StateFunction()
        {
            //Ajoute les informations à la création du fichier json de départ
            string workingDirectory = Environment.CurrentDirectory;
            this.CurrentDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + " State.json";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }
        public void StateCreate(string adresscopy, string adresspast, string FName, bool isActive, int filesLeft, long totalFileSize, string savecompleted)
        {
            this.FileLength = filesLeft;
            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.Write("Name : {0} \n", FName);
                w.Write("FileSource : {0} \n", adresscopy);
                w.Write("FileTarget : {0} \n", adresspast);
                w.Write("Time : {0} {1} \n", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                w.Write("FilesLeft : {0} \n", FileLength);
                w.Write("Active: {0}\n", isActive);
                w.Write("Complete: {0}\n", savecompleted);
                w.Write("Size: {0}\n", totalFileSize);
                w.Write("\n");
            }
        }
    }
}