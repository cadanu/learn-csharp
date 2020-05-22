using System;

namespace arithmetic
{
    class Program
    {
        private static String choice;
        private static String answer;
        private static double realAns;
        private static int on;

        static void Main(string[] args)
        {
            on = 0;
            choice = "yes";

            Console.WriteLine("Hi, this game lets you solve random math problems.");
            // play again loop unlocked by adding 1 to on.
            while (on < 1)
            {
                choice = choice.ToLower();// eliminate capitals
                if (choice.Contains('y') || choice.Contains("yes"))
                {
                    makeGame();// runs the game code

                    Console.Write("Do you want to play again (y/n)? ");// play again?
                    try
                    {
                        choice = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message /*+ e.StackTrace*/);
                    }
                }
                else
                {
                    on++;
                }                
            }
            Console.WriteLine("Thanks for playing.");
        }


        static void makeGame()
        {
            Console.WriteLine("Here is the question: " + makeProblem());

            Console.Write("What is your answer? ");

            try
            {
                answer = Console.ReadLine();

                if (int.Parse(answer) == Convert.ToInt32(realAns))
                {
                    Console.WriteLine("You're right. Good job!");
                }
                else Console.WriteLine("Sorry, that wasn't right.\n"
                                        + "Your answer: " + realAns + "\n"
                                        + "Correct answer: " + realAns);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message /*+ e.StackTrace*/);
            }            
        }


        private static String makeProblem()
        {
            Random rnd = new Random();
            int num1;
            int num2;
            String op;
            String problem;

            num1 = rnd.Next(0, 1000);
            num2 = rnd.Next(0, 1000);

            if (rnd.Next(0, 100) < 49)
            {
                op = " + ";
            }
            else op = " - ";

            if (op.Contains(" + "))
            {
                realAns = Convert.ToDouble(num1) + Convert.ToDouble(num2);
            }
            else realAns = Convert.ToDouble(num1) - Convert.ToDouble(num2);

            problem = num1 + op + num2;
            
            return problem;
        }
    }
}
