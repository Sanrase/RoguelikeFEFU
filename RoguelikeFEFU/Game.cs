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
            Teleporter teleporter;
            MapGenerate map = new MapGenerate();
            map.GenerateMap();
            enemies = map.GenerateEnemy();
            hero = map.GeneratePlayer();
            teleporter = map.GenerateTeleporter();
            Draw(map, hero, teleporter);
            Interface.DrawBox(30, 20, 15);
            int[,] coords = Interface.Statistics(30, hero);
            Interface.DynamicStatistics(hero, coords);

            while (true)
            {
                Update(hero, enemies, map, coords, teleporter);
            }


        }

        public static void Run(Person hero, MapGenerate map)
        {
            Teleporter teleporter;
            List<Enemy> enemies;
            map.GenerateMap();
            enemies = map.GenerateEnemy();
            Interaction.SetPlayerNewLevel(hero, map);
            teleporter = map.GenerateTeleporter();

            Draw(map, hero, teleporter);
            Interface.DrawBox(30, 20, 15);
            int[,] coords = Interface.Statistics(30, hero);
            Interface.DynamicStatistics(hero, coords);

            while (true)
            {
                Update(hero, enemies, map, coords, teleporter);
            }
        }


        public static void Draw(MapGenerate map, Person hero, Teleporter teleporter) 
        {
            map.PrintDungeon(hero, teleporter);
        }
        public static void Update(Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords, Teleporter teleporter)
        {
            Draw(map, hero, teleporter);
            Interface.DynamicStatistics(hero, coords);
            CheckButton(hero, enemies, map, teleporter);
            map.EnemiesMovement(enemies);
        }

        public static void CheckButton(Person hero, List<Enemy> enemies, MapGenerate generateMap, Teleporter teleporter)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if(keyInfo == ConsoleKey.E)
            {
                Interaction.PlayerAttack(hero, enemies, generateMap.GetMap());
            }
            else if(keyInfo == ConsoleKey.W || keyInfo == ConsoleKey.A || keyInfo == ConsoleKey.S || keyInfo == ConsoleKey.D)
            {
                generateMap.PlayerMovement(hero, keyInfo);
            }
            else if(keyInfo == ConsoleKey.H)
            {
                Interaction.PlayerHeal(hero);
            }
            else if(keyInfo == ConsoleKey.T)
            {
                Interaction.PlayerTeleport(hero, teleporter);
            }
        }
    }
}
