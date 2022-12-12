﻿using System;
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
        BlackList BannedProgramms = new BlackList(); //Initialisation de la blacklist
        public String name { get; set; }
        public String pathToCopy { get; set; }
        public String pathToPaste { get; set; }
        public int leftToTransfer { get; set; }

        Save RunningSave = new Save();

        public void minuscule()
        {
            pathToPaste = pathToCopy.ToLower();
        }
        public void completesave()
        {
            RunningSave.Variables(name,pathToCopy,pathToPaste, leftToTransfer);
            RunningSave.CompleteSave();
        }
    }
}
