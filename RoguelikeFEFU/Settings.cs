using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CountRooms { get; set; }

        public int minWidth = 50;
        public int minHeight = 50;
        public int maxWidth = 100;
        public int maxHeight = 100;
        public int maxRooms = 20;
        public int minRooms = 4;

        public string PlayerName { get; set; }
        public ConsoleColor PlayerColor { get; set; }
        public ConsoleColor ColorSnake { get; set; }
        public ConsoleColor ColorKobalt { get; set; }
        public ConsoleColor ColorBoss { get; set; }
        public char PlayerSymbol { get; set; }

        public string[] PlayerNames { get; set; }

        public char[] PlayerSymbols { get; set; }

        public Settings() 
        {
            PlayerSymbol = '@';
            PlayerName = "Ace";
            PlayerColor = ConsoleColor.Blue;
            ColorSnake = ConsoleColor.Green;
            ColorKobalt = ConsoleColor.Cyan;
            ColorBoss = ConsoleColor.Magenta;
            Width = 80;
            Height = 50;
            CountRooms = 5;
            PlayerNames = new string[10] {"Ace", "Ben", "Cat", "Dan", "Eve", "Fox", "Gus", "Ivy", "Jay", "Kit" };
            PlayerSymbols = new char[6] { '@', 'Q', '&', 'P', 'T', 'E'};
        }
    }
}
