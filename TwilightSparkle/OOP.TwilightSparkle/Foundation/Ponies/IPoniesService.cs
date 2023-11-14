using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP.TwilightSparkle.Foundation.Ponies
{
    public interface IPoniesService
    {
        Task<ExternalPony> GetByIdAsync(string id);

        Task<IReadOnlyCollection<ExternalPony>> GetFastPegasusesAsync();
    }
}