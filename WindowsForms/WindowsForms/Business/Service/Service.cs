using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.Business.DTO;
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.Business.Service
{
    public class Service
    {
        private ClassifyService classifyService = ClassifyService.getInstance();

        private ProductService productService = ProductService.getInstance();

        private CatalogService catalogService = CatalogService.getInstance();

        private ComboService comboService = ComboService.getInstance();

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

        public List<ComboDTO> getCombos()
        {
            return comboService.getCombos();
        }

        public ComboDTO getComboByID(int id)
        {
            return comboService.getComboById(id);
        }

        public List<ProductDTO> getProductsByIdCatalog(int idCatalog)
        {
            return productService.getProductsByIdCatalog(idCatalog);
        }

        public List<ProductDTO> getProductBySearchString(string searchValue)
        {
            return productService.getProductBySearchString(searchValue);
        }

        public List<ProductDTO> getProductByIdCombo(int idCombo)
        {
            return productService.getProductByIdCombo(idCombo);
        }

        public List<ProductDTO> getProductByIdClassify(int idClassify)
        {
            return productService.getProductByIdClassify(idClassify);
        }

        public List<ClassifyDTO> getClassifyBySearchString(string searchValue)
        {
            return classifyService.getClassifyBySearchString(searchValue);
        }

        public void createClassify(ClassifyDTO classify)
        {
            classifyService.create(classify);
        }

        public void editClassify(ClassifyDTO classify)
        {
            classifyService.edit(classify);
        }

        public void deleteClassify(int id)
        {
            classifyService.delete(id);
        }

        public List<ComboDTO> getCombosByIdCatalog(int idCatalog)
        {
            return comboService.getCombosByIdCatalog(idCatalog);
        }

        public List<ComboDTO> getComboBySearchString(string searchValue)
        {
            return comboService.getComboBySearchString(searchValue);
        }

        public void createCombo(ComboDTO combo)
        {
            comboService.create(combo);
        }

        public void editCombo(ComboDTO combo)
        {
            comboService.edit(combo);
        }

        public void deleteCombo(int id)
        {
            comboService.delete(id);
        }

        public List<CatalogDTO> getCatalogBySearchString(string searchValue)
        {
            return catalogService.getCatalogBySearchString(searchValue);
        }
    }
}
