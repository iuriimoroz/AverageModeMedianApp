using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AverageValueApp
{
    class Program
    {
        static void Main()
        {
            //Declaration of an Array List where numbers will be stored 
            ArrayList numbersList = new ArrayList();

            //Prompting a user to input numbers for calculation average, mode and median
            string input;
            do
            {
                Console.WriteLine("Print a number and press [Enter] button. If you want to stop - print \"stop\" word:");
                input = Console.ReadLine();
                if (input.All(char.IsDigit))//Checking if user provided a number
                {
                    numbersList.Add(Convert.ToInt32(input));
                }
                else if(input != "stop")//When user provided a symblol - he will be prompted to try again
                {
                    Console.WriteLine("Please provide an integer number, not a symbol. Try again.");
                }

            } while (input != "stop");//At this point the application stops prompting user to input numbers and goes to average, mode and median calculation code


            //This block of code calculates the average, mode and median if user provided at least one number
            if (numbersList.Count > 0)
            {
                //Calculation the average
                int[] array = new int[numbersList.Count];
                array = numbersList.ToArray(typeof(int)) as int[];
                int sum = array.Sum();
                double average = sum / array.Length;
                //Calculation the mode
                Dictionary<int, int> counts = new Dictionary<int, int>();
                foreach (int a in array)
                {
                    if (counts.ContainsKey(a))
                        counts[a] = counts[a] + 1;
                    else
                        counts[a] = 1;
                }

                int mode = int.MinValue;
                int max = int.MinValue;
                foreach (int key in counts.Keys)
                {
                    if (counts[key] > max)
                    {
                        max = counts[key];
                        mode = key;
                    }
                }
                //Calculation the median
                double median = 0;
                if (numbersList.Count % 2 != 0)
                    {
                    Array.Sort(array);
                    median = array[array.Length/2];
                    }
                else
                {
                    Array.Sort(array);
                    median = (array[(array.Length / 2) -1] + array[array.Length / 2]) / 2;
                }
                //Printing the average, mode and median and closing the screen
                Console.WriteLine($"The average value of numbers provided above is {average}.");
                Console.WriteLine($"The mode value of numbers provided above is {mode}.");
                Console.WriteLine($"The median value of numbers provided above is {median}.");
                Console.WriteLine("Press any key to close the screen...");
                Console.ReadKey();
            }
            //This block of code executed if user printed characters instead of numbers and did not provide any number for calculating the average mode and median values. He will be prompted to try again
            else if (input != "stop")
            {
                Console.WriteLine("You did not enter any number. Try again.");
                Main();
            }
            //This block of code executed if user wants to stop without providing any numbers for calculation
            else
            {
                Console.WriteLine("Press any key to close the screen...");
                Console.ReadKey();
            }
        }
    }
}
