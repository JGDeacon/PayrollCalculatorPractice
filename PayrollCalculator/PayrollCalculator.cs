using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCalculator
{
    class PayrollCalculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will figure out how many hours you need to work to meet your gross income goal for the week");
            Console.WriteLine("May I have you name?");
            //We are going to declare a string variable and initialize it with a Console.ReadLine()
            string userName = Console.ReadLine();
            //We are going to declare a few more variables now and we will initialize them later

            //Create an instance of the Calcs class
            Calcs calcs = new Calcs();
            // Get Gross Pay
            decimal grossPay = calcs.GetGross(userName);
            //mitigation... this is a bit heavy handed in its application, but they are stuck in the loop until they provide a usable value
            while (grossPay == 0.00m)
            {
                grossPay = calcs.GetGross(userName);
            }

            // Get Hourly Wage
            decimal hourlyWage = calcs.getWage(userName);
            //we will be nicer on this one and only let them make 10 mistakes
            int counter = 1;
            while (hourlyWage == 0.00m && counter < 10)
            {
                hourlyWage = calcs.getWage(userName);
               counter++;
            }
            //However we need an hourly wage. Without it we divide by 0 and that doesn't work. So lets...
            if (counter == 10)
            {
                Console.WriteLine("We set your hourly wage to $10.00");
                hourlyWage = 10.00m;
            }
            //Do you get time an a half?
            bool isOverTime = calcs.isOverTime();

            //This one does the magic. We take the other values collected and pass them into this method to get the total hours needed to meet the Gross pay goal.
            decimal hoursNeeded = calcs.HowManyHours(hourlyWage, grossPay, isOverTime);
            //Using .ToString with a mask to round the decimal to 2 places

            Console.WriteLine(); 
            Console.WriteLine($"I don't know if its good or bad {userName} but it looks like you will need to work {hoursNeeded.ToString("0.##")} hours a week to meet your goal");
            //There has got to be a better way to space the outputs
            Console.WriteLine();
            Console.WriteLine();
            //C2 in a ToString will format the decimal value as currency like $1,234.56
            Console.WriteLine($"You entered {hourlyWage.ToString("C2")} for your hourly wage, and you answered {isOverTime.ToString()} to the over time question");
            Console.WriteLine(userName + " is those entries are incorrect please run the program again with the correct entries");
            Console.WriteLine("Would you like to run the application again? y/n");
            
            //Just to show it this time we are using to upper and running the whole thing in an if condition. True we restart the program by rerunning the Main method
            if (Console.ReadLine().ToString().ToUpper() == "Y")
            {
                //Clear out the console window
                Console.Clear();
                Main(args); //No idea what args are.... YET!
            }

            //They said no and the program closes.
        
        }
    }
}
