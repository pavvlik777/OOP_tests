using System.Collections.Generic;

namespace OOP.TwilightSparkle.Models
{
    public interface IFlyingEntity
    {
        int FlyingSpeed { get; set; }

        IReadOnlyCollection<IFlyingEntity> Squad { get; set; }
    }
}
