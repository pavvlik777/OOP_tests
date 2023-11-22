using System;
using OOP.TwilightSparkle.Controllers;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Command
{
    public sealed class FlyBackwardsCommand : IFlyPegasusCommand
    {
        private const int SpeedToFlyBackwards = 33;

        private readonly PoniesController.PegasusFlyService _flyService;
        private readonly PegasusPony _pony;


        public FlyBackwardsCommand(PoniesController.PegasusFlyService flyService, PegasusPony pony)
        {
            _flyService = flyService;
            _pony = pony;
        }


        public void Fly()
        {
            if (_pony.FlyingSpeed < SpeedToFlyBackwards)
            {
                Console.WriteLine("Can't fly backwards, not enough speed.");

                return;
            }

            Console.WriteLine("Flying backwards.");
            _flyService.SaveExecutedCommand(this, $"{_pony.Name} flying backwards.");
        }
    }
}