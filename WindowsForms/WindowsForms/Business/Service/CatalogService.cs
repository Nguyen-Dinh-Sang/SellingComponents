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
    public class CatalogService
    {
        private CatalogRepository catalogRepository = CatalogRepository.getInstance();

        private static CatalogService instance;

        private IMapper mapper = new MappingConfig().config();

        private CatalogService()
        {

        }

        public static CatalogService getInstance()
        {
            if (instance == null)
            {
                instance = new CatalogService();
            }

            return instance;
        }

        public List<CatalogDTO> getCatalogs()
        {
            return new List<CatalogDTO>(mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDTO>>(catalogRepository.getCatalogs()));
        }
    }
}
