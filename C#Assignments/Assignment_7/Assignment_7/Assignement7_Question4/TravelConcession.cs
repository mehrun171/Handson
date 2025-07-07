using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7.Assignement7_Question4
{
    public class TravelConcession
    {
        public string CalculateConcession(int age, double TotalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concessionFare = TotalFare * 0.7; 
                return $"Senior Citizen - Fare: {concessionFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare}";
            }
        }
    }
}