namespace OOP.TwilightSparkle.Models
{
    public sealed class Butterfly : IFlyingEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int FlyingSpeed { get; set; }
    }
}