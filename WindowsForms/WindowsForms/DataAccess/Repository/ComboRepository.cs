using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;

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

        public Combo getComboById(int id)
        {
            return sellingComponentsDBContext.Combos.Find(id);
        }

        public IEnumerable<Combo> getCombosByIdCatalog(int idCatalog)
        {
            var query = (from c in sellingComponentsDBContext.Combos
                         where c.IdCatalog == idCatalog
                         select c);

            return query;
        }
    }
}
