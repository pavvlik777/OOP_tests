using System.Threading.Tasks;

namespace OOP.TwilightSparkle.Foundation.Ponies
{
    public interface IPoniesService
    {
        Task<ExternalPony> GetByIdAsync(string id);
    }
}