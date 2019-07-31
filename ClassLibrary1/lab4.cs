using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class lab4
    {
        public int FindElementIndexBetweenEqualSums(double[] arr)
        {
            decimal sum = (decimal)arr.Sum();
            var sumL = 0.0M;
            for (int i = 0; i < arr.Length; i++)
            {
                if (sumL == sum - sumL - (decimal)arr[i])
                    return i;
                sumL += (decimal)arr[i];
            }
            return -1;
        }
        public string FindStringConcatenation(string firstStr, string secondStr)
        {
            string delRepeat = string.Join(string.Empty, secondStr.Where(x => !firstStr.Contains(x)));
            return firstStr + delRepeat;
        }
    }
}
