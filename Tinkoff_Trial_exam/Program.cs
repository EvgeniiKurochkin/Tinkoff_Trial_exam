using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Tinkoff_Trial_exam
{
    internal class Program
    {
        static long[] Swith(long[] numbers)
        {
            long[] mas = numbers;
            long max = numbers[numbers.Length - 1].ToString().Length;
            long maxA = numbers[numbers.Length - 1].ToString().Length;
            long min = numbers[numbers.Length - 1];
            int itr = 0;
            int s = 0;
            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                if (numbers[i].ToString().Length == max && numbers[i] <= numbers[numbers.Length - 1] && numbers[i].ToString()[0] < '9')
                {
                    itr++;
                    min = numbers[i];
                    s = i;
                }
                if (numbers[i].ToString().Length < max && itr == 0)
                {
                    max = numbers[i].ToString().Length;
                    for (int j = numbers.Length - 1; j >= 0; j--)
                    {
                        var num = numbers[j]; 
                        if (numbers[j].ToString().Length > max)
                        {
                             num = numbers[j] % Convert.ToInt64(Math.Pow(10, max));
                        }
                        if (num.ToString().Length == max && num <= min && num.ToString()[0] < '9' )
                        {
                            itr++;
                            min = num;
                            s = j;
                        }
                    }
                    break;
                }
                
            }
            if (numbers[s].ToString()[(int)maxA - (int)max] < '9')
            {
                StringBuilder sb = new StringBuilder(numbers[s].ToString());
                sb[(int)maxA - (int)max] = '9';
                var b = sb.ToString();
                min = Convert.ToInt32(b);
                mas[s] = min;
                return mas;
            }
            return mas;
        }
        static void Main()
        {
            long[] numbersA = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt64);
            string[] ss = Console.ReadLine().Split(' ');
            long[] numbersB = Array.ConvertAll(ss, Convert.ToInt64);
            long j = 0;
            long g = 0;
            var a = Array.ConvertAll(ss, Convert.ToInt64); 

            for (int i = 0; i < numbersA[1]; i++)
            {
                 Array.Sort(a/*, (x, y) => y.CompareTo(x)*/);
                 a = Swith(a);
            }
            for (int i = 0; i < numbersB.Length; i++)
            {
                j += a[i];
                g += numbersB[i];
                Console.Write(a[i]+" ");
                Console.WriteLine(numbersB[i]);
            }
            Console.WriteLine(j - g);


        }


    }

}

