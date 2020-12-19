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
    class ComboDetailService
    {
        private ComboDetailRepository comboDetailRepository = ComboDetailRepository.getInstance();

        private static ComboDetailService instance;

        private IMapper mapper = new MappingConfig().config();

        private ComboDetailService()
        {

        }

        public static ComboDetailService getInstance()
        {
            if (instance == null)
            {
                instance = new ComboDetailService();
            }

            return instance;
        }
        public void create(ComboDetailDTO comboDetailDTO)
        {
            comboDetailRepository.create(mapper.Map<ComboDetailDTO, ComboDetail>(comboDetailDTO));
        }

    }
}
