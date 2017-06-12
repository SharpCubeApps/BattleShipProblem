using System;
using Battleship.BattleshipGame.Controllers;
using Battleship.BattleshipGame.Models.Ships;
using Battleship.Services;
using Battleship.Utils;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting point of the program
            //For exceptions, general idea is that if the is some issue with the input and program can not proceed assuming some default values, an exception has been thrown
            //All applications are logged on console at the application level.
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            //Create services that provide input to the system and a way to procuce output from the program
            IInputService inputService = new InputService();
            IOutputService outputService = new OutputService();

            //Inupt parser class to transform user input into usabel form
            IInputParser inputParser = new InputParser();

            //Create factory which will instantiate the ships
            IShipsFactory shipsFactory = new ShipsFactory();

            //Game controller
            BattleShipController battleShipController = new BattleShipController(inputParser, inputService, outputService, shipsFactory);
            battleShipController.InitializeGame();

        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            Console.WriteLine("Exception Message:");
            Console.WriteLine(exception.Message);
            Console.WriteLine("Stack Trace:");
            Console.WriteLine(exception.StackTrace);
        }
    }
}
