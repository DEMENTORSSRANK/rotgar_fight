

using System;
using System.Linq;
using ModestTree;

namespace Sources.Extensions
{
    public static class IntExtensions
    {
        public static int LeftSegmentIndex(this int[] array, int t)
        {
            if (array.Contains(t))
                return array.IndexOf(t);
            
            int index = Array.BinarySearch(array, t);
            
            if (index < 0)
                index = ~index - 1;
            
            return Math.Min(Math.Max(index, 0), array.Length - 2);
        }
    }
}