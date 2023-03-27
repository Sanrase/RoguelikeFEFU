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
        public static void Run(Settings settings)
        {
            bool gameRun = true;
            Person hero;
            List<Enemy> enemies;
            Teleporter teleporter;
            Trader trader;
            MapGenerate map = new MapGenerate(settings);

            map.GenerateMap();
            hero = map.GeneratePlayer();
            enemies = map.GenerateEnemy(hero);
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();

            int[,] coords = Interface.Statistics(30, hero);

            while (gameRun)
            {
                Update(settings, hero, enemies, map, coords, teleporter, trader, ref gameRun);
            }
        }

        public static void Run(Person hero, MapGenerate map, Settings settings)
        {
            bool gameRun = true;
            ref bool refGameRun = ref gameRun;
            Teleporter teleporter;
            List<Enemy> enemies;
            Trader trader;
            map.GenerateMap();
            enemies = map.GenerateEnemy(hero);
            Interaction.SetPlayerNewLevel(hero, map);
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();
            Interface.DynamicLineTeleport();

            int[,] coords = Interface.Statistics(30, hero);

            while (gameRun)
            {
                Update(settings, hero, enemies, map, coords, teleporter, trader, ref gameRun);
            }
        }


        public static void Draw(MapGenerate map, Person hero, Teleporter teleporter, Trader trader)
        {
            map.PrintDungeon(hero, teleporter, trader);
        }

        public static void Update(Settings settings, Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords, Teleporter teleporter, Trader trader, ref bool gameRun)
        {
            Draw(map, hero, teleporter, trader);
            Interface.DynamicStatistics(hero, coords);
            CheckButton(settings, hero, enemies, map, teleporter, trader, ref gameRun);
            map.EnemiesMovement(enemies);
        }

        public static void CheckButton(Settings settings, Person hero, List<Enemy> enemies, MapGenerate generateMap, Teleporter teleporter, Trader trader, ref bool gameRun)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if (keyInfo == ConsoleKey.E)
            {
                Interface.ClearDynamicLine();
                Interaction.PlayerAttack(hero, enemies, generateMap.GetMap());
            }
            else if (keyInfo == ConsoleKey.W || keyInfo == ConsoleKey.A || keyInfo == ConsoleKey.S || keyInfo == ConsoleKey.D)
            {
                Interface.ClearDynamicLine();
                generateMap.PlayerMovement(hero, keyInfo);
            }
            else if (keyInfo == ConsoleKey.H)
            {
                Interface.ClearDynamicLine();
                hero.Heal();
                Interface.DynamicLineHeal();
            }
            else if (keyInfo == ConsoleKey.T)
            {
                Interface.ClearDynamicLine();
                Interaction.PlayerTeleport(settings, hero, teleporter);
            }
            else if (keyInfo == ConsoleKey.M)
            {
                Interface.ClearDynamicLine();
                Interaction.OpenShop(hero, trader);
            }
            else if (keyInfo == ConsoleKey.Escape)
            {
                gameRun = MainMenu.MainMenuRunInGame(hero);
            }
        }
    }
}
