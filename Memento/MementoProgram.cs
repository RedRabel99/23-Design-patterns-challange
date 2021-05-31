using System;
using System.Collections.Generic;

namespace Memento
{
    class MementoProgram
    {
        public class Memento
        {
            private int _playerLevel;
            private List<string> _items;

            public Memento(int playerLevel, List<string> items)
            {
                _playerLevel = playerLevel;
                _items = items;
            }

            public int GetPlayerLevel()
            {
                return _playerLevel;
            }

            public List<string> GetItems()
            {
                List<string> newItems = new List<string>();
                foreach (var item in _items)
                {
                    newItems.Add(item);
                }

                return newItems;
            }
        }
        
        public class Game
        {
            private int _playerLevel;
            private List<string> _items;
            private List<Memento> _saves;

            public Game()
            {
                _playerLevel = 0;
                _items = new List<string>();
                _saves = new List<Memento>();
            }

            public void Save()
            {
                Console.WriteLine("Saving..");
                List<string> newItems = new List<string>();
                foreach (var item in _items)
                {
                    newItems.Add(item);
                }
                _saves.Add(new Memento(_playerLevel, newItems));
            }

            public void Load(int index)
            {
                if (index >= _saves.Count)
                {
                    Console.WriteLine("There is no save of that index");
                    return;
                }
                
                Memento memento = _saves[index];
                _playerLevel = memento.GetPlayerLevel();
                _items = memento.GetItems();
                Console.WriteLine($"Save of id {index} has been loaded");
            }

            public void AddItem(string item)
            {
                _items.Add(item);
            }

            public void LevelUp()
            {
                _playerLevel += 1;
            }

            public int GetPlayerLevel()
            {
                return _playerLevel;
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                foreach (var item in _items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
        
        static void Main(string[] args)
        {
            Game game = new Game();
            game.LevelUp();
            game.AddItem("Bow");
            game.AddItem("Hood");
            game.Save();
            
            game.LevelUp();
            game.LevelUp();
            game.AddItem("Ancient Scroll");
            game.Save();
            
            Console.WriteLine($"Player level: {game.GetPlayerLevel()}");
            game.ShowItems();
            
            game.Load(0);
            
            Console.WriteLine($"Player level: {game.GetPlayerLevel()}");
            game.ShowItems();
            
            game.Load(1);
            
            Console.WriteLine($"Player level: {game.GetPlayerLevel()}");
            game.ShowItems();
        }
    }
}