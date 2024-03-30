using NZWalks.API.Models.Domain;

//for testing purpose also line related to this in prgram.cs
namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
          {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ghufran Region",
                    Code = "GHU"
                }
            };
        }
    }
}
