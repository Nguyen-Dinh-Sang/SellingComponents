using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WindowsForms.DataAccess.Repository
{
    public class ProductRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static ProductRepository instance;

        private ProductRepository()
        {
        }

        public static ProductRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProductRepository();
            }

            return instance;
        }

        public IEnumerable<Product> getProducts()
        {
            return sellingComponentsDBContext.Products.Include(p => p.IdClassifyNavigation);
        }

        public void create(Product product)
        {
            sellingComponentsDBContext.Add(product);
            sellingComponentsDBContext.SaveChanges();
        }

        public void edit(Product product)
        {
            var pd = sellingComponentsDBContext.Products.Find(product.Id);
            pd.ProductName = product.ProductName;
            pd.Price = product.Price;
            pd.Detail = product.Detail;
            pd.IdClassify = product.IdClassify;
            sellingComponentsDBContext.SaveChanges();
        }

        public void delete(int id)
        {
            var product = sellingComponentsDBContext.Products.Find(id);
            sellingComponentsDBContext.Products.Remove(product);
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
