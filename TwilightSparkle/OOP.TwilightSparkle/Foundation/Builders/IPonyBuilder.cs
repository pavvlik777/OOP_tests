using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Builders
{
    public interface IPonyBuilder
    {
        void SetCommonInfo(Pony pony, string id, string name);

        void SetPegasusInfo(PegasusPony pony, int flyingSpeed);
    }
}