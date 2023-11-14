using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Specifications
{
    public sealed class FastPegasusSpecification : ISpecification<PegasusPony>
    {
        private const int FastSpeed = 50;


        public bool IsSatisfiedBy(PegasusPony obj)
        {
            return obj.FlyingSpeed > FastSpeed;
        }
    }
}
