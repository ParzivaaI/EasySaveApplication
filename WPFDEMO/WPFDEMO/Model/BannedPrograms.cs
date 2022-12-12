using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32;
using WPFDEMO.Commands;
using System.Diagnostics;

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

        /// <summary>
        /// Runs through processes and adds the process name and id to a list.
        /// </summary>
        /// <returns>Full process list</returns>
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