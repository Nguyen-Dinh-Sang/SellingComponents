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
            /*if (Convert.ToInt32(searchValue))
            {
                int value = Convert.ToInt32(searchValue);
                var query = (from wh in sellingComponentsDBContext.Warehouses
                             where wh.IdProduct ==  || c.CatalogDetails.Contains(searchValue)
                             select c);

                return query;
            }*/
            return null;
        }
    }
}
