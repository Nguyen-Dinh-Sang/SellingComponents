using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.DataAccess.Repository
{
    class CatalogRepository
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
    }
}
