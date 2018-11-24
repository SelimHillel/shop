using System.Collections.Generic;

namespace interfaces.Interfaces
{

    interface IСatalog
    {
        int Id { get; set; }
        IEnumerable<string> Category { get; set; }
        List<IProduct> ProductList { get ; set; }
        string Search { get; set; }
        int Sort { get; set; } //id типа сортировки который применён
        Dictionary<string, string> Filters { get; set; } //словарь: цвет, чёрный
        int Pagenumber { get; set; } //на какой странице каталога
        string URL { get; set; }
    
    }

}
