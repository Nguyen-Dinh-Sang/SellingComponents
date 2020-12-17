using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Entity;
using WindowsForms.DataAccess.Repository;
using System.Linq;
using AutoMapper;
using Business.Mapping;
using WindowsForms.Business.DTO;

namespace WindowsForms.Business.Service
{
    public class ProductService
    {
        private ProductRepository productRepository = ProductRepository.getInstance();

        private static ProductService instance;

        private IMapper mapper = new MappingConfig().config();

        private ProductService()
        {

        }

        public static ProductService getInstance()
        {
            if (instance == null)
            {
                instance = new ProductService();
            }

            return instance;
        }

        public List<ProductDTO> getProducts()
        {
            return new List<ProductDTO>(mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productRepository.getProducts()));
        }

        public void create(ProductDTO product)
        {
            productRepository.create(mapper.Map<ProductDTO, Product>(product));
        }

        public void edit(ProductDTO product)
        {
            productRepository.edit(mapper.Map<ProductDTO, Product>(product));
        }

        public void delete(int id)
        {
            productRepository.delete(id);
        }

        public List<ProductDTO> getProductsByIdCatalog(int idCatalog)
        {
            return new List<ProductDTO>(mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productRepository.getProductsByIdCatalog(idCatalog)));
        }

        public List<ProductDTO> getProductBySearchString(string searchValue)
        {
            return new List<ProductDTO>(mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productRepository.getProductBySearchString(searchValue)));
        }
       
        public List<ProductDTO> getProductByIdCombo(int idCombo)
        {
            return new List<ProductDTO>(mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productRepository.getProductByIdCombo(idCombo)));
        }
    }
}
