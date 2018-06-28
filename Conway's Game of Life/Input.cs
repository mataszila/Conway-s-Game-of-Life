using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    class Input
    {
        public static int inputXLength; public int MyProperty { get; set; }
        public static int inputYLength; public int MyProperty2 { get; set; }
        public static string inputLiveCell; public int MyProperty3 { get; set; }
        public static string inputDeadCell; public int MyProperty4 { get; set; }
        public static int inputIterationTime; public int MyProperty5 { get; set; }

        public static int askForANumber() {

            string x = Console.ReadLine();

            int ans = Int32.Parse(x);

            return ans;

           
        }

        public void askForWorldSize()
        {
            Console.WriteLine("Welcome to Conway's Game Of Life: ");
            Console.WriteLine("Please choose the size for your grid: ");
            Console.WriteLine("Please enter size of x axis: ");
            inputXLength = askForANumber();
            Console.WriteLine("Please enter size of y axis: ");
            inputYLength = askForANumber();


        }

        public void askForNotation()
        {
            Console.WriteLine("Please enter what character you want to use for a live cell: ");
            inputLiveCell = "[" + Console.ReadLine() + "]"; 
            Console.WriteLine("Please enter what character you want to use for a dead cell (preferably the same number of characters): ");
            inputDeadCell = "[" + Console.ReadLine() +"]";
            Console.WriteLine("Please enter time between every iteration (in milliseconds): ");
            inputIterationTime = askForANumber();
        }

        public void askForInput()
        {
            askForWorldSize();
            askForNotation();
        }






    }
}
