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
            Draw(map);
            enemies = map.GenerateEnemy();
            hero = map.GeneratePlayer();

            while (true)
            {
                Update(hero, enemies, map);
            }


        }


        public static void Draw(MapGenerate map) 
        {
           map.PrintDungeon();
            
        }
        public static void Update(Person hero, List<Enemy> enemies, MapGenerate map)
        {
            map.PlayerMovement(hero);
            map.EnemiesMovement(enemies);
        }
    }
}
