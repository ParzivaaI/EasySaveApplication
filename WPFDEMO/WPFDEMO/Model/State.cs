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

        public StateFunction()
        {
            //Ajoute les informations à la création du fichier json de départ
            string workingDirectory = Environment.CurrentDirectory;
            this.CurrentDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + " State.json";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }
        public void StateCreate(string message)
        {
            using (System.IO.StreamWriter w = System.IO.File.AppendText(FilePath))
            {
                w.Write("{0} \n", message);
            }
        }
    }
}