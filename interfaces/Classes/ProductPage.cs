using interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces.Classes
{
    class ProductPage : IProductPage
    {
        public IProduct Product { get; set; }
        //public IEnumerable<IReview> Reviews { get; set; }
        public IEnumerable<IProduct> RelatedProducts { get; set; }
    }
}
