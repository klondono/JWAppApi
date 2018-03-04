using System.Collections.Generic;
using JWAppApi.DbEntities;
using BusinessServices.Interfaces;
using System.Linq;

namespace BusinessServices.Implementations
{
    public class TerritoryService: BusinessService, ITerritoryService
    {
        private readonly JWAppContext db;

        public TerritoryService(JWAppContext dbContext)
        {
            db = dbContext;
        }

        public IEnumerable<Territory> GetTerritories(){

            return db.Territory;
        }
    }
}
