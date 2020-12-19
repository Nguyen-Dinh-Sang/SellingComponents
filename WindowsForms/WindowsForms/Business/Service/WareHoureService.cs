using AutoMapper;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.Business.DTO;
using WindowsForms.DataAccess.Entity;
using WindowsForms.DataAccess.Repository;

namespace WindowsForms.Business.Service
{
    public class WareHoureService
    {
        private WareHouseRepository wareHouseRepository = WareHouseRepository.getInstance();

        private static WareHoureService instance;

        private IMapper mapper = new MappingConfig().config();

        private WareHoureService()
        {

        }

        public static WareHoureService getInstance()
        {
            if (instance == null)
            {
                instance = new WareHoureService();
            }

            return instance;
        }

        public List<WareHouseDTO> getWareHouses()
        {
            return new List<WareHouseDTO>(mapper.Map<IEnumerable<Warehouse>, IEnumerable<WareHouseDTO>>(wareHouseRepository.getWarehouses()));
        }

        public WareHouseDTO getWareHouseById(int id)
        {
            return mapper.Map<Warehouse, WareHouseDTO>(wareHouseRepository.getWareHouseById(id));
        }
     
        public List<WareHouseDTO> getWareHouseBySearchString(string searchValue)
        {
            return new List<WareHouseDTO>(mapper.Map<IEnumerable<Warehouse>, IEnumerable<WareHouseDTO>>(wareHouseRepository.getWareHouseBySearchString(searchValue)));
        }

        public void create(WareHouseDTO wareHouse)
        {
            wareHouseRepository.create(mapper.Map<WareHouseDTO, Warehouse>(wareHouse));
        }
    }
}
