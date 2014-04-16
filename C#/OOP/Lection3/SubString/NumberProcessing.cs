using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinq
{
    public class NumberProcessing
    {
        private List<int> inArray;

        public NumberProcessing(List<int> inputArray)
        {
            this.inArray = inputArray;
        }

        public List<int> InArray { get; set; }


        public List<int> DivisibleBy3and7()
        {
            List<int> result = this.inArray.FindAll(x => ((x % 3) == 0) && (x % 7) == 0);

            return result;
        }

        public static void DivisibleBy3and7Linq(List<int> inputArray)
        {
            var query = from list in inputArray
                        where ((list % 3) == 0) && ((list % 7) == 0)
                        select list;

            foreach (var num in query)
            {
                Console.WriteLine("Number {0} is divisable by 3 and 7", num); 
            }
        }
    }
}
