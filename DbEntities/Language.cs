using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class Language
    {
        public Language()
        {
            Congregation = new HashSet<Congregation>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public bool? IsActive { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public ICollection<Congregation> Congregation { get; set; }
    }
}
