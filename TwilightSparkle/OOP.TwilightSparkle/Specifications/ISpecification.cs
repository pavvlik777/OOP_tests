namespace OOP.TwilightSparkle.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);
    }
}
