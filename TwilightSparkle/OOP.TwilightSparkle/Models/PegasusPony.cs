using System;
using System.Collections.Generic;

namespace OOP.TwilightSparkle.Models
{
    public sealed class PegasusPony : Pony
    {
        public int FlyingSpeed { get; set; }

        public IReadOnlyCollection<Pony> Subordinates { get; set; } //Composite


        public PegasusPony Clone() //Prototype
        {
            Console.WriteLine("Cloning forbidden by pegasus council, but go on.");
            Subordinates = new List<Pony>();
            Console.WriteLine("Subordinates are removed because reasons.");

            return (PegasusPony)MemberwiseClone();
        }
    }
}