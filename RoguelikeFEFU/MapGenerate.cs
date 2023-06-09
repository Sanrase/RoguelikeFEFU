﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoguelikeFEFU
{
    internal class MapGenerate
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private int minRoomSize;
        private int maxRoomSize;
        private int maxRooms;
        public List<Rectangle> rooms = new List<Rectangle>();
        private char[,] map;
        private List<Enemy> enemies = new List<Enemy>();
        public Teleporter teleporter;
        public Settings settings;

        public MapGenerate(Settings settings, int minRoomSize = 5, int maxRoomSize = 9)
        {
            this.settings = settings;
            Width = settings.Width;
            Height = settings.Height;
            this.minRoomSize = minRoomSize;
            this.maxRoomSize = maxRoomSize;
            this.map = new char[settings.Width, settings.Height];
            this.maxRooms = settings.CountRooms;
        }

        private void FillMap()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    map[x, y] = ' ';
                }
            }
        }

        public void GenerateMap()
        {
            Random rand = new Random();
            map = new char[Width, Height];
            rooms = new List<Rectangle>();
            FillMap();

            for (int i = 0; i < maxRooms; i++)
            {
                int roomWidth = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomHeight = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomX = rand.Next(1, Width - roomWidth - 1);
                int roomY = rand.Next(1, Height - roomHeight - 1);

                Rectangle newRoom = new Rectangle(roomX, roomY, roomWidth, roomHeight);
                bool roomIntersects = false;

                foreach (Rectangle room in rooms)
                {
                    Rectangle copyRoom = Rectangle.Inflate(room, 2, 2);
                    if (newRoom.IntersectsWith(copyRoom))
                    {
                        roomIntersects = true;
                        break;
                    }
                }
                if (!roomIntersects)
                {
                    rooms.Add(newRoom);
                    for (int x = newRoom.Left; x < newRoom.Right; x++)
                    {
                        for (int y = newRoom.Top; y < newRoom.Bottom; y++)
                        {
                            if (x == newRoom.Left || x == newRoom.Right - 1 || y == newRoom.Top || y == newRoom.Bottom - 1)
                            {
                                map[x, y] = '#';
                            }
                            else
                            {
                                map[x, y] = '.';
                            }
                        }
                    }
                }

            }

            for (int i = 0; i < rooms.Count - 1; i++)
            {
                int firstRoomCenterX = (int)(rooms[i].Left + rooms[i].Width / 2);
                int firstRoomCenterY = (int)(rooms[i].Top + rooms[i].Height / 2);
                int secondRoomCenterX = (int)(rooms[i + 1].Left + rooms[i + 1].Width / 2);
                int secondRoomCenterY = (int)(rooms[i + 1].Top + rooms[i + 1].Height / 2);

                if (new Random().Next(0, 2) == 0)
                {
                    for (int x = Math.Min(firstRoomCenterX, secondRoomCenterX); x <= Math.Max(firstRoomCenterX, secondRoomCenterX); x++)
                    {
                        if (map[x, firstRoomCenterY] == '.')
                        {
                            continue;
                        }
                        else
                        {
                            map[x, firstRoomCenterY] = '+';
                        }
                    }
                    for (int y = Math.Min(firstRoomCenterY, secondRoomCenterY); y <= Math.Max(firstRoomCenterY, secondRoomCenterY); y++)
                    {
                        if (map[secondRoomCenterX, y] == '.')
                        {
                            continue;
                        }
                        else
                        {
                            map[secondRoomCenterX, y] = '+';
                        }
                    }
                }
                else
                {
                    for (int y = Math.Min(firstRoomCenterY, secondRoomCenterY); y <= Math.Max(firstRoomCenterY, secondRoomCenterY); y++)
                    {
                        if (map[firstRoomCenterX, y] == '.')
                        {
                            continue;
                        }
                        else
                        {
                            map[firstRoomCenterX, y] = '+';
                        }
                    }
                    for (int x = Math.Min(firstRoomCenterX, secondRoomCenterX); x <= Math.Max(firstRoomCenterX, secondRoomCenterX); x++)
                    {
                        if (map[x, secondRoomCenterY] == '.')
                        {
                            continue;
                        }
                        else
                        {
                            map[x, secondRoomCenterY] = '+';
                        }
                    }
                }
            }
        }

        public List<Enemy> GenerateEnemy(Person hero)
        {
            Random rand = new Random();

            for (int i = 1; i < rooms.Count-1; i++)
            {
                int countEnemyRoom = rand.Next(1, 4);
                if (new Random().Next(0, 5) != 0)
                {
                    for (int j = 0; j < countEnemyRoom; j++)
                    {
                        int enemySpawnX = rand.Next(rooms[i].Left + 1, rooms[i].Right - 1);
                        int enemySpawnY = rand.Next(rooms[i].Top + 1, rooms[i].Bottom - 1);

                        if (new Random().Next(0, 2) == 0)
                        {
                            Snake snake = new Snake(enemySpawnX, enemySpawnY, settings.ColorSnake);
                            snake.Health += hero.Damage / 2;
                            enemies.Add(snake);
                            map[enemySpawnX, enemySpawnY] = snake.Symbol;
                        }
                        else
                        {
                            Kobalt kobalt = new Kobalt(enemySpawnX, enemySpawnY, settings.ColorKobalt);
                            kobalt.Health += hero.Damage / 2;
                            enemies.Add(kobalt);
                            map[enemySpawnX, enemySpawnY] = kobalt.Symbol;
                        }
                    }
                }
            }

            if (hero.Level % 3 == 0)
            {
                int enemySpawnX = rand.Next(rooms[rooms.Count - 1].Left + 1, rooms[rooms.Count - 1].Right - 1);
                int enemySpawnY = rand.Next(rooms[rooms.Count - 1].Top + 1, rooms[rooms.Count - 1].Bottom - 1);

                Boss boss = new Boss(enemySpawnX, enemySpawnY, settings.ColorBoss);
                enemies.Add(boss);
                map[enemySpawnX, enemySpawnY] = boss.Symbol;
            }

            return enemies;
        }

        public Person GeneratePlayer()
        {
            Person hero;
            int heroSpawnX = (rooms[0].Left + rooms[0].Width / 2);
            int heroSpawnY = (rooms[0].Top + rooms[0].Height / 2);

            hero = new Person(heroSpawnX, heroSpawnY, settings.PlayerColor, settings.PlayerSymbol, settings.PlayerName);
            map[heroSpawnX, heroSpawnY] = hero.Symbol;

            return hero;

        }

        public Teleporter GenerateTeleporter()
        {
            int teleporterSpawnX = rooms[rooms.Count - 1].Left + rooms[rooms.Count - 1].Width / 2;
            int teleporterSpawnY = rooms[rooms.Count - 1].Top + rooms[rooms.Count - 1].Height / 2;


            teleporter = new Teleporter(teleporterSpawnX, teleporterSpawnY, ConsoleColor.Red);
            map[teleporterSpawnX, teleporterSpawnY] = teleporter.Symbol;

            return teleporter;
        }

        public Trader GenerateTrader()
        {

            Random rand = new Random();
            int countRoom = rand.Next(1, rooms.Count - 1);

            int traderSpawnX = rooms[countRoom].Left + rooms[countRoom].Width / 2;
            int traderSpawnY = rooms[countRoom].Top + rooms[countRoom].Height / 2;

            Trader trader = new Trader(traderSpawnX, traderSpawnY, ConsoleColor.DarkRed);
            map[traderSpawnX, traderSpawnY] = trader.Symbol;

            return trader;
        }

        public void EnemiesMovement(List<Enemy> enemies)
        {
            Random rand = new Random();

            foreach (Enemy enemy in enemies)
            {
                int x = enemy.X;
                int y = enemy.Y;

                int enemyMoveSide = rand.Next(0, 4);

                switch (enemyMoveSide)
                {
                    case 0:
                        this.SetEnemyPosition(x, y - 1, enemy, settings);
                        break;
                    case 1:
                        this.SetEnemyPosition(x - 1, y, enemy, settings);
                        break;
                    case 2:
                        this.SetEnemyPosition(x, y + 1, enemy, settings);
                        break;
                    case 3:
                        this.SetEnemyPosition(x + 1, y, enemy, settings);
                        break;

                }

            }
        }

        private void SetEnemyPosition(int x, int y, Enemy enemy, Settings settings)
        {
            if (map[x, y] == '#' || map[x, y] == ' ' || map[x, y] == settings.snakeSymbol || map[x, y] == settings.PlayerSymbol || map[x, y] == '+' || map[x, y] == settings.kobaltSymbol
                || map[x, y] == 'T' || map[x, y] == '*' || map[x, y] == settings.boosSymbol)
            {
                return;
            }
            else
            {
                map[enemy.X, enemy.Y] = '.';
                enemy.X = x;
                enemy.Y = y;
                map[x, y] = enemy.Symbol;
            }
        }
        char current = '.';

        public void PlayerMovement(Person hero, ConsoleKey key, Settings settings)
        {
            int x = hero.X;
            int y = hero.Y;


            switch (key)
            {
                case ConsoleKey.W:
                    current = SetPlayerPosition(x, y - 1, current, hero, settings);
                    break;
                case ConsoleKey.A:
                    current = SetPlayerPosition(x - 1, y, current, hero, settings);
                    break;
                case ConsoleKey.S:
                    current = SetPlayerPosition(x, y + 1, current, hero, settings);
                    break;
                case ConsoleKey.D:
                    current = SetPlayerPosition(x + 1, y, current, hero, settings);
                    break;
            }
        }

        private char SetPlayerPosition(int x, int y, char current, Person hero, Settings settings)
        {
            if (map[x, y] == '#' || map[x, y] == ' ' || map[x, y] == settings.snakeSymbol || map[x, y] == settings.kobaltSymbol || map[x, y] == settings.boosSymbol)
            {
                return current;
            }
            else
            {
                map[hero.X, hero.Y] = current;
                hero.X = x;
                hero.Y = y;
                current = map[x, y];
                map[x, y] = hero.Symbol;


                return current;
            }
        }

        public char[,] GetMap()
        {
            return map;
        }
        public void PrintDungeon(Person hero, Teleporter teleporter, Trader trader)
        {
            int setX = 10;
            int setY = 5;
            int playerX = 10;
            int playerY = 5;

            int leftBound = Math.Max(0, hero.X - playerX);
            int rightBound = Math.Min(Width, hero.X + playerX);
            int topBound = Math.Max(0, hero.Y - playerY);
            int bottomBound = Math.Min(Height, hero.Y + playerY);
            
            for(int y = topBound; y < bottomBound; y++, setY++)
            {
                Console.SetCursorPosition(setX, setY);
                for (int x = leftBound; x < rightBound; x++)
                {
                    if (hero.X == x && hero.Y == y)
                    {
                        Console.ForegroundColor = hero.Color;
                        Console.Write(hero.Symbol);
                        Console.ResetColor();
                    }else if(teleporter.X == x && teleporter.Y == y)
                    {
                        Console.ForegroundColor = teleporter.Color;
                        Console.Write(teleporter.Symbol);
                        Console.ResetColor();
                    }
                    else if(trader.X == x && trader.Y == y)
                    {
                        Console.ForegroundColor = trader.Color;
                        Console.Write(trader.Symbol);
                        Console.ResetColor();
                    }
                    else
                    {
                        bool inMap = false;
                        foreach(Enemy enemy in enemies)
                        {
                            if (EnemyInMap(enemy, x, y))
                            {
                                Console.ForegroundColor = enemy.Color;
                                Console.Write(enemy.Symbol);
                                Console.ResetColor();
                                inMap = true;
                            }
                        }

                        if (!inMap)
                        {
                            Console.Write(map[x, y]);
                        }
                    }
                }
            }
        }

        private static bool EnemyInMap(Enemy enemy, int x, int y)
        {
            if(enemy.X == x && enemy.Y == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
