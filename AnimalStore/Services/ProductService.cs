using AnimalStore.DataOperators;
using AnimalStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalStore.Services
{
    public class ProductService
    {
        private Repository repo;

        public ProductService()
        {
            repo = new Repository();
        }

        public IEnumerable<object> GetProducts()
        {
            return repo.All<TypesOfProduct>()
                .Include(p => p.Animal)
                .Include(p => p.TypeOfType)
                .Select(p => new
                {
                    Product = p.TypeName,
                    Type = p.TypeOfType.TypeOfTypeName,
                    Animal = p.Animal.AnimalName,
                    Quantity = p.AvailableQuantity,
                    Price = p.Price
                })
                .ToList();
        }

        public IEnumerable<object> GetProducts(decimal minPrice, decimal maxPrice)
        {
            var products = repo.All<TypesOfProduct>()
                .Include(p => p.Animal)
                .Include(p => p.TypeOfType)
                .Select(p => new
                {
                    Product = p.TypeName,
                    Type = p.TypeOfType.TypeOfTypeName,
                    Animal = p.Animal.AnimalName,
                    Quantity = p.AvailableQuantity,
                    Price = p.Price
                })
                .ToList();

            if(minPrice != null)
            {
                products = products
                    .Where(p => p.Price >= minPrice)
                    .ToList();
            }

            if (maxPrice != null)
            {
                products = products
                    .Where(p => p.Price <= maxPrice)
                    .ToList();
            }

            return products;
        }

        public IEnumerable<object> GetProducts(string productName)
        {
            return repo.All<TypesOfProduct>()
                .Include(p => p.Animal)
                .Include(p => p.TypeOfType)
                .Select(p => new
                {
                    Product = p.TypeName,
                    Type = p.TypeOfType.TypeOfTypeName,
                    Animal = p.Animal.AnimalName,
                    Quantity = p.AvailableQuantity,
                    Price = p.Price
                })
                .Where(p => p.Product == productName)
                .ToList();
        }
    }
}
