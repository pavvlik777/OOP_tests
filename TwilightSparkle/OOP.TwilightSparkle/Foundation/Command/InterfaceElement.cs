namespace OOP.TwilightSparkle.Foundation.Command
{
    public sealed class InterfaceElement
    {
        private readonly ICommand _command;


        public InterfaceElement(ICommand command)
        {
            _command = command;
        }


        public void Execute()
        {
            _command.Execute();
        }
    }
}
