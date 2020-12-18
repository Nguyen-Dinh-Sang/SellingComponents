using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;

namespace WindowsForms.DataAccess.Repository
{
    public class WareHouseRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static WareHouseRepository instance;

        private WareHouseRepository()
        {
        }

        public static WareHouseRepository getInstance()
        {
            if (instance == null)
            {
                instance = new WareHouseRepository();
            }

            return instance;
        }

        public IEnumerable<Warehouse> getWarehouses()
        {
            return sellingComponentsDBContext.Warehouses;
        }

        public Warehouse getWareHouseById(int id)
        {
            return sellingComponentsDBContext.Warehouses.Find(id);
        }

        public IEnumerable<Warehouse> getWareHouseBySearchString(string searchValue)
        {
            int id = -1;
            if (Int32.TryParse(searchValue, out id))
            {
                var query = (from wh in sellingComponentsDBContext.Warehouses
                             where wh.IdProduct == id || wh.Amount == id
                             select wh);

                return query;
            } else
            {
                var queryProduct = (from p in sellingComponentsDBContext.Products
                                    where p.ProductName.Contains(searchValue)
                                    select p);

                var queryWareHouseByProductName = (from wh in sellingComponentsDBContext.Warehouses
                                                   where (from p in queryProduct
                                                          select p.Id).Contains(wh.IdProduct)
                                                    select wh);

                return queryWareHouseByProductName;
            }
        }

        public void create(Warehouse warehouse)
        {
            sellingComponentsDBContext.Add(warehouse);
            var pd = sellingComponentsDBContext.Products.Find(warehouse.IdProduct);
            pd.Amount += warehouse.Amount;
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
