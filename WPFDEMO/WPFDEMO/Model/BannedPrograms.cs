using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using WPFDEMO.Commands;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using System.Windows;

namespace WPFDEMO.Model
{
    /// <summary>
    /// Runs through active processes to add work software.
    /// </summary>
    class BannedProgramm : ObservableObject
    {
        /// <summary>
        /// Constructor to use ProcessList elswhere.
        /// </summary>
        public BannedProgramm()
        {
            proclist = ProcessList();
        }
        public string[] proclist;
        private string bannedprogramms;
        public string Ban()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory+@"..\..\..\Ressources\Config.json");
            Dictionary<string, string> setting = JsonConvert.DeserializeObject< Dictionary<string, string>>(json);
            Application.Current.Properties["BannedApps"] = setting["BannedApps"];
            return json;
        }
        public string[] ProcessList()
        {
            Process[] processes = Process.GetProcesses();
            List<string> processlist = new List<string>();
            foreach (Process allProcesses in processes)
            {
                if (!String.IsNullOrEmpty(allProcesses.ProcessName))
                {
                    string processnameid = allProcesses.ProcessName;
                    processlist.Add(processnameid);
                }
            }
            processlist.Sort();
            proclist = processlist.ToArray();
            return proclist;
        }
    }
}
