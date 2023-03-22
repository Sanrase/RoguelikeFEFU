using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoguelikeFEFU
{
    internal class MapGenerate
    {
        public int width = 100;
        public int height = 50;
        public int minRoomSize = 5; 
        public int maxRoomSize = 14; 
        public int maxRooms = 7; 
        public List<Rectangle> rooms = new List<Rectangle>(); 
        public int[,] map;

        public List<Rectangle> GenerateMap()
        {
            Person player;
            Random rand = new Random();
            map = new int[width, height];
            rooms = new List<Rectangle>();
            for (int i = 0; i < maxRooms; i++)
            {
                int roomWidth = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomHeight = rand.Next(minRoomSize, maxRoomSize + 1);
                int roomX = rand.Next(1, width - roomWidth - 1); 
                int roomY = rand.Next(1, height - roomHeight - 1);

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
                            if (x > newRoom.Left && x < newRoom.Right && y > newRoom.Top && newRoom.Bottom < y)
                            {
                                map[x, y] = 0;
                            }
                            else if (x == newRoom.Left || x == newRoom.Right - 1 || y == newRoom.Top || y == newRoom.Bottom - 1)
                            {
                                map[x, y] = 1;
                            }
                            else
                            {
                                map[x, y] = 2;
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
                        if (map[x, firstRoomCenterY] == 2)
                        {
                            continue;
                        }
                        else
                        {
                            map[x, firstRoomCenterY] = 3;
                        }
                    }
                    for (int y = Math.Min(firstRoomCenterY, secondRoomCenterY); y <= Math.Max(firstRoomCenterY, secondRoomCenterY); y++)
                    {
                        if (map[secondRoomCenterX, y] == 2)
                        {
                            continue;
                        }
                        else
                        {
                            map[secondRoomCenterX, y] = 3;
                        }
                    }
                }
                else
                {
                    for (int y = Math.Min(firstRoomCenterY, secondRoomCenterY); y <= Math.Max(firstRoomCenterY, secondRoomCenterY); y++)
                    {
                        if (map[firstRoomCenterX, y] == 2)
                        {
                            continue;
                        }
                        else
                        {
                            map[firstRoomCenterX, y] = 3;
                        }
                    }
                    for (int x = Math.Min(firstRoomCenterX, secondRoomCenterX); x <= Math.Max(firstRoomCenterX, secondRoomCenterX); x++)
                    {
                        if (map[x, secondRoomCenterY] == 2)
                        {
                            continue;
                        }
                        else
                        {
                            map[x, secondRoomCenterY] = 3;
                        }
                    }
                }
            }

            return rooms;
        }

        public int[,] GetMap()
        {
            return map;
        }


        public void PrintDungeon()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] == 1)
                    {
                        Console.Write('#');
                    }
                    else if (map[x, y] == 0)
                    {
                        Console.Write(' ');
                    }
                    else if (map[x, y] == 2)
                    {
                        Console.Write('.');
                    }
                    else {
                        Console.Write('+');
                    }
                }
                Console.WriteLine();
            }
        }

    }

}
