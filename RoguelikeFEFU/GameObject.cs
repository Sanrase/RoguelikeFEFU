using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        public int Damage  { get; set; }

        public Entity(int x, int y, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            Health = 10;
            Damage = 1;
        }

        public void Defense(int damage)
        {
            this.Health -= damage;
        }

        public bool IsAlive()
        {
            if (Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public class Person : Entity
    {
        public int Potion { get; set; }

        private int coins;
        public int Coins
        {
            get
            {
                return this.coins;
            }

            set
            {
                this.coins += value;
            }
        }
        public int Level { get; set; }

        protected int[] inventory = new int[5];
        public char Symbol { get; set; }
        public Person(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            Symbol = '@';
            Potion = 3;
            this.coins = 0;
            Damage = 5;

        }

        public void Heal()
        {
            if (this.Potion > 0)
            {
                this.Health = 10;
                this.Potion -= 1;
            }
        }
    }

    internal class Enemy : Entity
    {
        public char Symbol { get; set; }
        public int MinCoin { get; set; }
        public int MaxCoin { get; set; }
        public bool IsEnemy { get; set; }

        public Enemy(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            IsEnemy = true;
        }

    }

    internal class Kobolt : Enemy
    {
        
        public Kobolt(int x, int y, ConsoleColor color) : base (x, y, color)
        {
            Symbol = 'K';
            Health = 7;
            Damage = 1;
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
            Damage = 2;
            MaxCoin = 5;
            MinCoin = 1;
        }
    }

}
