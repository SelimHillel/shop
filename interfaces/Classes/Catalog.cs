
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
            Filters = new Dictionary<string, string>();
        }

        public int Id { get; set; }
        public IEnumerable<string> Category { get; set; }
        public string Search { get; set; }
        public int Sort { get; set; }
        public Dictionary<string, string> Filters { get; set; }
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

            var list = ProductList.Select(x => x.Name).ToList(); //выводим только названия из отфильтрованных продуктов

            foreach (var val in list)
            {
                Console.WriteLine(val);
            }

        }

        void CatalogSearch()
        {
            //var resultProductList = new List<IProduct>();

            //foreach (var product in ProductList)
            //{
            //    if (product.Name.IndexOf("Searchkey") < 0)
            //    {
            //        continue;
            //    }

            //    if (product.Description.IndexOf("Searchkey") < 0)
            //    {
            //        continue;
            //    }


            //    var FilterFlag = true;
            //    foreach (var spec in product.Specifications)
            //    {
            //        if (spec.Value.IndexOf("Searchkey") < 0)
            //        {
            //            FilterFlag = false;
            //            break;
            //        }
            //    }

            //    if (!FilterFlag)
            //    {
            //        continue;
            //    }

            //    ProductList = resultProductList;

            //}

            var resultProductList = new List<IProduct>();
            foreach (var product in ProductList)
            {
                if (product.Name.IndexOf(Search) != -1)
                {
                    resultProductList.Add(product);
                }

                if (product.Description != null && product.Description.IndexOf(Search) != -1)
                {
                    resultProductList.Add(product);
                }

                foreach (var spec in product.Specifications)
                {
                    if (spec.Key.IndexOf(Search) != -1)
                    {
                        resultProductList.Add(product);
                    }

                    if (spec.Value.IndexOf(Search) != -1)
                    {
                        resultProductList.Add(product);
                    }
                }
            }

            ProductList = resultProductList;

            var list = ProductList.Select(x => x.Name).ToList();

            foreach (var val in list)
            {
                Console.WriteLine(val);
            }


        }


    }
    
}










