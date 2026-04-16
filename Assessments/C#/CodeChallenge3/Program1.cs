using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int sum = 0;
            int score;

            for (int i = 1; i <= no_of_matches; i++)
            {
                Console.Write("Enter score for match " + i + ": ");
                score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine("\n======= Results =======");
            Console.WriteLine("Number of Matches: " + no_of_matches);
            Console.WriteLine("Total Score: " + sum);
            Console.WriteLine("Average Score: " + average);
        }
    }
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========Program1============");
            Console.Write("Enter number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            team.Pointscalculation(matches);

        }
    }
}
