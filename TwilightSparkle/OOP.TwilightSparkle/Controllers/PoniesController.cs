using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OOP.TwilightSparkle.Foundation.Builders;
using OOP.TwilightSparkle.Foundation.Command;
using OOP.TwilightSparkle.Foundation.Ponies;
using OOP.TwilightSparkle.Foundation.State;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Controllers
{
    [Route("api/ponies")]
    [ApiController]
    public sealed class PoniesController : ControllerBase
    {
        private readonly IPoniesService _poniesService;
        private readonly IPegasusPonyBuilder _ponyBuilder;

        private readonly WeatherContext _weatherContext;


        public PoniesController(
            IPoniesService poniesService,
            IPegasusPonyBuilder ponyBuilder)
        {
            _poniesService = poniesService;
            _ponyBuilder = ponyBuilder;

            _weatherContext = new WeatherContext();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pony>> GetById(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            var pony = _ponyBuilder
                .Reset()
                .SetCommonInfo(externalPony.Id, externalPony.Name)
                .GetResult();

            return pony;
        }

        [HttpGet("pegasuses/{id}")]
        public async Task<ActionResult<PegasusPony>> GetPegasusById(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            if (externalPony == null || externalPony.Type != ExternalPonyType.Pegasus)
            {
                return NotFound();
            }

            var pony = _ponyBuilder
                .Reset()
                .SetCommonInfo(externalPony.Id, externalPony.Name)
                .SetPegasusInfo(externalPony.FlyingSpeed!.Value)
                .GetResult();

            return pony;
        }

        [HttpPost("pegasuses/{id}/fly")]
        public async Task<ActionResult<PegasusPony>> MakePegasusFly(string id)
        {
            var externalPony = await _poniesService.GetByIdAsync(id);
            if (externalPony == null || externalPony.Type != ExternalPonyType.Pegasus)
            {
                return NotFound();
            }

            var pony = _ponyBuilder
                .Reset()
                .SetCommonInfo(externalPony.Id, externalPony.Name)
                .SetPegasusInfo(externalPony.FlyingSpeed!.Value)
                .GetResult();

            if (!_weatherContext.CheckIfPegasusCanFly(pony))
            {
                return BadRequest();
            }

            var flyService = new PegasusFlyService();
            var commands = new List<IFlyPegasusCommand>
            {
                new FlyFastCommand(flyService, _weatherContext, pony),
                new FlyBackwardsCommand(flyService, pony),
                new FlyBackwardsCommand(flyService, pony),
                new FlyFastCommand(flyService, _weatherContext, pony),
            };

            foreach (var command in commands)
            {
                command.Fly();
            }

            flyService.WriteCommandsStats();

            return Ok();
        }

        [HttpGet("pegasuses/fast")]
        public async Task<ActionResult<PegasusPony>> GetFastPegasuses()
        {
            var externalPonies = await _poniesService.GetFastPegasusesAsync();

            var ponies = externalPonies
                .Select(p =>
                {
                    var pony = _ponyBuilder
                        .Reset()
                        .SetCommonInfo(p.Id, p.Name)
                        .SetPegasusInfo(p.FlyingSpeed!.Value)
                        .GetResult();

                    return pony;
                })
                .ToList();

            return Ok(ponies);
        }



        public sealed class PegasusFlyService
        {
            private readonly IList<IFlyPegasusCommand> _commands;
            private readonly IList<string> _commandMessages;


            public PegasusFlyService()
            {
                _commands = new List<IFlyPegasusCommand>();
                _commandMessages = new List<string>();
            }


            public void SaveExecutedCommand(IFlyPegasusCommand command, string commandMessage)
            {
                _commands.Add(command);
                _commandMessages.Add(commandMessage);
            }

            public void WriteCommandsStats()
            {
                Console.WriteLine($"Successfully executed {_commands.Count} commands.");
                foreach (var commandMessage in _commandMessages)
                {
                    Console.Write(commandMessage);
                }
            }
        }
    }
}
