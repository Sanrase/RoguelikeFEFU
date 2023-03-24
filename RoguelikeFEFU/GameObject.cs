using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        public GameObject(int x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            Color = color;
        }
    }

    public class Entity : GameObject
    {
        public int Health  { get; set; }
        public int Attack  { get; set; }
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
        public int Coins { get; set; }
        public int Level { get; set; }
        protected int[] inventory = new int[5];
        public char Symbol { get; set; }
        public Person(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            Symbol = '@';
            Potion = 3;
            Coins = 10;
            Level = 0;

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

        public void Attack()
        {
            
        }

    }

    internal class Enemy : Entity
    {
        public char Symbol { get; set; }
        public int MinCoin { get; set; }
        public int MaxCoin { get; set; }

        public Enemy(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }

    }

    internal class Kobolt : Enemy
    {
        
        public Kobolt(int x, int y, ConsoleColor color) : base (x, y, color)
        {
            Symbol = 'K';
            Health = 7;
            Attack = 1;
            Defense = 1;
            MaxCoin = 7;
            MinCoin = 3;
            
        }
    }

    internal class Snake : Enemy
    {
        public Snake(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            Symbol = 'S';
            Health = 10;
            Attack = 2;
            Defense = 2;
            MaxCoin = 5;
            MinCoin = 1;
        }
    }

}
