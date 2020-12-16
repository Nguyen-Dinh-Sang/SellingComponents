using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.Business.DTO;
using WindowsForms.DataAccess.Entity;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<ClassifyDTO, Classify>();
            CreateMap<Classify, ClassifyDTO>();

            CreateMap<CatalogDTO, Catalog>();
            CreateMap<Catalog, CatalogDTO>();
        }
    }
}
