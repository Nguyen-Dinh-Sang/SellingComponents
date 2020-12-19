using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;
using System.Linq;


namespace WindowsForms.DataAccess.Repository
{
    public class ThongKeRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static ThongKeRepository instance;

        private ThongKeRepository()
        {
        }

        public static ThongKeRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ThongKeRepository();
            }

            return instance;
        }

        public IEnumerable<ThongKe> GetThongKes(DateTime? tu, DateTime? den)
        {
            var queryThongKe = (from od in sellingComponentsDBContext.Orders
                                join u in sellingComponentsDBContext.UserInformations on od.IdUser equals u.Id
                                select new ThongKe
                                {
                                    Id = od.Id,
                                    IdUser = od.IdUser,
                                    OrderDate = od.OrderDate,
                                    TotalCost = od.TotalCost,
                                    DeliveryAddress = od.DeliveryAddress,
                                    DeliveryDate = od.DeliveryDate,
                                    UserName = u.UserName,
                                    FullName = u.FullName
                                });
            if(tu != null && den !=null)
            {
                var query = (from tk in queryThongKe
                             where tk.OrderDate >= tu && tk.OrderDate <= den
                             select tk);

                return query;
            }
            return queryThongKe;
        }
    }
}
