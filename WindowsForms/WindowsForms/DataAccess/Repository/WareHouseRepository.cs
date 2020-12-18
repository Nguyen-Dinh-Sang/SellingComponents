using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;

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
    }
}
