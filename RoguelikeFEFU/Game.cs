using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Trader trader;
            MapGenerate map = new MapGenerate();

            map.GenerateMap();
            enemies = map.GenerateEnemy();
            hero = map.GeneratePlayer();
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();

            Draw(map, hero, teleporter, trader);
            int[,] coords = Interface.Statistics(30, hero);

            while (true)
            {
                Update(hero, enemies, map, coords, teleporter, trader);
            }


        }

        public static void Run(Person hero, MapGenerate map)
        {
            Teleporter teleporter;
            List<Enemy> enemies;
            Trader trader;
            map.GenerateMap();
            enemies = map.GenerateEnemy();
            Interaction.SetPlayerNewLevel(hero, map);
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();

            Draw(map, hero, teleporter, trader);
            int[,] coords = Interface.Statistics(30, hero);

            while (true)
            {
                Update(hero, enemies, map, coords, teleporter, trader);
            }
        }


        public static void Draw(MapGenerate map, Person hero, Teleporter teleporter, Trader trader) 
        {
            map.PrintDungeon(hero, teleporter, trader);
        }
        public static void Update(Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords, Teleporter teleporter, Trader trader)
        {
            Draw(map, hero, teleporter, trader);
            Interface.DynamicStatistics(hero, coords);
            CheckButton(hero, enemies, map, teleporter, trader);
            map.EnemiesMovement(enemies);
        }

        public static void CheckButton(Person hero, List<Enemy> enemies, MapGenerate generateMap, Teleporter teleporter, Trader trader)
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
            else if (keyInfo == ConsoleKey.M)
            {
                Interaction.OpenShop(hero, trader);
            }
        }
    }
}
