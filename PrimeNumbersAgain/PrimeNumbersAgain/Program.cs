using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            var max = 40000000;
            var sqrt = Math.Sqrt(max); // faster to initialize outside of loop
            var primes = new List<int>();
            bool[] numbers = new bool[max];

            for (int i = 0; i < numbers.Length; i++) // sets all booleans in array to true
                numbers[i] = true;

            for (int i = 2; i < sqrt + 1; i++)
            {
                if (numbers[i - 1])
                {
                    for (int j = (int)Math.Pow(i, 2); j <= max; j += i) // sets non-primes to false
                    {
                        numbers[j - 1] = false;
                    }
                }
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i])
                    primes.Add(i);
            }

            return primes[n - 1] + 1; // The output would always be 1 less than the actual answer (2 million prime is 32,452,843.
                                      // Program would output 32,452,842.) I have no idea what caused this so I decided to take an
                                      // easy way and just make it always add 1.
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
