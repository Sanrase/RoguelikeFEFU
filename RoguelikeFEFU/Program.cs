﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace RoguelikeFEFU
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Settings settings;
            string fullPath = Path.GetFullPath("SettingsGame.json");

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                settings = JsonConvert.DeserializeObject<Settings>(json);
            }
            else
            {
                settings = new Settings();
            }

            if (settings != null)
            {
                MainMenu.MainMenuRun(settings);
            }
            else
            {
                Console.WriteLine("Ошибка чтения файла!");
            }
        }
    }
}
