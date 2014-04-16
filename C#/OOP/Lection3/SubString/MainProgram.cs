using Events;
using MyLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubString
{
    class MainProgram
    {
        static void Main()
        {
            int position = 3, length = 4;

            StringBuilder temp = new StringBuilder();
            temp.Append("one,two,three");

            StringBuilder result = temp.Substring(position, length);
            Console.WriteLine("The Substring from position {0} with length {1} of string {2} is: {3}", position,length, temp.ToString(), result.ToString());

            List<int> tempArray = new List<int> { 21, 6, 54, 2, 4, 67 };
            Console.WriteLine("Sum of Array is: {0}",tempArray.Sum());
            Console.WriteLine("Product of Array is: {0}", tempArray.Product());
            Console.WriteLine("Min of Array is: {0}", tempArray.Min());
            Console.WriteLine("Max of Array is: {0}", tempArray.Max());
            Console.WriteLine("Average of Array is: {0}", tempArray.Average());

            Students[] allStudents = {  new Students("Ivan","Petrov"), 
                                        new Students("Pencho","Ivanov"),
                                        new Students("Bat","Sali"),
                                        new Students("Boncho","Dimitrov"),
                                        new Students("Vankata","Gerov"),
                                        new Students("Ivan","Dimitrov")};

            Console.WriteLine();
            StudentsFilters.FindAlphaNames(allStudents);
 
            Console.WriteLine();
            Students[] allStudentsAge ={new Students("Ivan","Petrov",18), 
                                        new Students("Pencho","Ivanov",34),
                                        new Students("Bat","Sali",23),
                                        new Students("Boncho","Dimitrov",19),
                                        new Students("Vankata","Gerov",56),
                                        new Students("Ivan","Dimitrov",34)};

            StudentsFilters.FindNormalAgeStudents(allStudentsAge, 18, 24);

            Console.WriteLine();
            StudentsFilters.SortByName(allStudents);

            Console.WriteLine();
            StudentsFilters.SortByNameLinq(allStudentsAge);

            Console.WriteLine();
            tempArray.Add(210);
            NumberProcessing intArray = new NumberProcessing(tempArray);
            
            List<int> divResult = intArray.DivisibleBy3and7();
            foreach (var item in divResult)
            {
                Console.WriteLine("Number {0} is divisable by 3 and 7",item);   
            }

            tempArray.Add(100);
            tempArray.Add(42);
            Console.WriteLine();
            NumberProcessing.DivisibleBy3and7Linq(tempArray);

            int execTime = 3000, lastedTime = 10000;

            Event.Timer(allStudents, execTime, lastedTime);

            Console.WriteLine();
            
            Publisher pub = new Publisher();
            Handler eventAllStudents = new Handler("eventAllStudents", pub);
            pub.Start(allStudents, 3, 20);

        }
    }
}
