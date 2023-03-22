using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal static class Game
    {   

        public static void Run()
        {


            Console.WriteLine("Хотите начать игру? (Y/N)");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                MapGenerate map = new MapGenerate();
                map.GenerateMap();
                Draw(map);

            } else
            {
                Environment.Exit(0);
            }

            while (true)
            {
                Update();
            }


        }

        public static void Draw(MapGenerate map) 
        {
           map.PrintDungeon();
           /* Console.WriteLine($"Health: {player.Health} / {player.MaxHealth}");
            Console.WriteLine($"Уровень:{level} "); */
        }
        public static void Update()
        {

        }

        public static void Player()
        {
            
        }
    }
}
