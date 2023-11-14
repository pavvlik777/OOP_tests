using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OOP.TwilightSparkle.Foundation.Builders;
using OOP.TwilightSparkle.Foundation.Ponies;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Controllers
{
    [Route("api/ponies")]
    [ApiController]
    public sealed class PoniesController : ControllerBase
    {
        private readonly IPoniesService _poniesService;
        private readonly IPonyBuilder _ponyBuilder;

        private readonly WeatherContext _weatherContext;


        public PoniesController(
            IPoniesService poniesService,
            IPonyBuilder ponyBuilder)
        {
            _poniesService = poniesService;
            _ponyBuilder = ponyBuilder;

            _weatherContext = new WeatherContext();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pony>> GetById(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            var pony = new Pony();
            _ponyBuilder.SetCommonInfo(pony, externalPony.Id, externalPony.Name);

            return pony;
        }

        [HttpGet("pegasus/{id}")]
        public async Task<ActionResult<PegasusPony>> GetPegasusById(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            if (externalPony == null || externalPony.Type != ExternalPonyType.Pegasus)
            {
                return NotFound();
            }

            var pony = new PegasusPony();
            _ponyBuilder.SetCommonInfo(pony, externalPony.Id, externalPony.Name);
            _ponyBuilder.SetPegasusInfo(pony, externalPony.FlyingSpeed!.Value);

            return pony;
        }

        [HttpPost("pegasus/{id}/fly")]
        public async Task<ActionResult<PegasusPony>> MakePegasusFly(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            if (externalPony == null || externalPony.Type != ExternalPonyType.Pegasus)
            {
                return NotFound();
            }

            var pony = new PegasusPony();
            _ponyBuilder.SetCommonInfo(pony, externalPony.Id, externalPony.Name);
            _ponyBuilder.SetPegasusInfo(pony, externalPony.FlyingSpeed!.Value);

            if (!_weatherContext.CheckIfPegasusCanFly(pony))
            {
                return BadRequest();
            }

            return Ok();
        }



        //PATTERN State
        private interface IWeatherState
        {
            bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context);
        }

        private sealed class SunWeather : IWeatherState
        {
            public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
            {
                context.ChangeState(new WindyWeather());

                return true;
            }
        }

        private sealed class WindyWeather : IWeatherState
        {
            public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
            {
                return pegasus.FlyingSpeed > 10;
            }
        }

        private sealed class StormWeather : IWeatherState
        {
            public bool CheckIfPegasusCanFly(PegasusPony pegasus, WeatherContext context)
            {
                context.ChangeState(new SunWeather());

                return false;
            }
        }


        private sealed class WeatherContext
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
}
