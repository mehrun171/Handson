using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_3
{
/*    1. Write a program to find the Sum and the Average points scored by the teams in the IPL.
 *    Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) 
 *    that takes no.of matches as input and accepts that many scores from the user.The function should then
 *    return the Count of Matches, Average and Sum of the scores.
*/

    class CricketTeam
    {
        public (int noofmatches, int sum, double average) PointsCalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;
            double average;
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score for match {i+1} : ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }
            average = (double)sum / (double)no_of_matches;

            return (no_of_matches, sum, average);
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.Write("Enter the number of matches played: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            var res = team.PointsCalculation(matches);


            Console.WriteLine($"Count of matches: {res.noofmatches}");
            Console.WriteLine($"Sum of Scores: {res.sum}");
            Console.WriteLine($"Average of Score: {res.average}");
            Console.ReadLine();
        }
    }
}
