using System.Collections.Generic;
using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Builders
{
    //PATTERN Builder
    public sealed class PegasusPonyBuilder : IPegasusPonyBuilder
    {
        private PegasusPony _pony;


        public PegasusPonyBuilder()
        {
            _pony = new PegasusPony();
        }


        public IPegasusPonyBuilder Reset()
        {
            _pony = new PegasusPony();

            return this;
        }

        public IPegasusPonyBuilder SetCommonInfo(string id, string name)
        {
            _pony.Id = id;
            _pony.Name = name;

            return this;
        }

        public IPegasusPonyBuilder SetPegasusInfo(int flyingSpeed)
        {
            _pony.FlyingSpeed = flyingSpeed;
            _pony.Squad = new List<IFlyingEntity>();

            return this;
        }

        public PegasusPony GetResult()
        {
            return _pony;
        }
    }
}