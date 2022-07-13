using System;

namespace Sources.Extensions
{
    public static class IntExtensions
    {
        public static int LeftSegmentIndex(this int[] array, int t)
        {
            int k = 0;

            for (int i = 0; i < array.Length; i++)
                if (Math.Abs(array[i] - t) < Math.Abs(array[k] - t))
                    k = i;

            return k;
        }
    }
}