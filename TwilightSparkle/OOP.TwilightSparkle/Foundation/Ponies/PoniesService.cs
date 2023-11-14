using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP.TwilightSparkle.Foundation.Ponies
{
    public sealed class PoniesService : IPoniesService
    {
        private static readonly IReadOnlyCollection<ExternalPony> Ponies;


        static PoniesService()
        {
            Ponies = new List<ExternalPony>
            {
                new ()
                {
                    Id = "TwilightSparkle",
                    Name = "Twilight Sparkle",
                    Type = ExternalPonyType.Unicorn,
                    FlyingSpeed = null,
                },
                new ()
                {
                    Id = "RainbowDash",
                    Name = "Rainbow Dash",
                    Type = ExternalPonyType.Pegasus,
                    FlyingSpeed = 80,
                },
                new ()
                {
                    Id = "Applejack",
                    Name = "Applejack",
                    Type = ExternalPonyType.EarthPony,
                    FlyingSpeed = null,
                },
            };
        }


        public async Task<ExternalPony> GetByIdAsync(string id)
        {
            await Task.Delay(3000);
            var pony = Ponies.SingleOrDefault(p => p.Id == id);

            return pony;
        }
    }
}