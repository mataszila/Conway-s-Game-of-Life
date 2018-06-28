using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    class Display
    {

        public Display()
        {

        }

        public static void printWorldAsGrid(World world)
        {
            Console.Clear();
            displayWorldParameters(world);



            for (int i = 0; i < world.xLength; i++)
            {
                for (int j = 0; j < world.yLength; j++)
                {
                    Console.Write( world.theGrid[i, j] );
                }
                Console.WriteLine();

            }
            Console.WriteLine("\nPress any key to exit the program");

        }
        
        public static void displayWorldParameters(World world)
        {
            Console.WriteLine("This is Conway's Game Of Life" + "\n");
            Console.WriteLine("Size of X axis in this world is: " + world.xLength + "\n");
            Console.WriteLine("Size of Y axis in this world is: " + world.yLength + "\n");
            Console.WriteLine("Size of the grid is: " + world.theGrid.Length + "\n");

        }




    }
}
