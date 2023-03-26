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
            DrawBox(30, 4, 20, 15);
            DynamicStatistics(hero, coords);
            return StaticStatistics(mapWidth, coords);
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
            for(int i = 0; i < n; i++)
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

            y += 2;
            Console.SetCursorPosition(mapWidth, y);
            Console.Write("Убийств: ");
            (left, top) = Console.GetCursorPosition();
            Interface.Add(coords, 4, left, top);

            return coords;
        }

        public static void DrawBox(int x, int y, int width, int height)
        {
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

        public static void ShopInterface(Person hero, int[,] coords)
        {
            int setX = 5;
            int setY = 5;
            DrawBox(setX, setY, 30, 15);

            ShopStaticInterface(setX, setY, coords);
            ShopDynamicInterface(hero, coords);
        }

        private static void ShopDynamicInterface(Person hero, int[,] coords)
        {
            ClearDynamicStatistic(coords, 1);

            Console.SetCursorPosition(coords[0,0], coords[0,1]);
            Console.Write(hero.Coins);
            Console.SetCursorPosition(1, 1);
        }

        private static void ShopStaticInterface(int setX, int setY, int[,] coords)
        {
            Console.SetCursorPosition(setX + 15, setY+1);
            Console.Write("Магазин");
            setY += 3
                ;
            Console.SetCursorPosition(setX + 10, setY);
            Console.Write("Монеты: ");
            (int left, int top) = Console.GetCursorPosition();
            coords[0, 0] = left;
            coords[0, 1] = top;


            setY += 2;
            Console.SetCursorPosition(setX + 6, setY);
            Console.Write("Тип");
            Console.SetCursorPosition(setX + 15, setY);
            Console.Write("Цена");
            Console.SetCursorPosition(setX + 23, setY);
            Console.Write("Кнопка");

            setY += 3;
            
            Console.SetCursorPosition(setX + 6, setY);
            Console.Write("Зелье     10       H");

            setY += 2;

            Console.SetCursorPosition(setX + 6, setY);
            
        }

        public static void Add(int[,] coords, int i, int x, int y)
        {
            coords[i,0] = x;
            coords[i, 1] = y;
        }

    }
}
