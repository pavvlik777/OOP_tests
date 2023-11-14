using System;

namespace OOP.TwilightSparkle.Foundation.Command
{
    public sealed class DropdownCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Dropdown opened.");
        }
    }
}
