using System;

namespace Strategy
{
    public class Enemy
    {
        private int _armor;
        private int _magicResist;

        public Enemy(int armor, int magicResist)
        {
            _armor = armor;
            _magicResist = magicResist;
        }

        public int GetArmor()
        {
            return _armor;
        }

        public int GetMagicResist()
        {
            return _magicResist;
        }
    }

    public interface IStrategy
    {
        public void Attack(Enemy enemy);
    }

    public class PhysicalAttack : IStrategy
    {
        public void Attack(Enemy enemy)
        {
            int armor = enemy.GetArmor();
            int damage = armor > 60 ? 0 : 60 - armor;
            
            Console.WriteLine($"Physical attack has dealt {damage} damage");
        }
    }
    
    public class AbilityAttack : IStrategy
    {
        public void Attack(Enemy enemy)
        {
            int magicResist = enemy.GetMagicResist();
            int damage = magicResist > 60 ? 0 : 60 - magicResist;
            
            Console.WriteLine($"Ability attack has dealt {damage} damage");
        }
    }

    public class Player
    {
        private IStrategy _attackStrategy;

        public Player(IStrategy strategy)
        {
            _attackStrategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _attackStrategy = strategy;
        }

        public void Attack(Enemy enemy)
        {
            _attackStrategy.Attack(enemy);
        }
    }
    class StrategyProgram
    {
        static void Main(string[] args)
        {
            IStrategy physicalAttack = new PhysicalAttack();
            IStrategy abilityAttack = new AbilityAttack();

            Player player = new Player(physicalAttack);

            Enemy malphite = new Enemy(150, 40);
            
            player.Attack(malphite);
            player.SetStrategy(abilityAttack);
            player.Attack(malphite);
        }
    }
}