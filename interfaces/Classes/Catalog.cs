
using interfaces.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace interfaces
{
    class Catalog : IСatalog
    {

        public Catalog()
        {
            ProductList = new List<IProduct>();
            Filters = new Dictionary<string, object>();
        }

        public int Id { get; set; }
        public IEnumerable<string> Category { get; set; }
        public string Search { get; set; }
        public int Sort { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public int Pagenumber { get; set; }
        public string URL { get; set; }
        public List<IProduct> ProductList { get; set; }

        void Filter()
        {

            foreach (var filter in Filters)
            {
                var resultProductList = new List<IProduct>();


                foreach (var product in ProductList)
                {
                    if (filter.Key == "PriceFrom" && Convert.ToDouble(filter.Value) > product.Price)
                    {
                        continue;
                    }

                    if (filter.Key == "PriceTo" && Convert.ToDouble(filter.Value) < product.Price)
                    {
                        continue;
                    }
                    if (filter.Key == "IsEnabled" && !product.isEnabled)
                    {
                        continue;//не придёт к add
                    }

                    if (filter.Key == "HasImages" && product.Pic.Count() <= 0) //если количество ссылок (элементов в списке) <=0 то не интересует
                    {
                        continue;//не придёт к add
                    }

                    var filterFlag = true;
                    foreach (var spec in product.Specifications)
                    {
                        if (filter.Key == spec.Key && filter.Value != spec.Value)
                        {
                            filterFlag = false;
                            break;
                        }
                    }

                    if (!filterFlag)
                    {
                        continue;
                    }

                    resultProductList.Add(product);
                }
                ProductList = resultProductList;
            }

        }



        List<IProduct> SearchInCatalog(string keyWord)
        {
            var resultSearch = new List<IProduct>();

            foreach (var product in ProductList)
            {
                if (keyWord == product.Name || Convert.ToUInt32(keyWord) == product.Id)
                {
                    resultSearch.Add(product);
                }
                else
                {
                    foreach (var category in product.Categories)
                    {
                        if (keyWord == category)
                        {
                            resultSearch.Add(product);
                        }
                    }              
                }
                                   
            }
            return resultSearch;
        }
    }
}










