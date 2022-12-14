using System;
using System.IO;
using System.Xml.Serialization;

namespace WPFDEMO.Model

{
    public class Logger
    {

        public string FName { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public long FileSize { get; set; }
        public string Time { get; set; }

        //define log 
        private string CurrentDirectory
        {
            get;
            set;
        }

        //...

        private String FileName
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

        //...

        private string FileName2
        {
            //File Name
            get;
            set;
        }

        private string FilePath2
        {
            get;
            set;
        }

        public Logger()
        {
            // Create a JSON files in the project folder
            string workingDirectory = Environment.CurrentDirectory;
            this.CurrentDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.FileName = DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            this.FilePath = CurrentDirectory + "/" + this.FileName;
            // Create a XML files in the project folder
            this.FileName2 = DateTime.Now.ToString("dd-MM-yyyy") + ".xml";
            this.FilePath2 = CurrentDirectory + "/" + FileName2;

        }


        public void SaveLog(string message)
        {
            using (System.IO.StreamWriter w = System.IO.File.AppendText(FilePath))
            {
                w.Write("{0} \n", message);
            }

        }
        public void XMLSerialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Logger));
            using (TextWriter writer = new StreamWriter(FilePath2))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}