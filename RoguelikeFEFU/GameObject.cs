using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal class GameObject
    {
        protected int x = 0;
        protected int y = 0;
        protected ConsoleColor color = ConsoleColor.White;

        public GameObject(int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }   
    }

    internal class Entity : GameObject
    {
        protected int health = 10;
        protected int attack = 1;
        protected int defense = 1;

        public Entity(int health, int attack, int defense, int x, int y, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }

        public override void Move(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
        }
    }
     internal class Persone : Entity
    {
        protected int potion = 3;
        protected int[] inventory = new int[5];
        public Persone(int health, int attack, int defense, int x, int y, ConsoleColor color) : base(health, attack, defense, x, y, color)
        {

        }

        public void Heal()
        {
            if (this.potion > 0)
            {
                this.health = 10;
                this.potion -= 1;
            }
            else
            {
                this.health -= 1;
            }
        }

        public virtual void Move()
        {

        }
    }
}
