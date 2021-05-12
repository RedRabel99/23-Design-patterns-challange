using System;

namespace Facade
{
    class Order
    {
        private string _mealName;
        private double _price;

        public Order(string mealName, double price)
        {
            _mealName = mealName;
            _price = price;
            Console.WriteLine($"Order created:\nMeal Name = {mealName}\nPrice: {price}" );
        }

        public string GetMealName()
        {
            return _mealName;
        }

        public double GetPrice()
        {
            return _price;
        }
    }

    class Meal
    {
        private string _name;

        public Meal(string name)
        {
            _name = name;
            Console.WriteLine($"Meal: {name} is made");
        }

        public string GetName()
        {
            return _name;
        }
    }

    class WaiterSystem
    {
        private string _name;

        public WaiterSystem(string name)
        {
            _name = name;
        }

        public Order CreateOrder(string mealName, double price)
        {
            Console.WriteLine("Creating order...");
            return new Order(mealName, price);
        }

        public void ServeOrder(Meal meal)
        {
            Console.WriteLine($"Serving meal: {meal.GetName()}");
        }

        public string GetName()
        {
            return _name;
        }
    }

    class CookSystem
    {
        private string _name;

        public CookSystem(string name)
        {
            _name = name;
        }

        public Meal MakeMeal(Order order)
        {
            Console.WriteLine($"Making a meal...");
            return new Meal(order.GetMealName());
        }
    }

    class RestaurantFacade
    {
        private WaiterSystem _waiterSystem;
        private CookSystem _cookSystem;

        public RestaurantFacade(string waiterName, string cookName)
        {
            _waiterSystem = new WaiterSystem(waiterName);
            _cookSystem = new CookSystem(cookName);
        }

        public void ServiceCustomer()
        {
            string mealName;
            Console.WriteLine("Enter the meal you want to get: ");
            mealName = Console.ReadLine();
            Order order = _waiterSystem.CreateOrder(mealName, 22.99);
            Meal meal = _cookSystem.MakeMeal(order);
            _waiterSystem.ServeOrder(meal);
        }
    }
    class FacadeProgram
    {
        static void Main(string[] args)
        {
            RestaurantFacade restaurant = new RestaurantFacade("Arthur", "Vincent");
            
            restaurant.ServiceCustomer();
        }
    }
}