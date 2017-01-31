using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememBeer.Models
{
    public class Beer
    {
        public BeerType Type { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<BeerReview> Reviews { get; set; }
    }
}
