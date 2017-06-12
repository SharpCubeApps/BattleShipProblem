using System;

namespace Battleship.Services
{
    public class InputService : IInputService
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
