using System;
using OOP.TwilightSparkle.Controllers;
using OOP.TwilightSparkle.Foundation.State;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Command
{
    public sealed class FlyFastCommand : IFlyPegasusCommand
    {
        private readonly PoniesController.PegasusFlyService _flyService;
        private readonly WeatherContext _weatherContext;
        private readonly PegasusPony _pony;


        public FlyFastCommand(PoniesController.PegasusFlyService flyService, WeatherContext weatherContext, PegasusPony pony)
        {
            _flyService = flyService;
            _weatherContext = weatherContext;
            _pony = pony;
        }


        public void Fly()
        {
            if (!_weatherContext.CheckIfPegasusCanFly(_pony))
            {
                Console.WriteLine("Can't fly in this weather.");

                return;
            }

            Console.WriteLine("Flying.");
            _flyService.SaveExecutedCommand(this, $"{_pony.Name} flying.");
        }
    }
}