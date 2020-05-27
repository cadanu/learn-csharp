using System;

namespace total_after_discount
{
    class Program
    {        
        static void Main(string[] args)
        {
            //int unlock = 0;
            string customer;
            double subtotal;

            Console.WriteLine(
                "This program calculates the total amount of a product "
                + "\nbased on the type of customer and subtotal amount. "
                + "\n");
            
            // prompt the user for the customer designation
            Console.Write("Enter customer type (R/C): ");
            do
            {// lets keep prompting the user for the right input
                try
                {
                    customer = Console.ReadLine();
                    customer = customer.ToLower();
                    if (customer.Equals("r") || customer.Equals("c"))
                    {
                        break;
                    }
                    else throw new Exception();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong, please type 'R' or 'C'.");
                }
            } while (true);

            // prompt the user for the subtotal
            Console.Write("Enter subtotal: ");
            do
            {// and lets make sure there are no errors in the subtotal (i.e. nan)
                try
                {
                    subtotal = double.Parse(Console.ReadLine());
                    break;
                } 
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong, please make sure you enter a number.");
                }
            } while (true);

            doCalc(customer, subtotal);
        }

        static void doCalc(string customer, double subtotal)
        {
            double percent;
            double tax;

            // lets determine the percentage
            if (customer.Equals("r"))
            {
                if (subtotal > 249)
                {
                    percent = 0.25;
                }
                else if (subtotal > 99 && subtotal < 250)
                {
                    percent = 0.1;
                }
                else percent = 0.0;                               
            }
            else
            {
                if (subtotal > 249)
                {
                    percent = 0.3;
                }
                else percent = 0.2;
            }
            tax = (subtotal - (subtotal * percent)) * 0.13;

            Console.WriteLine("\nDiscount percent : " + percent.ToString("p1"));
            Console.WriteLine("Subtotal         : " + subtotal.ToString("c2"));
            Console.WriteLine("Discounted amount: " + (subtotal * percent).ToString("c2"));
            Console.WriteLine("Total (+ 13% HST): " + ((subtotal - (subtotal * percent)) + tax).ToString("c2"));
        }
    }
}
