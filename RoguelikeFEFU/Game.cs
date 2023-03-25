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
            Interface.DynamicStatistics(hero, coords);
            Interaction.SetCursorToPlayer(hero);
            CheckButton(hero, enemies, map);
            map.EnemiesMovement(enemies);
        }

        public static void CheckButton(Person hero, List<Enemy> enemies, MapGenerate generateMap)
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
        }
    }
}
