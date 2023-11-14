using System.Collections.Generic;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Builders
{
    //PATTERN Builder
    public sealed class PonyBuilder : IPonyBuilder
    {
        public void SetCommonInfo(Pony pony, string id, string name)
        {
            pony.Id = id;
            pony.Name = name;
        }

        public void SetPegasusInfo(PegasusPony pony, int flyingSpeed)
        {
            pony.FlyingSpeed = flyingSpeed;
            pony.Subordinates = new List<Pony>();
        }
    }
}