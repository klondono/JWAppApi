using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class Congregation
    {
        public Congregation()
        {
            FieldServiceSymbol = new HashSet<FieldServiceSymbol>();
            Person = new HashSet<Person>();
            Territory = new HashSet<Territory>();
        }

        public int CongregationId { get; set; }
        public int CongregationNo { get; set; }
        public string CongregationName { get; set; }
        public string CongregationNameLong { get; set; }
        public string CongregationPhoneNo { get; set; }
        public string CongregationEmail { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public int? AddressId { get; set; }
        public int LanguageId { get; set; }

        public Address Address { get; set; }
        public Language Language { get; set; }
        public ICollection<FieldServiceSymbol> FieldServiceSymbol { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<Territory> Territory { get; set; }
    }
}
