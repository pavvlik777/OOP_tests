using System;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.State
{
    //PATTERN State
    public interface IWeatherState
    {
        bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context);
    }

    public sealed class SunWeather : IWeatherState
    {
        public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
        {
            context.ChangeState(new WindyWeather());

            return true;
        }
    }

    public sealed class WindyWeather : IWeatherState
    {
        public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
        {
            return pegasus.FlyingSpeed > 10;
        }
    }

    public sealed class StormWeather : IWeatherState
    {
        public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
        {
            context.ChangeState(new SunWeather());

            return false;
        }
    }


    public sealed class WeatherContext
    {
        private IWeatherState _state;


        public WeatherContext()
        {
            var now = DateTime.Now;
            if (now.Day < 3)
            {
                _state = new SunWeather();
                return;
            }
            if (now.Day < 15)
            {
                _state = new WindyWeather();
                return;
            }

            _state = new StormWeather();
        }


        public bool CheckIfPegasusCanFly(PegasusPony pegasus)
        {
            return _state.CheckIfPegasusCanFly(pegasus, this);
        }

        public void ChangeState(IWeatherState newState)
        {
            _state = newState;
        }
    }
}
