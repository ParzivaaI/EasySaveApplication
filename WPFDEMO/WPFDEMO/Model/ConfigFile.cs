using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32;
using WPFDEMO.Commands;
using System.Diagnostics;
using System.Windows;
using System.Threading;
using System.Text;

namespace WPFDEMO.Model
{
    class ConfigFile
    {
        public string Data;
        ConfigFileJson configFileJson;
        public string[] bannedProcesses;
        public string configfilepath = Path.GetFullPath(@"Config\config.json");
        public ConfigFile()
        {   
            Directory.CreateDirectory(Path.GetFullPath(@"Config"));

            // Generate config file if it does not exist, a cryptoKey of 64 bits is also created
            if (!File.Exists(configfilepath))
            {
                configFileJson = new ConfigFileJson
                {
                    language = "",
                    fileMaxSize = "2048",
                    cryptoKey = GenerateCryptoKey(),
                    cryptedExtensions = "",
                    priorityExtensions = "",
                    workSoftware = ""
                };

                Data = JsonConvert.SerializeObject(configFileJson);

                File.WriteAllText(configfilepath, Data);
            }
            bannedProcesses = GetBannedProcesses();
        }
        public string GenerateCryptoKey()
        {
            // Generate a random string of 64 bit 
            StringBuilder strbuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 64; i++)
            {
                // Generate floating point numbers
                double myFloat = random.NextDouble();
                // Generate the char using below logic
                var myChar = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * myFloat) + 65));
                strbuilder.Append(myChar);
            }
            return strbuilder.ToString();
        }
        public string[] GetBannedProcesses()
        {
            Data = File.ReadAllText(configfilepath);
            configFileJson = JsonConvert.DeserializeObject<ConfigFileJson>(Data);

            bannedProcesses = configFileJson.workSoftware.Split(',');

            Data = JsonConvert.SerializeObject(configFileJson, Formatting.Indented);
            File.WriteAllText(configfilepath, Data);
            return bannedProcesses;
        }

        public string getConfigFileElement(string element)
        {
            Data = File.ReadAllText(configfilepath);

            configFileJson = JsonConvert.DeserializeObject<ConfigFileJson>(Data);

            switch (element)
            {
                case "FileMaxSize":
                    element = configFileJson.fileMaxSize;
                    break;
                case "CryptoKey":
                    element = configFileJson.cryptoKey;
                    break;
                case "CryptedExtensions":
                    element = configFileJson.cryptedExtensions;
                    break;
                case "WorkSoftware":
                    element = configFileJson.workSoftware;
                    break;
                case "PriorityExtensions":
                    element = configFileJson.priorityExtensions;
                    break;
            }
            return element;
        }
    }
}