using interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces.Classes
{
    class Product : IProduct

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string URL { get; set; }
        public bool isEnabled { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> PaymentMethods { get; set; }
        public Dictionary<string, object> Specifications { get; set; }
        public IEnumerable<string> Pic { get; set; }
       //public ISale SpecialOffer { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
