using UnityEngine;

namespace Sources.Extensions
{
    public static class FloatExtensions
    {
        public static int ToMilliseconds(this float value) => Mathf.RoundToInt(value * 1000);
    }
}