using System;

// This class explores the application of in, ref and out when passing variables. 

namespace passing_values
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 8, i = 7;// when passing with in and ref (input parameters), variables should be initialized.
            int j, k;// when passing with out (output parameters), variables need not be initialized.
            
            Console.WriteLine("Practice passing variables: ");
            k = changeInt(a, ref i, out j);

            Console.WriteLine("i = {0}, j = {1} and the sum of them multiplied by {2} = {3}.", i, j, a, k);
            Console.ReadKey();
        }

        private static int changeInt(in int a, ref int i, out int j)
        {// a will not be changed, i may be changed, j must be changed.
            //i = 10;
            j = 12;
            return (i + j) * a;
        }
    }
}
