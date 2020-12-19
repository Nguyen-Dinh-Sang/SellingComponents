using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;
namespace WindowsForms.DataAccess.Repository
{
    class ComboDetailRepository
    {
        private static ComboDetailRepository instance;
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();
        public static ComboDetailRepository getInstance()
        {            if (instance == null)
            {
                instance = new ComboDetailRepository();
            }

            return instance;
        }
        public IEnumerable<ComboDetail> getComboDetails()
        {
            return sellingComponentsDBContext.ComboDetails;
        }

        public ComboDetail getComboDetailById(int id)
        {
            return sellingComponentsDBContext.ComboDetails.Find(id);
        }

        public IEnumerable<ComboDetail> getCombosByIdCombo(int idCombo)
        {
            var query = sellingComponentsDBContext.ComboDetails.Where(t => t.IdCombo == idCombo);

            return query;
        }
        public void create(ComboDetail comboDetail)
        {
            sellingComponentsDBContext.Add(comboDetail);
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
