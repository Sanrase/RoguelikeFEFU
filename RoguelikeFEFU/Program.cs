using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoguelikeFEFU
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Settings settings = new Settings();
            
            MainMenu.MainMenuRun(settings);
        }
    }
}
