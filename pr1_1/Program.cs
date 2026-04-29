using System;
using System.Collections.Generic;

namespace PracticeTask
{
    class DiscountManager
    {
        private static DiscountManager instance;

        private Dictionary<string, double> discounts;

        private DiscountManager()
        {
            discounts = new Dictionary<string, double>();
        }

        public static DiscountManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiscountManager();

                return instance;
            }
        }

        public void SetDiscount(string product, double percent)
        {
            if (discounts.ContainsKey(product))
                discounts[product] = percent;
            else
                discounts.Add(product, percent);

            Console.WriteLine($"Скидка для {product} = {percent}%");
        }

        public double GetDiscount(string product)
        {
            if (discounts.ContainsKey(product))
                return discounts[product];

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DiscountManager dm = DiscountManager.Instance;

            dm.SetDiscount("Laptop", 10);
            dm.SetDiscount("Phone", 15);

            Console.WriteLine("\nСкидка на Laptop: " + dm.GetDiscount("Laptop") + "%");
            Console.WriteLine("Скидка на Phone: " + dm.GetDiscount("Phone") + "%");

            DiscountManager dm2 = DiscountManager.Instance;

            dm2.SetDiscount("Tablet", 5);

            Console.WriteLine("\nСкидка на Tablet через dm: " + dm.GetDiscount("Tablet") + "%");
        }
    }
}