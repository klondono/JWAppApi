using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class FieldServiceSymbol
    {
        public FieldServiceSymbol()
        {
            TerritoryActivity = new HashSet<TerritoryActivity>();
        }

        public string FieldServiceSymbol1 { get; set; }
        public string FieldServiceSymbolDescription { get; set; }
        public int? ListOrder { get; set; }
        public int? CongregationId { get; set; }

        public Congregation Congregation { get; set; }
        public ICollection<TerritoryActivity> TerritoryActivity { get; set; }
    }
}
