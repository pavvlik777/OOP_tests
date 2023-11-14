using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP.TwilightSparkle.Foundation.Ponies
{
    //PATTERN Proxy
    public sealed class CachedPoniesService : IPoniesService
    {
        private readonly PoniesService _service;

        private static readonly IList<ExternalPony> CachedPonies;


        public CachedPoniesService()
        {
            _service = new PoniesService();
        }

        static CachedPoniesService()
        {
            CachedPonies = new List<ExternalPony>();
        }


        public async Task<ExternalPony> GetByIdAsync(string id)
        {
            var cachedPony = CachedPonies.SingleOrDefault(p => p.Id == id);
            if (cachedPony == null)
            {
                cachedPony = await _service.GetByIdAsync(id);
                CachedPonies.Add(cachedPony);
            }

            return cachedPony;
        }
    }
}