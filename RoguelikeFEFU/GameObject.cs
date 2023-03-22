using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    public class GameObject
    {
        protected int x = 0;
        protected int y = 0;
        public ConsoleColor color;

        public GameObject(int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }

    public class Entity : GameObject
    {
        public int Health  { get; set;}
        public int Attack  { get; set;}
        public int Defense  { get; set; }

        public Entity(int x, int y, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            this.Health = 10;
            this.Attack = 1;
            this.Defense = 1;
        }
    }
    public class Person : Entity
    {
        public int Potion { get; set; }
        protected int[] inventory = new int[5];
        public char Symbol { get; set; }
        public Person(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            this.Symbol = '@';
            this.Potion = 3;
        }

        public void Heal()
        {
            if (this.Potion > 0)
            {
                this.Health = 10;
                this.Potion -= 1;
            }
            else
            {
                this.Health -= 1;
            }
        }

        //public void Move(int x, int y, int[,] map)
        //{
        //    ConsoleKeyInfo key = Console.ReadKey();

        //    switch (key)
        //    {

        //        case key.Key == ConsoleKey.W:

        //    }
        //}

        public void Attack()
        {

        }

    }

    internal class Enemy : Entity
    {
        public char Symbol { get; set; }
        public Enemy(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            this.Health = 13;
            this.Attack = 3;
            this.Defense = 0;
            this.Symbol = 'S';
        }
    }

}
