using Bogus;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> prodList = new List<ProductModel>();
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if(prodList.Count == 0)
            {
                prodList.Add(new ProductModel { Id = 1, Name = "Gaming Controller", Price = 999, Description = "Used to play games" });

                prodList.Add(new ProductModel { Id = 2, Name = "Mouse Pad", Price = 149, Description = "A square piece of plastic to make mousing easier" });

                prodList.Add(new ProductModel { Id = 3, Name = "Web Cam", Price = 499, Description = "Enables you to attend more Zoom meetings" });

                for (int i = 0; i < 100; i++)
                {
                    prodList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 4)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(1000))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }
            
            return prodList;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
