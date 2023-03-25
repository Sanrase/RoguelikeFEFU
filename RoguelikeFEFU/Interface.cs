using System;
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
            int[,] coords = new int[5,2];
            return Interface.StaticStatistics(mapWidth, coords);
        }

        public static void DynamicStatistics(Person hero, int[,] coords)
        {
            ClearDynamicStatistic(hero, coords);
            Console.SetCursorPosition(coords[0, 0], coords[0, 1]);
            Console.Write(hero.Level);
            Console.SetCursorPosition(coords[1, 0], coords[1, 1]);
            Console.Write(hero.Health);
            Console.SetCursorPosition(coords[2, 0], coords[2, 1]);
            Console.Write(hero.Potion);
            Console.SetCursorPosition(coords[3, 0], coords[3, 1]);
            Console.Write(hero.Coins);
        }

        private static void ClearDynamicStatistic(Person hero, int[,] coords)
        {
            Console.SetCursorPosition(coords[0, 0], coords[0, 1]);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(coords[1, 0], coords[1, 1]);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(coords[2, 0], coords[2, 1]);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(coords[3, 0], coords[3, 1]);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(' ');
            }
        }
        private static int[,] StaticStatistics(int mapWidth, int[,] coords)
        {
            mapWidth += 8;
            int y = 15;
            Console.SetCursorPosition(mapWidth, y-1);
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

            return coords;
        }

        public static void DrawBox(int x, int width, int height)
        {
            int y = 13;
            x += 4;
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

        public static void Add(int[,] coords, int i, int x, int y)
        {
            coords[i,0] = x;
            coords[i, 1] = y;
        }

    }
}
