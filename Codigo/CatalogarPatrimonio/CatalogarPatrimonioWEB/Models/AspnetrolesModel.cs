
using System.Collections.Generic;
using Core;

namespace CatalogarPatrimonioWEB.Models
{
    public class AspnetrolesModel
    {
        public AspnetrolesModel()
        {
            Aspnetroleclaims = new HashSet<Aspnetroleclaims>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}