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
            Trader trader;
            map.GenerateMap();
            Draw(map);
            hero = map.GeneratePlayer();
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();
            enemies = map.GenerateEnemy();
            Interface.DrawBox(map.Width, 13, 20, 20);
            int[,] coords = Interface.Statistics(map.Width, hero);
            Interface.DynamicStatistics(hero, coords);

            while (true)
            {
                Update(hero, enemies, map, coords, trader, teleporter);
            }


        }

        public static void Run(Person hero, MapGenerate map)
        {
            Teleporter teleporter;
            List<Enemy> enemies;
            Trader trader;
            map.GenerateMap();
            Draw(map);
            trader = map.GenerateTrader();
            Interaction.SetPlayerNewLevel(hero, map);
            teleporter = map.GenerateTeleporter();
            enemies = map.GenerateEnemy();
            Interface.DrawBox(map.Width, 13, 20, 20);
            int[,] coords = Interface.Statistics(map.Width, hero);
            Interface.DynamicStatistics(hero, coords);

            while (true)
            {
                Update(hero, enemies, map, coords, trader, teleporter);
            }
        }


        public static void Draw(MapGenerate map) 
        {
            map.PrintDungeon();
        }
        public static void Update(Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords, Trader trader, Teleporter teleporter)
        {
            Interface.DynamicStatistics(hero, coords);
            Interaction.SetCursorToPlayer(hero);
            CheckButton(hero, enemies, map, trader, teleporter);
            map.EnemiesMovement(enemies);
        }

        public static void CheckButton(Person hero, List<Enemy> enemies, MapGenerate generateMap, Trader trader, Teleporter teleporter)
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
            else if(keyInfo == ConsoleKey.M)
            {
                Interaction.OpenShop(hero, trader, generateMap);
            }
        }
    }
}
