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

        public IEnumerable<Combo> getComboBySearchString(string searchValue)
        {
            var query = (from c in sellingComponentsDBContext.Combos
                         where c.ComboName.Contains(searchValue) || c.ComboDetails.Contains(searchValue)
                         select c);

            return query;
        }


        public void create(Combo combo)
        {
            sellingComponentsDBContext.Add(combo);
            sellingComponentsDBContext.SaveChanges();
        }

        public void edit(Combo combo)
        {
            var cb = sellingComponentsDBContext.Combos.Find(combo.Id);
            cb.ComboName = combo.ComboName;
            cb.ComboDetails = combo.ComboDetails;
            cb.TotalCost = combo.TotalCost;
            cb.IdCatalog = combo.IdCatalog;
            sellingComponentsDBContext.SaveChanges();
        }

        public void delete(int id)
        {
            var combo = sellingComponentsDBContext.Combos.Find(id);
            sellingComponentsDBContext.Combos.Remove(combo);
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
