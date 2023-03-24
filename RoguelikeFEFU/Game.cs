﻿using System;
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
            Interface.DrawBox(map.Width, 20, 20);
            int[,] coords = Interface.Statistics(map.Width, hero);
            Interface.DynamicStatistics(hero, coords);

            while (true)
            {
                Update(hero, enemies, map, coords);
            }


        }


        public static void Draw(MapGenerate map) 
        {
            map.PrintDungeon();
        }
        public static void Update(Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords)
        {
            map.PlayerMovement(hero);
            Interface.DynamicStatistics(hero, coords);
            map.EnemiesMovement(enemies);
        }
    }
}
