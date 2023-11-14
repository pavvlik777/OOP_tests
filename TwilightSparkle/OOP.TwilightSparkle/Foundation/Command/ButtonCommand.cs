using System;

namespace OOP.TwilightSparkle.Foundation.Command
{
    public sealed class ButtonCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Button clicked.");
        }
    }
}
