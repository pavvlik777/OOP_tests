using OOP.TwilightSparkle.Models;

namespace OOP.TwilightSparkle.Foundation.Builders
{
    public interface IPegasusPonyBuilder
    {
        IPegasusPonyBuilder Reset();

        IPegasusPonyBuilder SetCommonInfo(string id, string name);

        IPegasusPonyBuilder SetPegasusInfo(int flyingSpeed);

        PegasusPony GetResult();
    }
}