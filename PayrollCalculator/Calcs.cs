using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCalculator
{
    class Calcs
    {
        

        public decimal GetGross(string userName)
        {
            decimal grossPay = 0.00m; // variable scoped to method
            Console.WriteLine($"How much would you like to gross per week {userName}?");
            // By typing "Try" then hitting Tab Tab you get the try block below. This will allow code to run, but if it crashes the program can recover.
            // We are doing this for the gross income question to prevent a crash if the user put in non numeric charecters. Try/Catches can do a number of things.
            try
            {

                //We are trying to parse (convert) a string to numbers
                grossPay = Decimal.Parse(Console.ReadLine());
                return grossPay; 
            }
            catch (Exception)
            {
                //this is the code that runs if the user enters something that can't be parse (converted) into a number
                Console.WriteLine("I'm sorry we couldn't accept that. Please only user numbers and a decimal. For example 2564.25.");

                return grossPay;
            }
        }

        public decimal getWage(string userName)
        {
            decimal wage = 0.00m; // variable scoped to method
            Console.WriteLine($"{userName} how much do you make an hour?");
            try
            {
                wage = Decimal.Parse(Console.ReadLine());
                return wage;
            }
            catch (Exception)
            {
                //this is the code that runs if the user enters something that can't be parse (converted) into a number
                Console.WriteLine("I'm sorry we couldn't accept that. Please only user numbers and a decimal. For example 15.75");
                return wage;
            }
        }

        public bool isOverTime()
        {
            Console.WriteLine("Do you get time and a half for overtime hours? (y/n)");
            //Doing a few things here. Setting the value of overTime 
            string overTime = Console.ReadLine();

            //Because Ternaries are fun... lets use one and setting the value of overTime to lowercase
            bool answer = (overTime.ToLower() == "y") ? true : false;
            return answer;

            //notice their isn't a try block around this code. You can input anything into a string so there isn't going to be a parse error.
            //to idiot proof this you would want to validate the value of overTime to make sure the user entered a y or n
            //Users are very creative when it comes to finding the "non-happy path" of an application.
        }

        public decimal HowManyHours(decimal wage, decimal goal, bool overTime)
        {
            //Declare and initialize the hours total remember to add the m to decimals when YOU set the value directly
            decimal totalHours = 0.00m;
            //math time!
            if ((goal/wage) < 40) //Do we need OT to meet our goal?
            {
                totalHours = goal / wage;
                return totalHours;
            }
            else
            {
                if (overTime)
                {
                    totalHours = (goal - (wage * 40)) / (wage * 1.5m)+40;
                    //totalHours can be messy so lets round at the 2nd decimal place, but we are going to do that while presenting back to the user
                    return totalHours;
                }
                else
                {
                    totalHours = goal / wage;
                    return totalHours;
                }
            }
        }


    }
}
