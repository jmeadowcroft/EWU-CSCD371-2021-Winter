using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment4
{
    public class NumSet
    {
        private HashSet<int>? set;

        public HashSet<int> Set{
            get
            {
                return set!;
            }
            private set => set = value??throw new ArgumentNullException();

        }

        public NumSet(params int[] arr)
        {
            if(arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            this.set = new HashSet<int>(arr);
        }

        //public equals
        public override bool Equals(Object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not NumSet numSet)
            {
                return false;
            }
            
            return numSet.Set.IsSubsetOf(this.Set) && this.Set.IsSubsetOf(numSet.Set);
        }

        public override int GetHashCode()
        {

            int res = 0;
            int[] setArr = this.ToArray();

            for(int i = 0; i < setArr.Length; i++)
            {
               res += setArr[i];
            }

            return res+=setArr.Length;
        }

        public static bool operator ==(NumSet first, NumSet second)
        {
            if (first is null && second is null) return true;
            if (first is null ^ second is null) return false;
            return first!.Equals(second);
        }

        public static bool operator !=(NumSet first, NumSet second)
            => !(first == second);


        public int[] ToArray()
        {   
            return Set.ToArray();
        }

        public override string ToString()
        {
            var hsArr = Set.ToArray();
            var res = "{";
            for(int i = 0; i < hsArr.Length; i++)
            {
                res += hsArr[i];
                
                if(i != hsArr.Length-1)
                    res += ", ";
            }
            res += "}";

            return res;
        }
    }
}