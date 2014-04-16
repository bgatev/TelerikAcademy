using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BitArrays
{
    public class BitArray64:IEnumerable<int>
    {
        private ulong number;
        private int[] bits;
  
        public BitArray64():this(0)
        {
        }
        
        public BitArray64(ulong num)
        {
            this.number = num;
            this.bits = new int[64];
        }

        public int[] Bits
        {
            get
            {
                return GetBits();
            }
        }

        private int[] GetBits()
        {
            ulong number = this.number;

            int i = 63;
            
            while (number > 0)
            {
                bits[i] = (int)number % 2;
                number = number / 2;
                i--;
            }

            for (; i > -1; i--) bits[i] = 0;
            
            return bits;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));

                return bits[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            bits = GetBits();

            for (int i = 0; i < bits.Length; i++) yield return bits[i];
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BitArray64 tempNum = obj as BitArray64;

            if (this.number == tempNum.number) return true;

            return false;
        }

        public static bool operator ==(BitArray64 firstNum, BitArray64 secondNum)
        {
            if (firstNum.Equals(secondNum)) return true;

            return false;
        }

        public static bool operator !=(BitArray64 firstNum, BitArray64 secondNum)
        {
            if (!firstNum.Equals(secondNum)) return true;

            return false;    
        }
    }
}
