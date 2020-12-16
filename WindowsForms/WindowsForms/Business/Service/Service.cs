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
    }
}
