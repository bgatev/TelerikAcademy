namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var allProducts = new[]
                {
                    new Product("beer", 3, 2), //name, weight, cost
                    new Product("vodka", 8, 12),
                    new Product("cheese", 4, 5),
                    new Product("nuts", 1, 4),
                    new Product("ham", 2, 3),
                    new Product("whiskey", 8, 13),
                };

            int capacity = 10;

            var orderedProducts = allProducts.OrderByDescending(c => c.Cost).ThenByDescending(w => w.Weight);

            int count = 1;
            int currentCapacity = 0;
            int currentCost = 0;
            int maxCost = 0;

            for (int i = capacity; i > -1; i--)
            {
                foreach (var product in orderedProducts)
                {
                    var restOrderedProducts = orderedProducts.Skip(count);

                    currentCapacity += product.Weight;
                    currentCost += product.Cost;

                    foreach (var restProduct in restOrderedProducts)
                    {
                        currentCapacity += restProduct.Weight;
                        currentCost += restProduct.Cost;

                        if (currentCapacity > capacity)
                        {
                            currentCapacity -= restProduct.Weight;
                            currentCost -= restProduct.Cost;
                        }
                        else
                        {
                            if (maxCost < currentCost) maxCost = currentCost;
                        }
                    }

                    currentCapacity = 0;
                    currentCost = 0;
                    count++;
                }
            }

            Console.WriteLine(maxCost);
        }
    }
}
