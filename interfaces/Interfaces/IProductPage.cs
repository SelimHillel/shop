using System.Collections.Generic;

namespace interfaces.Interfaces
{
    interface IProductPage
    {
        IProduct Product { get; set; } //сам продукт
        //IEnumerable<IReview> Reviews { get; set; } //массив объектов 
        IEnumerable<IProduct> RelatedProducts { get; set; } //массив продуктов
    }
}
