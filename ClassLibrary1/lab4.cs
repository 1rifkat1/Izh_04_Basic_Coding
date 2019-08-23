using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class lab4
    {
        const int INTLENGTH = 32;
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
        #region task1
        public int InsertNumber(int num1, int num2, int i, int j)
        {
            var bytes1 = ToBytesArray(num1);
            var bytes2 = ToBytesArray(num2);
            for (int x = i; x <= j; x++)
            {
                bytes1[x] = bytes2[x - i];
            }

            return ToInt(bytes1);
        }
        private int[] ToBytesArray(int num)
        {
            int[] array = new int[INTLENGTH];
            if (num < 0)
                array[array.Length - 1] = 1;
            if (num == 0)
                return array;
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = num % 2;
                if (num <= 3)
                {
                    array[i + 1] = 1;
                    break;
                }
                num /= 2;
            }
            return array;
        }
        private int ToInt(int[] bytes)
        {
            if (bytes.Length != INTLENGTH)
                throw new ArgumentException();
            int result = 0;
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                result += bytes[i] * (int)Math.Pow(2, i);
            }
            if (bytes[bytes.Length - 1] == 1)
                result *= -1;
            return result;
        }
        #endregion
        public int FindNextBiggerNumber(int num,out double time)
        {
            int result;
            var watcher = new Stopwatch();
            watcher.Start();

            var arr = num.ToString().Select(x => (int)(x - '0')).ToArray();
            int[] arrDigits = new int[10];
            foreach (var c in arr)
                arrDigits[c]++;
            for (int i = num + 1; ; i++)
            {
                var norm = true;

                var current = i.ToString().Select(x => (int)(x - '0')).ToArray();
                if (current.Length != arr.Length)
                {
                    result = -1;
                    break;
                }

                int[] digits = new int[10];
                foreach (var c in current)
                    digits[c]++;

                for (int j = 0; j < 10; j++)
                {
                    if (arrDigits[j] != digits[j])
                    {
                        norm = false;
                        break;
                    }
                }
                if (norm)
                {
                    result = i;
                    break;
                }
            }
            watcher.Stop();
            time = watcher.ElapsedMilliseconds;
            return result;
        }
    }
}
