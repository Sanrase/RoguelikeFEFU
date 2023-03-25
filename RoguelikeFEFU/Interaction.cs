using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal static class Interaction
    {
        public static void PlayerAttack(Person hero, List<Enemy> enemies, char[,] map)
        {
            Enemy enemy = SearchPlayerAttack(hero, enemies);
            
            if (enemy.IsEnemy)
            {
                enemy.Defense(hero.Damage);
                if(!enemy.IsAlive())
                {
                    Interaction.DeadEnemy(enemy, hero, map);
                    enemies.Remove(enemy);
                }
                hero.Defense(enemy.Damage);
                if (!hero.IsAlive())
                {
                    Interaction.DeadPlayer(hero);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private static Enemy SearchPlayerAttack(Person hero, List<Enemy> enemies)
        {

            Enemy nullEnemy = new Enemy(0, 0, ConsoleColor.White);
            nullEnemy.IsEnemy = false;

            foreach(Enemy enemy in enemies)
            {
                for (int x = hero.X - 1; x <= hero.X + 1; x++)
                {
                    for (int y = hero.Y - 1; y <= hero.Y + 1; y++)
                    {
                        if(enemy.X == x && enemy.Y == y)
                        {
                            return enemy;
                        }
                    }
                }
            }

            return nullEnemy;
        }

        private static void DeadEnemy(Enemy enemy, Person hero, char[,]map)
        {
            Random random = new Random();
            map[enemy.X, enemy.Y] = '.';
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.Write('.');
            hero.Coins = random.Next(enemy.MinCoin, enemy.MaxCoin);
        }

        private static void DeadPlayer(Person hero)
        {

        }

        public static void PlayerHeal(Person hero)
        {
            hero.Heal();
        }
    }
}
