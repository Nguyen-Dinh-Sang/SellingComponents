using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.DataAccess.Repository
{
    public class ComboRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static ComboRepository instance;

        private ComboRepository()
        {
        }

        public static ComboRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ComboRepository();
            }

            return instance;
        }

        public IEnumerable<Combo> getCombos()
        {
            return sellingComponentsDBContext.Combos;
        }
    }
}
