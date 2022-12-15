using Newtonsoft.Json;
using System;
using System.IO;
using System.Timers;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace WPFDEMO.Model
{
    public class Save
    {
        long maxsize;
        string name;
        string copyDirectory;
        string pasteDirectory;
        int leftToTransfer;
        bool stateIsActive;
        string saveCompleted;
        public static int TimeCounter = 0;
        public static Timer timer = new Timer(500);

        public int LeftToTransfer { get => leftToTransfer; set => leftToTransfer = value; }
        public string PasteDirectory { get => pasteDirectory; set => pasteDirectory = value; }
        public string Name { get => name; set => name = value; }
        public string CopyDirectory { get => copyDirectory; set => copyDirectory = value; }
        public string SaveCompleted { get => saveCompleted; set => saveCompleted = value; }
        public long Maxsize { get => maxsize; set => maxsize = value; }
        public bool StateIsActive { get => stateIsActive; set => stateIsActive = value; }
        public Save()
        {
            Name = "EasySaved";//Initialisation de Save avec des données de départ
            CopyDirectory = @"C:\";
            PasteDirectory = @"C:\Program Files";
            SaveCompleted = "Complete";
            Maxsize = 1000000;
        }
        public void Variables(string Name, string CopyDirectory, string PasteDirectory, int LeftToTransfer)
        {
            name = Name;//Initialisation des variables avec les valeurs de départ voulues
            copyDirectory = CopyDirectory;
            pasteDirectory = PasteDirectory;
            leftToTransfer = LeftToTransfer;
        }
        public void CryptingData()
        {
            var date = DateTime.Now; //Mettre la date du jour
            long totalFileSize = 0; //Initialiser la taille totale du fichier
            pasteDirectory += @"\";
            Process process = new Process();
            process.StartInfo.FileName=@"../../../Cryptosoft/Cryptosoft.exe";
            process.StartInfo.Arguments=copyDirectory;       // copy
            process.StartInfo.Arguments += pasteDirectory;  // paste path
            process.Start();
            process.WaitForExit();
        }
        public void CompleteSave()
        {
            //Demarrer le timer
            timer.Elapsed += SaveTimer;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            TimeCounter++;
            string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK"); //Mettre date du jour
            long totalFileSize = 0; //Initialiser la taille totale du fichier
            pasteDirectory += @"\" + name;
            //créer la state
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*", SearchOption.AllDirectories))
            {
                MessageBox.Show("test");
                Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory)); //créer le dossier dans la nouvelle sauvegarde pour chaque dossier existant
            }
            //Copying all the files, replace if same name
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {
                totalFileSize += newPath.Length;
            }
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {

                File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                LeftToTransfer--;
                TimeCounter++;
                totalFileSize = newPath.Length;
                //ajouter ici si file de taille superieure à variable de taille, refuser copie
                long length = new System.IO.FileInfo(newPath).Length;
                if (length>maxsize)
                {
                  if (LeftToTransfer >= 0)
                  {
                      CryptingData(); //crypting the file
                      bool stateIsActive;
                      File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                      LeftToTransfer--; //On décrémente le nombre de fichiers restant à copier
                      TimeCounter++;
                      totalFileSize = newPath.Length;
                      if (LeftToTransfer >= 0)
                      {
                          stateIsActive = true;
                      }
                      else
                      {
                          stateIsActive = false;
                      }
                    ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, LeftToTransfer, totalFileSize, saveCompleted);
                  }
                }
                else
                {
                  leftToTransfer--;
                }
            }

            var logger = new Logger
            {
                FName = name,
                FileSource = copyDirectory,
                FileTarget = pasteDirectory,
                FileSize = totalFileSize,
                Time = date,
            };
            string jsonString = JsonConvert.SerializeObject(logger);
            logger.XMLSerialize();
            logger.SaveLog(jsonString);
        }

        public void DiffSave()
        {
            SaveCompleted = "Differential";
            long totalFileSize = 0;
            //Demarrer le timer
            timer.Elapsed += SaveTimer;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            TimeCounter++;
            pasteDirectory += @"\" + name;
            //Ajout du nom au path pour créer le dossier de sauvegarde
            StateFunction ObjStateFunction = new StateFunction();
            //créer les dossiers
            foreach (string dirPath in Directory.GetDirectories(copyDirectory, "*", SearchOption.AllDirectories))
            {
                if (Directory.GetLastAccessTime(dirPath) > Directory.GetLastAccessTime(copyDirectory))
                {
                    Directory.CreateDirectory(dirPath.Replace(copyDirectory, pasteDirectory));
                }
            }
            //Copie les fichiers, remplace si nom identique
            foreach (string newPath in Directory.GetFiles(copyDirectory, "*.*", SearchOption.AllDirectories))
            {
                if (File.GetLastAccessTime(newPath) > File.GetLastAccessTime(newPath.Replace(copyDirectory, pasteDirectory)))
                {

                    File.Copy(newPath, newPath.Replace(copyDirectory, pasteDirectory), true);
                    LeftToTransfer--;
                    totalFileSize -= newPath.Length;
                    if (LeftToTransfer >= 0)
                    {
                        stateIsActive = true;
                    }
                    else
                    {
                        stateIsActive = false;
                    }
                }

            }
            string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
            ObjStateFunction.StateCreate(copyDirectory, pasteDirectory, name, stateIsActive, LeftToTransfer, totalFileSize, saveCompleted);
            var logger = new Logger
            {
                FName = name,
                FileSource = copyDirectory,
                FileTarget = pasteDirectory,
                FileSize = totalFileSize,
                Time = date
            };
            string jsonString = JsonConvert.SerializeObject(logger);
            logger.SaveLog(jsonString);


        }

        void SaveTimer(object sender, ElapsedEventArgs e)
        {
            TimeCounter++;
        }
        public void Encrypt(string sourceDir, string targetDir)//Fonction de cryptage
        {
            using (Process process = new Process())//Création du process
            {
                process.StartInfo.FileName = @"..\..\..\Ressources\CryptoSoft.exe"; //Appel du process Cryptosoft
                process.StartInfo.Arguments = String.Format("\"{0}\"", sourceDir) + " " + String.Format("\"{0}\"", targetDir);
                process.Start();
                process.Close();
            }

            }*/
    }
}
