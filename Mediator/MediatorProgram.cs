using System;

namespace Mediator
{
    public interface IMediator
    {
        public void Notify(int damage, Character targer);
    }

    public abstract class Character
    {
        protected IMediator mediator;
        protected int damage;
        protected int health;

        protected Character(Game mediator, int damage, int health)
        {
            this.mediator = mediator;
            this.damage = damage;
            this.health = health;
        }

        public abstract void Attack(Character target);
        public abstract void TakeDamage(int damage);
    }

    public class Player : Character
    {
        public Player(Game mediator, int damage, int health) : base(mediator, damage, health){}

        public override void Attack(Character target)
        {
            //Console.WriteLine(health);
            if (health > 0)
            {
                mediator.Notify(damage, target);
            }
            else
            {
                Console.WriteLine("Player can't attack cause it is dead");
            }
        }

        public override void TakeDamage(int damage)
        {
            if (health <= 0)
            {
                Console.WriteLine("Player is dead");
                return;
            }

            if (health - damage <= 0)
            {
                Console.WriteLine("The hit was lethal. Game Over...");
                health = 0;
            }
            else
            {
                health -= damage;
                Console.WriteLine($"Player got hit for {damage} damagae\n" +
                                  $"Health left: {health}");
            }
        }
    }
    
    public class Enemy : Character
    {
        public Enemy(Game mediator, int damage, int healh) : base(mediator, damage, healh){}

        public override void Attack(Character target)
        {
            if (health > 0)
            {
                mediator.Notify(damage, target);
            }
            else
            {
                Console.WriteLine("Enemy can't attack cause it is dead");
            }
        }

        public override void TakeDamage(int damage)
        {
            if (health <= 0)
            {
                Console.WriteLine("Enemy is dead");
                return;
            }

            if (health - damage <= 0)
            {
                Console.WriteLine("The hit was lethal. Enemy has died");
                health = 0;
            }
            else
            {
                health -= damage;
                Console.WriteLine($"Enemy got hit for {damage} damagae\n" +
                                  $"Health left: {health}");
            }
        }
    }

    public class Game : IMediator
    {
        public void Notify(int damage, Character targer)
        {
            targer.TakeDamage(damage);
        }
    }
    
    class MediatorProgram
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var player = new Player(game, 50, 100);
            var enemy = new Enemy(game, 10, 200);

            for (var i = 0; i < 4; i++)
            {
                player.Attack(enemy);
                enemy.Attack(player);
            }

        }
    }
}