using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class NumSet
    {
        private HashSet<int> Numbers { get; }
        public NumSet(params int[]? numbers)
        {
            if(numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            else
            {
                Array.Sort(numbers);
                Numbers = new HashSet<int>(numbers);
            }
            
        }

        public override string ToString()
        {
            string returnString = "";
            int[] tempArray = Numbers.ToArray();
            returnString = String.Join(" ", tempArray);
            return returnString;
        }

        public override bool Equals(object? numSet)
        {
            return Equals(numSet);
        }

        public bool Equals(NumSet? numSet)
        {
            bool equals = false;
            if (numSet is null)
                equals = false;
            else
            {
                int thisHash = GetHashCode();
                int otherHash = numSet.GetHashCode();

                equals = thisHash == otherHash;
            }
            return equals;
        }



        public override int GetHashCode()
        {
            int sum = 0;
            foreach (int num in Numbers)
            {
                sum = HashCode.Combine(num.GetHashCode(),sum);
            }
            return sum;
        }

        public static bool operator ==(NumSet? setOne, NumSet? setTwo)
        {
            bool result;
            if(setOne is not null)
            {
                result = setOne.Equals(setTwo);
            }
            else if(setTwo is not null)
            {
                result = setTwo.Equals(setOne);
            }
            else
            {
                result = true;
            }
            return result;
        }
        public static bool operator !=(NumSet? setOne, NumSet? setTwo)
        {
            bool result = !(setOne == setTwo);
            return result;
        }
    }
}
