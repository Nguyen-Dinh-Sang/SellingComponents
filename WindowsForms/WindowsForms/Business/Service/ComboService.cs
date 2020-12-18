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
    public class ComboService
    {
        private ComboRepository comboRepository = ComboRepository.getInstance();

        private static ComboService instance;

        private IMapper mapper = new MappingConfig().config();

        private ComboService()
        {

        }

        public static ComboService getInstance()
        {
            if (instance == null)
            {
                instance = new ComboService();
            }

            return instance;
        }

        public List<ComboDTO> getCombos()
        {
            return new List<ComboDTO>(mapper.Map<IEnumerable<Combo>, IEnumerable<ComboDTO>>(comboRepository.getCombos()));
        }

        public ComboDTO getComboById(int id)
        {
            return mapper.Map<Combo, ComboDTO>(comboRepository.getComboById(id));
        }

        public List<ComboDTO> getCombosByIdCatalog(int idCatalog)
        {
            return new List<ComboDTO>(mapper.Map<IEnumerable<Combo>, IEnumerable<ComboDTO>>(comboRepository.getCombosByIdCatalog(idCatalog)));
        }
        
        public List<ComboDTO> getComboBySearchString(string searchValue)
        {
            return new List<ComboDTO>(mapper.Map<IEnumerable<Combo>, IEnumerable<ComboDTO>>(comboRepository.getComboBySearchString(searchValue)));
        }
    }
}
