﻿using Shop.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.OrderBy(x => x.Name);
        }

        public Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return this.context.Products.Any(p => p.Id == id);
        }
    }
}
