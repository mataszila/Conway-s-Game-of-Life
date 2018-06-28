using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args) {

            Program newGame = new Program();


               newGame.startTheProgram();
        }



        public void startTheProgram()
        {
            Input userInput = new Input();
            userInput.askForInput();
            World earth = new World(Input.inputXLength,Input.inputYLength);

            //earth.generateWorldAsGrid();
            //earth.populateGrid();

            earth.runOneStepOfTime();


            Console.ReadLine();

        }



    }
}
    

