using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;

namespace WindowsForms.DataAccess.Repository
{
    public class ClassifyRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static ClassifyRepository instance;

        private ClassifyRepository()
        {
        }

        public static ClassifyRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ClassifyRepository();
            }

            return instance;
        }

        public IEnumerable<Classify> getClassifies()
        {
            return sellingComponentsDBContext.Classifies;
        }

        public Classify getClassifyByIdProduct(int id)
        {
            var product = (from p in sellingComponentsDBContext.Products
                           where p.Id == id
                           select p).First();
            int idClassify = product.IdClassify;
            return (from c in sellingComponentsDBContext.Classifies
                    where c.Id == idClassify
                    select c).First();
        }

        public IEnumerable<Classify> getClassifyBySearchString(string searchValue)
        {
            var queryClassify = (from c in sellingComponentsDBContext.Classifies
                                where c.ClassifyName.Contains(searchValue) ||
                                      c.ClassifyDetail.Contains(searchValue)
                                select c);

            return queryClassify;
        }

        public void create(Classify classify)
        {
            sellingComponentsDBContext.Add(classify);
            sellingComponentsDBContext.SaveChanges();
        }

        public void edit(Classify classify)
        {
            var c = sellingComponentsDBContext.Classifies.Find(classify.Id);
            c.ClassifyName = classify.ClassifyName;
            c.ClassifyDetail = classify.ClassifyDetail;
            sellingComponentsDBContext.SaveChanges();
        }

        public void delete(int id)
        {
            var classify = sellingComponentsDBContext.Classifies.Find(id);
            sellingComponentsDBContext.Classifies.Remove(classify);
            sellingComponentsDBContext.SaveChanges();
        }
    }
}
