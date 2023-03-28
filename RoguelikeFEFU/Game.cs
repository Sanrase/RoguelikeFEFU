using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security;

namespace RoguelikeFEFU
{
    internal static class Game
    {
        public static void Run(Settings settings)
        {
            bool gameRun = true;
            bool isTeleport = false;
            Person hero;
            List<Enemy> enemies;
            Teleporter teleporter;
            Trader trader;
            MapGenerate map = new MapGenerate(settings);
            Record record;

            map.GenerateMap();
            hero = map.GeneratePlayer();
            enemies = map.GenerateEnemy(hero);
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();

            int[,] coords = Interface.Statistics(30, hero);

            while (gameRun)
            {
                Update(settings, hero, enemies, map, coords, teleporter, trader, ref gameRun, ref isTeleport);
            }
            if (isTeleport)
            {
                Interaction.PlayerTeleport(settings, hero, teleporter, ref gameRun, ref isTeleport);
            }
            MainMenu.MainMenuRun(settings);
        }

        public static void Run(Person hero, MapGenerate map, Settings settings)
        {
            bool gameRun = true;
            bool isTeleport = false;
            ref bool refGameRun = ref gameRun;
            Teleporter teleporter;
            List<Enemy> enemies;
            Trader trader;
            Record record;

            map.GenerateMap();
            enemies = map.GenerateEnemy(hero);
            Interaction.SetPlayerNewLevel(hero, map);
            teleporter = map.GenerateTeleporter();
            trader = map.GenerateTrader();
            Interface.DynamicLineTeleport();

            int[,] coords = Interface.Statistics(30, hero);

            while (gameRun)
            {
                Update(settings, hero, enemies, map, coords, teleporter, trader, ref gameRun,ref isTeleport);
            }
            if (isTeleport)
            {
                Interaction.PlayerTeleport(settings, hero, teleporter, ref gameRun, ref isTeleport);
            }
        }


        public static void Draw(MapGenerate map, Person hero, Teleporter teleporter, Trader trader)
        {
            map.PrintDungeon(hero, teleporter, trader);
        }

        public static void Update(Settings settings, Person hero, List<Enemy> enemies, MapGenerate map, int[,] coords, Teleporter teleporter, Trader trader, ref bool gameRun, ref bool isTeleport)
        {
            Draw(map, hero, teleporter, trader);
            CheckButton(settings, hero, enemies, map, teleporter, trader, ref gameRun, ref isTeleport);
            map.EnemiesMovement(enemies);
            Interface.DynamicStatistics(hero, coords);
        }

        public static void CheckButton(Settings settings, Person hero, List<Enemy> enemies, MapGenerate generateMap, Teleporter teleporter, Trader trader, ref bool gameRun, ref bool isTeleport)
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            if (keyInfo == ConsoleKey.E)
            {
                Interface.ClearDynamicLine();
                Interaction.PlayerAttack(ref gameRun, hero, enemies, generateMap.GetMap());
            }
            else if (keyInfo == ConsoleKey.W || keyInfo == ConsoleKey.A || keyInfo == ConsoleKey.S || keyInfo == ConsoleKey.D)
            {
                Interface.ClearDynamicLine();
                generateMap.PlayerMovement(hero, keyInfo, settings);
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
                Interaction.PlayerTeleport(settings, hero, teleporter, ref gameRun, ref isTeleport);
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

        public static void GameOver(Person hero, ref bool gameRun)
        {
            gameRun = false;
            Interface.GameOver(hero);

            Record record;
            string fullPath = Path.GetFullPath("RecordGame.json");


            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                record = JsonConvert.DeserializeObject<Record>(json);

                if(record != null && record.Level < hero.Level)
                {
                    record.Name = hero.Name;
                    record.Level = hero.Level;
                    record.CountKills = hero.Kills;
                    File.WriteAllText(fullPath, JsonConvert.SerializeObject(record));
                }
                else if(record != null && record.Level == hero.Level && record.CountKills < hero.Kills)
                {
                    record.Name = hero.Name;
                    record.Level = hero.Level;
                    record.CountKills = hero.Kills;
                    File.WriteAllText(fullPath, JsonConvert.SerializeObject(record));
                }
            }
            else
            {
                record = new Record();
                record.Name = hero.Name;
                record.Level = hero.Level;
                record.CountKills = hero.Kills;
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(record));
            }


            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            switch (keyInfo)
            {
                default:
                    break;
            }
        }
    }
}
