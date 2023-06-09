﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using Lucene.Net.Search;
using Lucene.Net.Util;
using System.Dynamic;

namespace RoguelikeFEFU
{
    internal static class Interface
    {
        public static int[,] Statistics(int mapWidth, Person hero)
        {
            int[,] coords = new int[5, 2];
            DrawBox(34, 4, 20, 15);
            coords = StaticStatistics(mapWidth, coords);
            DynamicStatistics(hero, coords);
            return coords;
        }

        public static void DynamicStatistics(Person hero, int[,] coords)
        {
            ClearDynamicStatistic(coords, 5);
            Console.SetCursorPosition(coords[0, 0], coords[0, 1]);
            Console.Write(hero.Level);
            Console.SetCursorPosition(coords[1, 0], coords[1, 1]);
            Console.Write(hero.Health);
            Console.SetCursorPosition(coords[2, 0], coords[2, 1]);
            Console.Write(hero.Potion);
            Console.SetCursorPosition(coords[3, 0], coords[3, 1]);
            Console.Write(hero.Coins);
            Console.SetCursorPosition(coords[4, 0], coords[4, 1]);
            Console.Write(hero.Kills);
            Console.SetCursorPosition(20, 10);
        }

        private static void ClearDynamicStatistic(int[,] coords, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.SetCursorPosition(coords[i, 0], coords[i, 1]);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(' ');
                }
            }
        }
        private static int[,] StaticStatistics(int mapWidth, int[,] coords)
        {
            mapWidth += 8;
            int y = 6;
            Console.SetCursorPosition(mapWidth, y - 1);
            Console.Write("Cтатистика:");

            mapWidth -= 2;
            y += 1;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Уровень: ");
            (int left, int top) = Console.GetCursorPosition();
            Interface.Add(coords, 0, left, top);

            y += 2;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Здоровье: ");
            (left, top) = Console.GetCursorPosition();
            Interface.Add(coords, 1, left, top);

            y += 2;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Зелья: ");
            (left, top) = Console.GetCursorPosition();
            Interface.Add(coords, 2, left, top);

            y += 2;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Монеты: ");
            (left, top) = Console.GetCursorPosition();
            Interface.Add(coords, 3, left, top);

            y += 2;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Убийств: ");
            (left, top) = Console.GetCursorPosition();
            Interface.Add(coords, 4, left, top);

            return coords;
        }

        public static void DrawBox(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for (int i = 1; i < width - 1; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write("═");
            }
            Console.SetCursorPosition(x + width - 1, y);
            Console.Write("╗");

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("║");
                Console.SetCursorPosition(x + width - 1, y + i);
                Console.Write("║");
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚");
            for (int i = 1; i < width - 1; i++)
            {
                Console.SetCursorPosition(x + i, y + height - 1);
                Console.Write("═");
            }
            Console.SetCursorPosition(x + width - 1, y + height - 1);
            Console.Write("╝");
        }

        public static void ShopInterface(Person hero)
        {
            int setX = 15;
            int setY = 5;
            DrawBox(setX, setY, 30, 15);

            ShopStaticInterface(hero, setX, setY);
        }

        private static void ShopStaticInterface(Person hero, int setX, int setY)
        {
            Console.SetCursorPosition(setX + 14, setY + 1);
            Console.Write("Лавка");
            setY += 4;

            Console.SetCursorPosition(setX + 6, setY);
            Console.Write("Тип");
            Console.SetCursorPosition(setX + 15, setY);
            Console.Write("Цена");

            setY += 2;

            Console.SetCursorPosition(setX + 6, setY);
            Console.Write("Зелье     10");

            setY += 2;

            Console.SetCursorPosition(setX + 6, setY);
            Console.Write("Урон(+1)  20");

            DynamicLineInShop(hero);
        }

        public static void Add(int[,] coords, int i, int x, int y)
        {
            coords[i, 0] = x;
            coords[i, 1] = y;
        }

        public static void ClearDynamicLine()
        {
            int setY = 21;
            int setX = 2;

            for (; setY <= 22; setY++)
            {
                Console.SetCursorPosition(setX, setY);
                for (int i = 0; i < 62; i++)
                {
                    Console.Write(' ');
                }
            }
        }

        public static void DynamicLine(Person hero, Enemy enemy, int damageGiven)
        {
            Console.SetCursorPosition(2, 21);
            Console.Write($"Вы нанесли врагу {enemy.Name} - {hero.Damage} урона. И получили в ответ {damageGiven} урона.");
            Console.SetCursorPosition(2, 22);
            Console.Write($"У врага {enemy.Name} осталось {enemy.Health} здоровья");
            Console.SetCursorPosition(0, 0);
        }

        public static void DynamicLine(int coins, Person hero, Enemy enemy)
        {
            Console.SetCursorPosition(2, 21);
            Console.Write($"Вы нанесли врагу {enemy.Name} - {hero.Damage} урона.");
            Console.SetCursorPosition(2, 22);
            Console.Write($"Вы убили врага {enemy.Name}. За это вы получили {coins} монет");
            Console.SetCursorPosition(0, 0);
        }

        public static void DynamicLineHeal()
        {
            Console.SetCursorPosition(2, 21);
            Console.Write("Вы выпиваете зелье здоровья.");
            Console.SetCursorPosition(0, 0);
        }

        public static void DynamicLineTeleport()
        {
            Console.SetCursorPosition(2, 21);
            Console.Write("Вы перешли на новый уровень.");
            Console.SetCursorPosition(0, 0);
        }

        private static void ClearDynamicLineInShop()
        {
            int setX = 4;
            int setY = 21;

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(setX, setY);
                for (int j = 0; j < 50; j++)
                {
                    Console.Write(' ');
                }
                setY++;
            }
        }

        public static void DynamicLineMenuSettingsButton(Person hero)
        {
            Console.SetCursorPosition(35, 23);
            Console.Write($"{hero.Name} вы не можете войти в настройки во время игры!");
            Console.SetCursorPosition(0, 0);
        }
        private static void DynamicLineInShop(Person hero)
        {
            ClearDynamicLineInShop();
            Console.SetCursorPosition(4, 21);
            Console.Write($"Вы входите в лавку. Ваше количество монет: {hero.Coins}");
            Console.SetCursorPosition(4, 22);
            Console.Write("Чтобы купить зелье здоровья нажмите (H).");
            Console.SetCursorPosition(4, 23);
            Console.Write("Если хотите улучшить свой меч нажмите (D).");
            Console.SetCursorPosition(4, 24);
            Console.Write("чтобы выйти из лавки нажмите (E).");
            Console.SetCursorPosition(0, 0);
        }

        private static void GameOverStatistic(Person hero)
        {
            Console.SetCursorPosition(35, 9);
            Console.Write("╔═════════════════╗");
            Console.SetCursorPosition(35, 10);
            Console.Write("║    GAME OVER    ║");
            Console.SetCursorPosition(35, 11);
            Console.Write("╚═════════════════╝");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(35, 13);
            Console.Write("     Статистика");
            Console.ResetColor();
            Console.SetCursorPosition(35, 15);
            Console.Write($"   Имя: {hero.Name}");
            Console.SetCursorPosition(35, 17);
            Console.Write($"   Уровень карты: {hero.Level}");
            Console.SetCursorPosition(35, 19);
            Console.Write($"   Убийств: {hero.Kills}");
            Console.SetCursorPosition(0, 0);
        }

        public static void GameOver(Person hero)
        {
            Console.Clear();
            DrawBox(30, 8, 30, 15);

            GameOverStatistic(hero);
        }
    }
}
