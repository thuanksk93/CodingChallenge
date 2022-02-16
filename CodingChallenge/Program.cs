using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodingChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            Input();
            Console.ReadKey();
        }
        static void Input()
        {
            int dice, sides;
            try
            {
                Console.WriteLine(" Input dice :");
                dice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" Input sides: ");
                sides = Convert.ToInt32(Console.ReadLine());
                if (dice != 0 && sides != 0)
                {
                    var timing = new Stopwatch();
                    timing.Start();
                    var Rounds = Random(dice, sides);
                    foreach (var itemRound in Rounds)
                    {
                        PrintMax(itemRound);
                    }
                    Console.WriteLine("Time elapsed success : {0} ", timing.Elapsed.TotalSeconds);
                }
                else
                {
                    Console.WriteLine("Error! cannot be 0 !");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input must not contain text!");
            }
        }

        /// <summary>
        /// Random calculate the score of 1000 rounds, 
        /// each with ‘I’ dice with ‘J’ sides,
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="sides"></param>
        /// <returns></returns>
        static List<List<int>> Random(int dice, int sides)
        {
            const int RoundRandom = 1000;
            Random random = new Random();
            var listRound = new List<List<int>>();
            for (int i = 0; i < RoundRandom; i++)
            {
                var roundDice = new List<int>();
                for (int j = 0; j < dice; j++)
                {
                    roundDice.Add(random.Next(1, sides));
                }
                listRound.Add(roundDice);
            }

            return listRound;
        }
       
        /// <summary>
        /// Find the largest and most frequent occurrence in a list
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        private static int FindMax(List<int> round)
        {
            round.Sort();
            int totalMax = 0;
            int currentTotalScore = 0;
            int currentScore = 0;

            foreach (var item in round)
            {
                if (item != currentScore)
                {
                    currentTotalScore = item;
                    currentScore = item;

                    if (currentTotalScore > totalMax)
                    {
                        totalMax = currentTotalScore;
                    }
                }
                else if (item == currentScore)
                {
                    currentTotalScore += item;
                    if (currentTotalScore > totalMax)
                    {
                        totalMax = currentTotalScore;
                    }
                }
            }

            return totalMax;

        }
       
        /// <summary>
        /// Compare the elements in the array one by one
        /// </summary>
        /// <param name="round2"></param>
        /// <returns></returns>
        private static int FindMax2(List<int> round2)
        {
            int totalMax = 0;
            int currentScoreTotal = 0;
            for (int i = 0; i < round2.Count; i++)
            {
                currentScoreTotal = round2[i];
                for (int j = i + 1; j < round2.Count; j++)
                {
                    if (round2[i] == round2[j])
                    {
                        currentScoreTotal += round2[i];
                    }
                }
                if (currentScoreTotal > totalMax)
                {
                    totalMax = currentScoreTotal;
                }
            }
            return totalMax;
        }

        private static void PrintMax(List<int> round)
        {
            Console.Write($"[{string.Join(", ", round)}]");

            var score = FindMax(round);
            Console.WriteLine($" => {score}");
        }
    }
}
