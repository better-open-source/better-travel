using System.Collections.Generic;
using System.Threading.Tasks;
using BetterTravel.Domain.Entities;
using BetterTravel.HotToursFetcher.Function.Providers;

namespace BetterTravel.HotToursFetcher.Function.Abstractions
{
    public interface IPoehalisnamiProvider
    {
        Task<List<HotTour>> GetHotToursAsync(PoehalisnamiQuery query);
    }
}