using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            string s123 = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(" aadgfa , basdfa");

            //
            int[] number = new int[] { 1,3 ,2};
            Array.Sort(number);
            foreach (var item in number)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");
            IEnumerable<int> rofNumber = number.Reverse();
            foreach (var item in rofNumber)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");

            {
                Stopwatch sw = Stopwatch.StartNew();
                var v = Fibonacci(4).Take(100).Select(s => s * s).Aggregate((t, a) => t + a);
                sw.Stop();

                Console.WriteLine(v + " -- " + sw.ElapsedMilliseconds);
            }

            {
                Stopwatch sw = Stopwatch.StartNew();
                var v = Fibonacci().Where(i => i % 3 == 0).Take(100).Select(s => s * s).Aggregate((t, a) => t + a);
                sw.Stop();

                Console.WriteLine(v + " -- " + sw.ElapsedMilliseconds);
            }



            List<BigInteger> biSet = new List<BigInteger>();
            int count = 0;
            foreach (var item in Fibonacci())
            {
                if (item % 3 == 0)
                {
                    biSet.Add(item);
                    ++count;
                    if (count == 100)
                    {
                        break;
                    }
                }
            }

            BigInteger biSum = 0;
            foreach (var item in biSet)
            {
                Console.WriteLine(item.ToString());
                biSum += (item * item);
            }

            Console.WriteLine("-------------\r\n " + biSum);

            Console.ReadLine();
        }

        static IEnumerable<BigInteger> Fibonacci()
        {
            BigInteger first = 1;
            BigInteger second = 1;


            {
                yield return first;
                yield return second;
            }


            while (true)
            {

                {
                    BigInteger temp = first;
                    first = second;
                    second = temp + second;
                    yield return second;
                }

            }
        }


        static IEnumerable<BigInteger> Fibonacci(int special)
        {
            BigInteger first = 1;
            BigInteger second = 1;

            if (special <= 2)
            {
                yield return first;
                yield return second;
            }

            int index = 3;
            while (true)
            {
                BigInteger temp = first;
                first = second;
                second = temp + second;

                if (index % special == 0)
                {

                    yield return second;
                }
                ++index;
            }
        }
    }
}
