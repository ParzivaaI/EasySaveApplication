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

namespace WPFDEMO.Model
{
    class ConfigFileJson
    {
        public string language;
        public string fileMaxSize;
        public string cryptoKey;
        public string cryptedExtensions;
        public string priorityExtensions;
        public string workSoftware;
    }
}