using System;
using System.Collections.Generic;

namespace Assignment4
{
    public class NumSet
    {
        private int[] Numbers { get; }

        public NumSet(params int[] numbers)
        {
            Numbers = numbers;
            Array.Sort(Numbers);
        }

        public int[] GetValues() => (int[])Numbers.Clone();

        public override string ToString() => string.Join(", ", Numbers);

        public override bool Equals(object? obj)
        {
            if (obj is not NumSet set)
            {
                return false;
            }
            if (Numbers.Length != set.Numbers.Length)
            {
                return false;
            }
            for(int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] != set.Numbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int rv = 0;
            for(int i = 0; i < Numbers.Length; i++)
            {
                rv = HashCode.Combine(rv, Numbers[i]);
            }
            return rv;
        }

        public static bool operator ==(NumSet left, NumSet right)
        {
            return EqualityComparer<NumSet>.Default.Equals(left, right);
        }

        public static bool operator !=(NumSet left, NumSet right)
        {
            return !(left == right);
        }

        public static implicit operator int[]?(NumSet? numSet) => numSet?.Numbers;
    }
}
