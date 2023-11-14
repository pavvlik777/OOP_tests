using OOP.TwilightSparkle.Foundation.Ponies;

namespace OOP.TwilightSparkle.Specifications
{
    public sealed class FastPonySpecification : Specification<ExternalPony>
    {
        private const int FastSpeed = 50;


        public override bool IsSatisfiedBy(ExternalPony obj)
        {
            return obj.FlyingSpeed > FastSpeed;
        }
    }
}
