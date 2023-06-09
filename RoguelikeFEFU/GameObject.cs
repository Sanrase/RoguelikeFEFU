﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
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
        public bool IsAlive { get; set; }



        public Entity(int x, int y, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            Health = 10;
            Damage = 1;
            IsAlive = true;
        }

        public void Defense(int damage)
        {
            Health -= damage;
            if(Health <= 0)
            {
                IsAlive = false;
            }
        }

    }
    public class Person : Entity
    {
        public int Potion { get; set; }

        public int Kills { get; set; }

        public int Coins { get; set; }
        public int Level { get; set; }

        public string Name { get; set; }

        protected int[] inventory = new int[5];
        public char Symbol { get; set; }
        public Person(int x, int y, ConsoleColor color, char symbol = '@', string name = "Ace") : base(x, y, color)
        {
            Symbol = symbol;
            Name = name;
            Potion = 3;
            Coins = 0;
            Level = 1;
            Damage = 5;
            Kills = 0;
        }

        public void Heal()
        {
            if (Potion > 0)
            {
                Health = 10;
                Potion -= 1;
            }
        }
    }

    internal class Enemy : Entity
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public int MinCoin { get; set; }
        public int MaxCoin { get; set; }
        public bool IsEnemy { get; set; }

        public Enemy(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            IsEnemy = true;
        }

    }

    internal class Kobalt : Enemy
    {
        
        public Kobalt(int x, int y, ConsoleColor color) : base (x, y, color)
        {
            Symbol = 'K';
            Health = 7;
            Damage = 1;
            MaxCoin = 7;
            MinCoin = 3;
            Name = "Kobalt";
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
            Name = "Snake";
        }
    }

    internal class Trader : GameObject
    {
        public char Symbol { get; set; }
        public Trader(int x, int y, ConsoleColor color) : base(x, y, color) { Symbol = 'T'; }

        public void BayHeal(Person hero)
        {
            if(hero.Coins >= 10)
            {
                hero.Potion = hero.Potion + 1;
                hero.Coins -= 10;
            }

        }

        public void BayDamage(Person hero)
        {
            if(hero.Coins >= 20)
            {
                hero.Damage = hero.Damage + 1;
                hero.Coins -= 20;
            }
        }
    }

    internal class Boss : Enemy
    {
        private bool bossIsAllive = true;
        public Boss(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            Health = 20;
            Damage = 4;
            Symbol = 'B';
        }
    }

    internal class Teleporter : Entity
    {
        public char Symbol { get; set; }
        public Teleporter(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            Symbol = '*';
        }
    }
}
