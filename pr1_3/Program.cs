using System;
using System.Collections.Generic;

namespace PracticeTask
{
    interface ICustomer
    {
        void Update(string promotion);
    }

    class PromotionManager
    {
        private List<ICustomer> customers = new List<ICustomer>();

        public void Subscribe(ICustomer customer)
        {
            customers.Add(customer);
        }

        public void Unsubscribe(ICustomer customer)
        {
            customers.Remove(customer);
        }

        public void AddPromotion(string promotion)
        {
            Console.WriteLine("\n🔥 Новая акция: " + promotion);
            Notify(promotion);
        }

        private void Notify(string promotion)
        {
            foreach (var customer in customers)
            {
                customer.Update(promotion);
            }
        }
    }

    class LoyalCustomer : ICustomer
    {
        public string Name { get; set; }

        public LoyalCustomer(string name)
        {
            Name = name;
        }

        public void Update(string promotion)
        {
            Console.WriteLine($"⭐ ЛОЯЛЬНЫЙ клиент {Name}: {promotion}");
        }
    }

    class RegularCustomer : ICustomer
    {
        public string Name { get; set; }

        public RegularCustomer(string name)
        {
            Name = name;
        }

        public void Update(string promotion)
        {
            Console.WriteLine($"👤 клиент {Name}: {promotion}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PromotionManager manager = new PromotionManager();

            Console.Write("Сколько клиентов добавить? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nКлиент {i + 1}");

                Console.Write("Имя: ");
                string name = Console.ReadLine();

                Console.Write("Тип (1 - лояльный, 2 - обычный): ");
                int type = int.Parse(Console.ReadLine());

                ICustomer customer;

                if (type == 1)
                    customer = new LoyalCustomer(name);
                else
                    customer = new RegularCustomer(name);

                manager.Subscribe(customer);
            }

            Console.WriteLine("\n--- Добавление акций ---");

            while (true)
            {
                Console.Write("\nВведите акцию (или exit): ");
                string promo = Console.ReadLine();

                if (promo.ToLower() == "exit")
                    break;

                manager.AddPromotion(promo);
            }
        }
    }
}