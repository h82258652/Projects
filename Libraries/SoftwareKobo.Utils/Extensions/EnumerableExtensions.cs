using System;
using System.Collections.Generic;
using System.Numerics;

namespace SoftwareKobo.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<long> Range(long start, long count)
        {
            var max = (BigInteger)start + count - 1;
            if (count < 0 || max > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (var i = start; i < start + count; i++)
            {
                yield return i;
            }
        }
    }
}