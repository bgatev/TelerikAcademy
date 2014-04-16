using System;
using System.Linq;

namespace GenericList
{
    public static class GenericListExtensions
    {
        public static T Min<T>(this GenericsList<T> list) where T : IComparable<T>
        {
            T min = list[0];
            for (int index = 1; index < list.Count; index++)
            {
                if (list[index].CompareTo(min) < 0) min = list[index];
            }

            return min;
        }

        public static T Max<T>(this GenericsList<T> list) where T : IComparable<T>
        {
            T max = list[0];
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].CompareTo(max) > 0) max = list[index];
            }
            
            return max;
        }

    }
}
