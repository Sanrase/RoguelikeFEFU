using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lucene.Net.Util;

namespace RoguelikeFEFU
{
    internal class MapGenerate
    {
        private int width;
        private int heigth;
        private int minRoomSize; 
        private int maxRoomSize; 
        private int maxRooms;
        private int maxEnemyMap = 10;
        private int level = 1;
        private List<Rectangle> rooms = new List<Rectangle>(); 
        private char[,] map;
        private List<Enemy> enemies = new List<Enemy>();
        public Person hero;

        public MapGenerate(int width = 100, int height = 50, int minRoomSize = 5, int maxRoomSize = 14, int maxRooms = 7)
        {
            this.width = width;
            this.heigth = height;
            this.minRoomSize = minRoomSize;
            this.maxRoomSize = maxRoomSize;
            this.maxRooms = maxRooms;
        }

        private void FillMap()
        {
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < heigth; y++)
                {
                    map[x, y] = ' ';
                }
            }
        }

        public void GenerateMap()
        {
            Random rand = new Random();
            map = new char[width, heigth];
            rooms = new List<Rectangle>();
            this.FillMap();

            for (int i = 0; i < maxRooms; i++)
            {
                int roomWidth = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomHeight = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomX = rand.Next(1, width - roomWidth - 1); 
                int roomY = rand.Next(1, heigth - roomHeight - 1);

                Rectangle newRoom = new Rectangle(roomX, roomY, roomWidth, roomHeight);
                bool roomIntersects = false;

                foreach (Rectangle room in rooms)
                {
                    if (newRoom.IntersectsWith(room))
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

        public List<Enemy> SetEnemy()
        {
            Random rand = new Random();
            int countEnemyRoom = rand.Next(1, 3);

            for(int i = 1; i < rooms.Count; i++)
            {
                int enemySpawnX = rand.Next(rooms[i].Left + 1, rooms[i].Right - 1);
                int enemySpawnY = rand.Next(rooms[i].Top + 1, rooms[i].Bottom - 1);
                for (int j = 0; j < countEnemyRoom; j++)
                {
                    Enemy enemy = new Enemy(enemySpawnX, enemySpawnY, ConsoleColor.Blue);
                    enemies.Add(enemy);
                    map[enemySpawnX, enemySpawnY] = enemy.Symbol;
                }
            }

            return enemies;
        }
        
        public Person SetHero()
        {
            int heroSpawnX = (rooms[0].Left + rooms[0].Width / 2);
            int heroSpawnY = (rooms[0].Top + rooms[0].Height / 2);

            hero = new Person(heroSpawnX, heroSpawnY, ConsoleColor.Red);
            map[heroSpawnX, heroSpawnY] = hero.Symbol;

            return hero;

        }

        public void PrintDungeon()
        {
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

    }
}
