using System;
using System.Collections.Generic;

namespace Singleton
{
    public sealed class ShoppingCart {
        
        private static ShoppingCart _instance = null;
        private List<string> _items;
        
        private ShoppingCart()
        {
            _items = new List<string>();
        }  
        public static ShoppingCart Instance {  
            get {  
                if (_instance == null) {  
                    _instance = new ShoppingCart();  
                }  
                return _instance;  
            }  
        }

        public void AddItem(string itemName)
        {
            _items.Add(itemName);
        }

        public void RemoveItem(string itemName)
        {
            _items.Remove(itemName);
        }

        public void PrintItems()
        {
            Console.WriteLine("Items:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
class SingletonProgram
    {
        static void Main(string[] args)
        {
            ShoppingCart cart1 = ShoppingCart.Instance;
            ShoppingCart cart2 = ShoppingCart.Instance;
            
            Console.WriteLine(cart1 == cart2);
            
            cart1.AddItem("CPU");
            cart2.AddItem("Graphic Card");
            cart1.AddItem("DYSK TYSIONC");
            
            cart1.PrintItems();
        }
    }
}