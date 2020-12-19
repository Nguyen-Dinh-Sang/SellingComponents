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
            return sellingComponentsDBContext.Products;
        }
        public IEnumerable<Product> getProductNotInCombo(int idCombo)
        {
            var queryComboDetail = (from cbd in sellingComponentsDBContext.ComboDetails
                                    where cbd.IdCombo == idCombo
                                    select cbd);

            var queryProduct = (from cbd in queryComboDetail
                                join p in sellingComponentsDBContext.Products on cbd.IdProduct equals p.Id
                                select p);
            var query = from p in sellingComponentsDBContext.Products
                        where !((from cb in queryProduct
                                select cb.Id).Contains(p.Id))
                                select p;
            return query;
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

        public IEnumerable<Product> getProductsByIdCatalog(int idCatalog)
        {
            var queryComboByIdCatalog = (from cb in sellingComponentsDBContext.Combos
                                         where cb.IdCatalog == idCatalog
                                         select cb);

            var queryComboDetaltByIdCombo = (from cbd in sellingComponentsDBContext.ComboDetails
                                             where (from cb in queryComboByIdCatalog
                                                    select cb.Id).Contains(cbd.IdCombo)
                                             select cbd);

            var queryProduct = (from cbd in queryComboDetaltByIdCombo
                                join p in sellingComponentsDBContext.Products on cbd.IdProduct equals p.Id
                                select p);

            return queryProduct;
        }

        public IEnumerable<Product> getProductBySearchString(string searchValue)
        {
            var queryProduct = (from p in sellingComponentsDBContext.Products
                                where p.ProductName.Contains(searchValue) ||
                                      p.Detail.Contains(searchValue)
                                select p);

            return queryProduct;
        }

        public IEnumerable<Product> getProductByIdCombo(int idCombo)
        {
            var queryComboDetail = (from cbd in sellingComponentsDBContext.ComboDetails
                                    where cbd.IdCombo == idCombo
                                    select cbd);

            var queryProduct = (from cbd in queryComboDetail
                                join p in sellingComponentsDBContext.Products on cbd.IdProduct equals p.Id
                                select p);

            return queryProduct;
        }

        public IEnumerable<Product> getProductByIdClassify(int idClassify)
        {
            var queryProduct = (from p in sellingComponentsDBContext.Products
                                where p.IdClassify == idClassify
                                select p);

            return queryProduct;
        }
    }
}
