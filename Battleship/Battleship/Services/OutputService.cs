using System;

namespace Battleship.Services
{
    public class OutputService : IOutputService
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
