using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    class World
    {
        public int xLength, yLength;

        public List<int> xChanges;
        public List<int> yChanges;
        public string[,] theGrid;


        public int XLength
        {
            get
            {
                return xLength;
            }
            set
            {
                xLength = value;
            }
        }

        public int YLength
        {
            get
            {
                return yLength;
            }
            set
            {
                yLength = value;
            }
        }

        public string[,] TheGrid
        {
            get
            {
                return theGrid;
            }
            set
            {
                theGrid = value;
            }
        }

        public List<int> XChanges
        {
            get
            {
                return xChanges;
            }
            set
            {
               xChanges = value;
            }
        }

        public List<int> YChanges
        {
            get
            {
                return yChanges;
            }
            set
            {
                yChanges = value;
            }
        }
        


        public World(int xLength, int yLength)
        {
            this.xLength = xLength;
            this.yLength = yLength;
            this.theGrid = new string[xLength, yLength];
            generateWorldAsGrid();
            populateGrid();
        }


        public void generateWorldAsGrid()
        {
            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    theGrid[i, j] = Input.inputDeadCell;
                }

            }

        }

        // Hardcoded => to be fixed

        public void populateGrid()
        {
            theGrid[2, 0] = Input.inputLiveCell;
            theGrid[3, 1] = Input.inputLiveCell;
            theGrid[1, 2] = Input.inputLiveCell;
            theGrid[2, 2] = Input.inputLiveCell;
            theGrid[3, 2] = Input.inputLiveCell;

        }

        public int checkNeighborsOfOneCell(int xPos, int yPos)
        {
            int neighborCount = 0;

            for(int x = -1 ; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int xCheck = xPos + x;
                    int yCheck = yPos + y;


                    if (x == 0 && y == 0)
                    {

                        continue;
                    }

                    if (xCheck >= 0 && xCheck < xLength && yCheck >= 0 && yCheck < yLength && theGrid[xCheck, yCheck] == Input.inputLiveCell)
                    {
                        neighborCount++;
                        
                    }


                }
            }

            return neighborCount;

        }

        public void runOneStepOfTime()
        {


            Display.displayWorldParameters(this);


            while (true && !Console.KeyAvailable)
            {

                Display.printWorldAsGrid(this);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Input.inputIterationTime));

                xChanges = new List<int>();
                yChanges = new List<int>();


                for (int i = 0; i < xLength; i++)
                {
                    for (int j = 0; j < yLength; j++)
                    {

                        int neighborCount = checkNeighborsOfOneCell(i, j);
                        // Console.WriteLine("x: " + i + " y: " + j + " has " + neighborCount + " neighbors");

                        //Any live cell with fewer than two live neighbours dies, as if caused by under population.

                        if (theGrid[i, j] == Input.inputLiveCell && neighborCount < 2)
                        {
                            //Console.WriteLine("x: " + i + " y: " + j + " has  " + neighborCount + " neighbors and will die");

                            xChanges.Add(i);
                            yChanges.Add(j);

                        }

                        //Any live cell with two or three live neighbours lives on to the next generation.

                        //Any live cell with more than three live neighbours dies, as if by overpopulation.

                        if (theGrid[i, j] == Input.inputLiveCell && neighborCount > 3)
                        {
                            //Console.WriteLine("x: " + i + " y: " + j + " has  " + neighborCount + " neighbors and will die");


                            xChanges.Add(i);
                            yChanges.Add(j);
                        }

                        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

                        if (theGrid[i, j] == Input.inputDeadCell && neighborCount == 3)
                        {
                            //Console.WriteLine("x: " + i + " y: " + j + " has  " + neighborCount + " and will come back to life");


                            xChanges.Add(i);
                            yChanges.Add(j);
                        }

                    }
                }
                makeChangesAfterStepOfTime(xChanges, yChanges);

            }
        }

        public void makeChangesAfterStepOfTime(List<int> xChanges, List<int> yChanges)
        {
            for(int i = 0; i < xChanges.Count; i++)
            {
                int xTemp = xChanges[i];
                int yTemp = yChanges[i];

                if (theGrid[xTemp, yTemp] == Input.inputLiveCell)
                {
                    theGrid[xTemp, yTemp] = Input.inputDeadCell;
                }
                else
                {
                    theGrid[xTemp, yTemp] = Input.inputLiveCell;

                }



            }




        }




    }
}