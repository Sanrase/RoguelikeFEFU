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
            Person hero;
            List<Enemy> enemies;
            MapGenerate map = new MapGenerate();
            map.GenerateMap();
            enemies = map.SetEnemy();
            hero = map.SetHero();


            Draw(map);

            while (true)
            {
                Update();
            }


        }

        public static void Draw(MapGenerate map) 
        {
           map.PrintDungeon();
            
        }
        public static void Update()
        {

        }

        public static void Player()
        {
            
        }
    }
}
