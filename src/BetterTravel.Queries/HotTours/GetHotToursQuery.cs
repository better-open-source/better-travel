using System.Collections.Generic;
using BetterTravel.DataAccess.Abstraction.Entities.Enums;
using BetterTravel.Queries.Abstractions;
using BetterTravel.Queries.ViewModels;

namespace BetterTravel.Queries.HotTours
{
    public class GetHotToursQuery : IQuery<List<GetHotToursViewModel>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int[] Countries { get; set; }
        public Stars Stars { get; set; }
    }
}