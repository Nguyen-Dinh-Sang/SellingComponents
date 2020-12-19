using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Entity;
using WindowsForms.DataAccess.Repository;

namespace WindowsForms.Business.Service
{
    public class ThongKeService
    {
        private ThongKeRepository thongKeRepository = ThongKeRepository.getInstance();

        private static ThongKeService instance;

        private ThongKeService()
        {

        }

        public static ThongKeService getInstance()
        {
            if (instance == null)
            {
                instance = new ThongKeService();
            }

            return instance;
        }

        public List<ThongKe> GetThongKes(DateTime tu, DateTime den)
        {
            return new List<ThongKe>(thongKeRepository.GetThongKes(tu, den));
        }
    }
}
