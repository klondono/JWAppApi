using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class Address
    {
        public Address()
        {
            Congregation = new HashSet<Congregation>();
            Person = new HashSet<Person>();
            TerritoryActivity = new HashSet<TerritoryActivity>();
            TerritoryAddressLink = new HashSet<TerritoryAddressLink>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Number { get; set; }
        public string PreDir { get; set; }
        public string Street { get; set; }
        public string Suffix { get; set; }
        public string PostDir { get; set; }
        public string Sec { get; set; }
        public string SecNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Zip4 { get; set; }
        public string County { get; set; }
        public string StateFp { get; set; }
        public string CountyFp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string GeoPrecision { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }

        public ICollection<Congregation> Congregation { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<TerritoryActivity> TerritoryActivity { get; set; }
        public ICollection<TerritoryAddressLink> TerritoryAddressLink { get; set; }
    }
}
