using JWAppApi.DbEntities;
using System.Collections.Generic;

namespace BusinessServices.Interfaces{

    public interface ITerritoryService
    {
        IEnumerable<Territory> GetTerritories();
    }
}
