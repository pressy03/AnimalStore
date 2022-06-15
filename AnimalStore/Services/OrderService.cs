using AnimalStore.DataOperators;
using AnimalStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalStore.Services
{
    public class OrderService
    {
        private Repository repo;

        public OrderService()
        {
            repo = new Repository();
        }

        public IEnumerable<object> GetOrders()
        {
            List<object> result = new List<object>();

            var ordersDetails = repo.All<OrderDetail>()
                .Include(od => od.Type)
                .ThenInclude(od => od.Animal)
                .Select(o => new
                {
                    Id = o.OrderId,
                    Product = $"{o.Type.TypeName} за {o.Type.Animal.AnimalName}",
                    OrderedQuantity = o.OrderedQuantity,
                    TotalPrice = o.OrderedQuantity * o.Type.Price
                })
                .ToList();

            var orders = repo.All<Order>()
                .Select(o => new
                {
                    o.OrderId,
                    o.DateAndTime,
                    o.Fullfilled
                })
                .ToList();

            foreach (var order in orders)
            {
                var od = ordersDetails.FirstOrDefault(o => o.Id == order.OrderId);

                result.Add(new
                {
                    Product = od.Product,
                    OrderedQuantity = od.OrderedQuantity,
                    Date = order.DateAndTime.ToString("dd.MM.yyyy"),
                    Fullfilled = order.Fullfilled,
                    TotalPrice = od.TotalPrice
                });
            }

            return result;
        }

        public IEnumerable<object> GetOrders(int? cardId)
        {
            List<object> result = new List<object>();

            var ordersDetails = repo.All<OrderDetail>()
                .Include(od => od.Type)
                .ThenInclude(od => od.Animal)
                .Where(o => repo.All<Order>().FirstOrDefault(order => order.OrderId == o.OrderId).ClientCardId == cardId)
                .Select(o => new
                {
                    Id = o.OrderId,
                    Product = $"{o.Type.TypeName} за {o.Type.Animal.AnimalName}",
                    OrderedQuantity = o.OrderedQuantity,
                    TotalPrice = o.OrderedQuantity * o.Type.Price
                })
                .ToList();

            var orders = repo.All<Order>()
                .Where(o => o.ClientCardId == cardId)
                .Select(o => new
                {
                    o.OrderId,
                    o.DateAndTime,
                    o.Fullfilled
                })
                .ToList();

            foreach (var order in orders)
            {
                var od = ordersDetails.FirstOrDefault(o => o.Id == order.OrderId);

                result.Add(new
                {
                    Product = od.Product,
                    OrderedQuantity = od.OrderedQuantity,
                    Date = order.DateAndTime.ToString("dd.MM.yyyy"),
                    Fullfilled = order.Fullfilled,
                    TotalPrice = od.TotalPrice
                });
            }

            return result;
        }

        private string GetFormattedDate(int orderId)
        {
            return repo.All<Order>()
                .FirstOrDefault(order => order.OrderId == orderId)
                .DateAndTime
                .ToString("dd.MM.yyyy");
        }

        public IEnumerable<object> GetOrders(string date)
        {
            List<object> result = new List<object>();

            var ordersDetails = repo.All<OrderDetail>()
                .Include(od => od.Type)
                .ThenInclude(od => od.Animal)
                .ToList()
                .Where(o => GetFormattedDate(o.OrderId) == date)
                .Select(o => new
                {
                    Id = o.OrderId,
                    Product = $"{o.Type.TypeName} за {o.Type.Animal.AnimalName}",
                    OrderedQuantity = o.OrderedQuantity,
                    TotalPrice = o.OrderedQuantity * o.Type.Price
                })
                .ToList();

            var orders = repo.All<Order>()
                .ToList()
                .Where(o => o.DateAndTime.ToString("dd.MM.yyyy") == date)
                .Select(o => new
                {
                    o.OrderId,
                    o.DateAndTime,
                    o.Fullfilled
                })
                .ToList();

            foreach (var order in orders)
            {
                var od = ordersDetails.FirstOrDefault(o => o.Id == order.OrderId);

                result.Add(new
                {
                    Product = od.Product,
                    OrderedQuantity = od.OrderedQuantity,
                    Date = order.DateAndTime.ToString("dd.MM.yyyy"),
                    Fullfilled = order.Fullfilled,
                    TotalPrice = od.TotalPrice
                });
            }

            return result;
        }

        public IEnumerable<object> GetOrders(decimal? minPrice, decimal? maxPrice)
        {
            List<object> result = new List<object>();

            var ordersDetails = repo.All<OrderDetail>()
                .Include(od => od.Type)
                .ThenInclude(od => od.Animal)
                .Select(o => new
                {
                    Id = o.OrderId,
                    Product = $"{o.Type.TypeName} за {o.Type.Animal.AnimalName}",
                    OrderedQuantity = o.OrderedQuantity,
                    TotalPrice = o.OrderedQuantity * o.Type.Price
                })
                .ToList();

            var orders = repo.All<Order>()
                .Select(o => new
                {
                    o.OrderId,
                    o.DateAndTime,
                    o.Fullfilled
                })
                .ToList();

            if(minPrice != null)
            {
                ordersDetails = ordersDetails.Where(od => od.TotalPrice >= minPrice).ToList();
            }

            if (maxPrice != null)
            {
                ordersDetails = ordersDetails.Where(od => od.TotalPrice <= minPrice).ToList();
            }

            foreach (var od in ordersDetails)
            {
                var order = orders.FirstOrDefault(o => o.OrderId == od.Id);

                result.Add(new
                {
                    Product = od.Product,
                    OrderedQuantity = od.OrderedQuantity,
                    Date = order.DateAndTime.ToString("dd.MM.yyyy"),
                    Fullfilled = order.Fullfilled,
                    TotalPrice = od.TotalPrice
                });
            }

            return result;
        }
    }
}
