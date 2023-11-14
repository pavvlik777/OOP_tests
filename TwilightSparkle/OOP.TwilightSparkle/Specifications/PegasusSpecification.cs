using OOP.TwilightSparkle.Foundation.Ponies;

namespace OOP.TwilightSparkle.Specifications
{
    public sealed class PegasusSpecification : Specification<ExternalPony>
    {
        public override bool IsSatisfiedBy(ExternalPony obj)
        {
            return obj.Type == ExternalPonyType.Pegasus;
        }
    }
}
