using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.Business.DTO;

namespace WindowsForms.Business.Service
{
    public class Service
    {
        private ClassifyService classifyService = ClassifyService.getInstance();

        private ProductService productService = ProductService.getInstance();

        private CatalogService catalogService = CatalogService.getInstance();

        private static Service instance;

        private Service()
        {

        }

        public static Service getInstance()
        {
            if (instance == null)
            {
                instance = new Service();
            }

            return instance;
        }

        public IEnumerable<ClassifyDTO> getClassifies()
        {
            return classifyService.getClassifies();
        }

        public ClassifyDTO getClassifyByIdProduct(int id)
        {
            return classifyService.getClassifyByIdProduct(id);
        }

        public List<CatalogDTO> getCatalogs()
        {
            return catalogService.getCatalogs();
        }

        public void createProduct(ProductDTO product)
        {
            productService.create(product);
        }

        public void editProduct(ProductDTO product)
        {
            productService.edit(product);
        }

        public void deleteProduct(int id)
        {
            productService.delete(id);
        }

        public void createCatalog(CatalogDTO catalog)
        {
            catalogService.create(catalog);
        }

        public void editCatalog(CatalogDTO catalog)
        {
            catalogService.edit(catalog);
        }

        public void deleteCatalog(int id)
        {
            catalogService.delete(id);
        }
    }
}
