using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.DataAccess.Repository
{
    public class CatalogRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static CatalogRepository instance;

        private CatalogRepository()
        {
        }

        public static CatalogRepository getInstance()
        {
            if (instance == null)
            {
                instance = new CatalogRepository();
            }

            return instance;
        }

        public IEnumerable<Catalog> getCatalogs()
        {
            return sellingComponentsDBContext.Catalogs;
        }

        public void create(Catalog catalog)
        {
            sellingComponentsDBContext.Add(catalog);
            sellingComponentsDBContext.SaveChanges();
        }

        public void edit(Catalog catalog)
        {
            var ctl = sellingComponentsDBContext.Catalogs.Find(catalog.Id);
            ctl.CatalogName = catalog.CatalogName;
            ctl.CatalogDetails = catalog.CatalogDetails;
            sellingComponentsDBContext.SaveChanges();
        }

        public void delete(int id)
        {
            var catalog = sellingComponentsDBContext.Catalogs.Find(id);
            sellingComponentsDBContext.Catalogs.Remove(catalog);
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
