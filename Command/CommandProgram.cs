using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Command
{
    public interface ICommand
    {
        public void Execute();
    }

    public class Farm
    {
        private int _windmillLevel = 1;
        private int _shedLevel = 1;
        private int _money = 0;

        public int GetWindmillLevel()
        {
            return _windmillLevel;
        }

        public int GetShedLevel()
        {
            return _shedLevel;
        }

        public int GetMoney()
        {
            return _money;
        }

        public void UpgradeWindmillLevel()
        {
            _windmillLevel += 1;
        }

        public void UpgradeShedLevel()
        {
            _shedLevel += 1;
        }

        public void SetMoney(int money)
        {
            _money = money;
        }
    }

    public class ShedUpgrade : ICommand
    {
        private Farm _farm;
        
        public ShedUpgrade(Farm farm)
        {
            _farm = farm;
        }

        public void Execute()
        {
            int shedLevel = _farm.GetShedLevel();
            int money = _farm.GetMoney();
            int moneyNeeded = shedLevel * 10;
            if (money >= moneyNeeded)
            {
                _farm.UpgradeShedLevel();
                Console.WriteLine($"The shed has ben upgraded to {shedLevel + 1} level for {moneyNeeded} coins");
                _farm.SetMoney(money - moneyNeeded);
                Console.WriteLine($"Money left: {money - moneyNeeded} coins");
            }
            else
            {
                Console.WriteLine($"Not enough money to upgrade shed to level {shedLevel + 1}");
                Console.WriteLine($"Current money: {money}\nMoney needed: {moneyNeeded}");
            }
        }
    }
    
    public class WindmillUpgrade : ICommand
    {
        private Farm _farm;
        
        public WindmillUpgrade(Farm farm)
        {
            _farm = farm;
        }

        public void Execute()
        {
            int windmillLevel = _farm.GetWindmillLevel();
            int money = _farm.GetMoney();
            int moneyNeeded = windmillLevel * 10;
            if (money >= moneyNeeded)
            {
                _farm.UpgradeWindmillLevel();
                Console.WriteLine($"The windmill has ben upgraded to {windmillLevel + 1} level for {moneyNeeded} coins");
                _farm.SetMoney(money - moneyNeeded);
                Console.WriteLine($"Money left: {money - moneyNeeded} coins");
            }
            else
            {
                Console.WriteLine($"Not enough money to upgrade windmill to level {windmillLevel + 1}");
                Console.WriteLine($"Current money: {money}\nMoney needed: {moneyNeeded}");
            }
        }
    }

    public class Invoker
    {
        private Queue<ICommand> _commands;

        public Invoker()
        {
            _commands = new Queue<ICommand>();
        }

        public void Add(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            
            _commands.Clear();
        }
    }
    class CommandProgram
    {
        static void Main(string[] args)
        {
            Farm farm = new Farm();
            farm.SetMoney(160);

            ICommand shedUpgrade = new ShedUpgrade(farm);
            ICommand windmillUpgrade = new WindmillUpgrade(farm);

            Invoker invoker = new Invoker();
            
            invoker.Add(shedUpgrade);
            invoker.Add(windmillUpgrade);
            invoker.Add(shedUpgrade);
            invoker.Add(shedUpgrade);
            invoker.Add(windmillUpgrade);
            invoker.Add(windmillUpgrade);
            invoker.Add(windmillUpgrade);
            invoker.Add(shedUpgrade);
            
            invoker.Execute();
        }
    }
}