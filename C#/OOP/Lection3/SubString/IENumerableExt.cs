using System;
using System.Collections.Generic;
using System.Linq;

namespace SubString
{
    public static class IENumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            dynamic result = 0;

            foreach (var item in list)
            {
                result += item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            dynamic result = 1;

            foreach (var item in list)
            {
                result *= item;
            }

            return result;
        }

        public static T Min<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            dynamic min = int.MaxValue;

            foreach (var item in list)
            {
                if (item < min) min = item;       
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            dynamic max = int.MinValue;

            foreach (var item in list)
            {
                if (item > max) max = item;
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            dynamic result = list.Sum();
            int num = list.Count();

            return result / num;
        }
    }
}
