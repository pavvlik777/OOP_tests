using System;
using System.Collections.Generic;

namespace OOP.TwilightSparkle.Models
{
    public sealed class PegasusPony : Pony, IFlyingEntity
    {
        public int FlyingSpeed { get; set; }

        public IReadOnlyCollection<IFlyingEntity> Squad { get; set; } //Composite


        public PegasusPony Clone() //Prototype
        {
            Console.WriteLine("Cloning forbidden by pegasus council, but go on.");
            Squad = new List<IFlyingEntity>();
            Console.WriteLine("Subordinates are removed because reasons.");

            return (PegasusPony)MemberwiseClone();
        }
    }
}