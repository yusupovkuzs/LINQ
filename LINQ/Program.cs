using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Data64
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int DurationHours { get; set; }
        public int ClientCode { get; set; }
    }
    class Program
    {
        public static string LinqBegin4(char symbolC, string[] sequenceA)
        {
            try
            {
                var result = sequenceA.Length == 1 && sequenceA[0].EndsWith(symbolC)
                    ? sequenceA[0]
                    : sequenceA.Length > 1
                        ? "Error"
                        : "";

                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static List<int> LinqBegin16(int[] integerSequence)
        {
            List<int> positiveNumbers = integerSequence
                .Where(num => num > 0)
                .ToList();

            return positiveNumbers;
        }

        public static List<string> LinqBegin28(int L, string[] sequenceA)
        {
            var result = sequenceA
                .TakeWhile(s => s.Length <= L || !char.IsLetter(s.Last()))
                .Where(s => char.IsLetter(s.Last()))
                .OrderByDescending(s => s.Length)
                .ThenBy(s => s)
                .ToList();

            return result;
        }

        public static List<string> LinqBegin37(IEnumerable<string> sequenceA)
        {
            var result = sequenceA
                .Select((str, index) => string.IsNullOrWhiteSpace(str) ? str : str + (index + 1))
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .OrderBy(str => str)
                .ToList();

            return result;
        }

        public static IEnumerable<char> LinqBegin40(int K, IEnumerable<string> sequenceA)
        {
            var result = sequenceA
                .Where(str => str.Length >= K)
                .SelectMany(str => str)
                .Reverse()
                .ToList();

            return result;
        }

        public static IEnumerable<string> LinqBegin52(IEnumerable<string> sequenceA, IEnumerable<string> sequenceB)
        {
            var result = sequenceA
                .Where(ea => char.IsDigit(ea.Last()))
                .SelectMany(ea => sequenceB.Where(eb => char.IsDigit(eb.Last())), (ea, eb) => $"{ea}={eb}")
                .OrderBy(e => e, StringComparer.Ordinal)
                .ThenByDescending(e => e, StringComparer.Ordinal)
                .ToList();

            return result;
        }
        public static void Main(string[] args)
        {
            // LinqBegin4
            char symbol = 'C';
            string[] seq4 = { "ABC", "DEF", "GHC" };
            string result4 = LinqBegin4(symbol, seq4);
            Console.WriteLine("LinqBegin4: " + result4);

            // LinqBegin16
            int[] numbers = { -3, 5, 0, 8, -2, 10 };
            List<int> positiveNumbers = LinqBegin16(numbers);
            Console.Write("LinqBegin16: ");
            foreach (int num in positiveNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // LinqBegin28
            int L = 3;
            string[] seq28 = { "A", "BCD", "XYZ", "W", "LMN", "PQR", "12K", "FFFFF" };
            List<string> sortedStrings = LinqBegin28(L, seq28);
            Console.Write("LinqBegin28: ");
            foreach (string str in sortedStrings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();

            // LinqBegin37
            string[] seq37 = { "ABC", "", "DEF", "GHI", "", "JKL" };
            List<string> transformedAndSortedStrings = LinqBegin37(seq37);
            Console.Write("LinqBegin37: ");
            foreach (string str in transformedAndSortedStrings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();

            // LinqBegin40
            int K = 3;
            string[] seq40 = { "ABC", "DEFG", "H", "IJKL", "MNO" };
            IEnumerable<char> reversedCharacters = LinqBegin40(K, seq40);
            Console.Write("LinqBegin40: ");
            foreach (char ch in reversedCharacters)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();

            // LinqBegin52
            string[] seq52A = { "AF3", "G7H", "IJKL8" };
            string[] seq52B = { "D78", "M5N", "OPQ6" };
            IEnumerable<string> combinations = LinqBegin52(seq52A, seq52B);
            Console.Write("LinqBegin52: ");
            foreach (string combination in combinations)
            {
                Console.Write(combination + " ");
            }
            Console.WriteLine();

            // LinqBegin64
            List<Data64> fitnessData = new List<Data64>
            {
                new Data64 { Year = 2023, Month = 1, DurationHours = 2, ClientCode = 101 },
                new Data64 { Year = 2023, Month = 2, DurationHours = 1, ClientCode = 101 },
                new Data64 { Year = 2024, Month = 1, DurationHours = 3, ClientCode = 101 },
                new Data64 { Year = 2023, Month = 1, DurationHours = 2, ClientCode = 102 },
                new Data64 { Year = 2023, Month = 2, DurationHours = 2, ClientCode = 102 }
            };
            var totalDurationByClient = fitnessData
                .GroupBy(data => data.ClientCode)
                .Select(group => new
                {
                    ClientCode = group.Key,
                    TotalDuration = group.Sum(data => data.DurationHours)
                })
                .OrderByDescending(result => result.TotalDuration)
                .ThenBy(result => result.ClientCode);

            Console.WriteLine("LinqBegin64: ");
            foreach (var res in totalDurationByClient)
            {
                Console.WriteLine($"{res.TotalDuration} hours, Client Code: {res.ClientCode}");
            }
        }
    }
}
