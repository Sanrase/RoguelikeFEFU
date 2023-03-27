﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Lucene.Net.Search.FieldValueHitQueue;

namespace RoguelikeFEFU
{
    internal static class Interaction
    {
        public static void PlayerAttack(Person hero, List<Enemy> enemies, char[,] map)
        {
            Enemy enemy = SearchPlayerAttack(hero, enemies);
            
            if (enemy.IsEnemy)
            {
                enemy.Defense(hero.Damage);
                if(!enemy.IsAlive)
                {
                    DeadEnemy(enemy, hero, map);
                    enemies.Remove(enemy);
                }
                else
                {
                    hero.Defense(enemy.Damage);
                    Interface.DynamicLine(hero, enemy, enemy.Damage);
                }
                if (!hero.IsAlive)
                {
                    DeadPlayer(hero);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public static void PlayerTeleport(Person hero, Teleporter teleporter)
        {
            if (RadiusTeleport(hero, teleporter))
            {
                Console.Clear();
                hero.Level += 1;
                int height = 50, maxRooms = 4, width = 50;
                height += hero.Level * 3;
                width += hero.Level * 3;
                maxRooms += hero.Level;
                MapGenerate genMap = new MapGenerate(width, height, 5, 9, maxRooms);

                Game.Run(hero, genMap);
            }
        }

        private static Enemy SearchPlayerAttack(Person hero, List<Enemy> enemies)
        {

            Enemy nullEnemy = new Enemy(0, 0, ConsoleColor.White);
            nullEnemy.IsEnemy = false;

            foreach(Enemy enemy in enemies)
            {
                for (int x = hero.X - 1; x <= hero.X + 1; x++)
                {
                    for (int y = hero.Y - 1; y <= hero.Y + 1; y++)
                    {
                        if(enemy.X == x && enemy.Y == y)
                        {
                            return enemy;
                        }
                    }
                }
            }

            return nullEnemy;
        }

        public static void SetPlayerNewLevel(Person hero, MapGenerate genMap)
        {
            Rectangle room = genMap.rooms[0];
            char[,] map = genMap.GetMap();

            int heroSpawnX = (room.Left + room.Width / 2);
            int heroSpawnY = (room.Top + room.Height / 2);

            hero.X = heroSpawnX;
            hero.Y = heroSpawnY;

            map[heroSpawnX, heroSpawnY] = hero.Symbol;
        }

        public static void OpenShop(Person hero, Trader trader)
        {
            if (RadiusTrader(hero, trader))
            {
                Console.Clear();
                ConsoleKey keyInfo = ConsoleKey.C;
                Interface.ShopInterface(hero);
                while (keyInfo != ConsoleKey.E)
                {
                    keyInfo = Console.ReadKey(true).Key;
                    switch (keyInfo)
                    {
                        case ConsoleKey.H:
                            trader.BayHeal(hero);
                            Interface.ShopInterface(hero);
                            break;
                        case ConsoleKey.D:
                            trader.BayDamage(hero);
                            Interface.ShopInterface(hero);
                            break;
                        case ConsoleKey.E:
                            Console.Clear();
                            Interface.Statistics(30, hero);
                            break;
                    }
                }
            }
        }

        private static bool RadiusTrader(Person hero, Trader trader)
        {
            for (int x = hero.X - 1; x <= hero.X + 1; x++)
            {
                for (int y = hero.Y - 1; y <= hero.Y + 1; y++)
                {
                    if (trader.X == x && trader.Y == y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool RadiusTeleport(Person hero, Teleporter teleporter)
        {
            for (int x = hero.X - 1; x <= hero.X + 1; x++)
            {
                for (int y = hero.Y - 1; y <= hero.Y + 1; y++)
                {
                    if (teleporter.X == x && teleporter.Y == y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void DeadEnemy(Enemy enemy, Person hero, char[,]map)
        {
            Random random = new Random();
            map[enemy.X, enemy.Y] = '.';
            int coins = random.Next(enemy.MinCoin, enemy.MaxCoin);
            hero.Coins += coins;
            hero.Kills += 1;
            Interface.DynamicLine(coins, hero, enemy);
        }

        private static void DeadPlayer(Person hero)
        {

        }
    }
}
