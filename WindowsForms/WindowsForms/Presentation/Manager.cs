using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsForms.Business.DTO;
using WindowsForms.Business.Service;

namespace WindowsForms.Presentation
{
    public partial class Manager : Form
    {
        private String username;
        private ProductService productService = ProductService.getInstance();
        private Service service = Service.getInstance();
        private BindingSource bindingSourceProduct = new BindingSource();
        private BindingSource bindingSourceCatalog = new BindingSource();

        public Manager(String username)
        {
            this.username = username;
            InitializeComponent();
            load();
        }

        private void load()
        {
            dataGridViewProduct.DataSource = bindingSourceProduct;
            dataGridViewCatalog.DataSource = bindingSourceCatalog;
            loadProduct();
            addProductBinding();
            loadClassifies();
            loadCatalog();
            addCatalogBinding();
        }

        private void loadProduct()
        {
            bindingSourceProduct.DataSource = productService.getProducts();
        }

        private void loadClassifies()
        {
            comboBoxClassify2.DataSource = service.getClassifies();
            comboBoxClassify2.DisplayMember = "ClassifyName";
        }

        private void addProductBinding()
        {
            textBoxId.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "Id", true, DataSourceUpdateMode.Never));
            textBoxProductName.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "ProductName", true, DataSourceUpdateMode.Never));
            textBoxAmount.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "Amount", true, DataSourceUpdateMode.Never));
            numericUpDownPrice.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "Price", true, DataSourceUpdateMode.Never));
            textBoxDetail.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "Detail", true, DataSourceUpdateMode.Never));
            textBoxDateCreate.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "DateCreated", true, DataSourceUpdateMode.Never));

        }

        private void loadCatalog()
        {
            comboBoxCatalog.DataSource = service.getCatalogs();
            comboBoxCatalog.DisplayMember = "CatalogName";
            bindingSourceCatalog.DataSource = service.getCatalogs();
        }

        private void addCatalogBinding()
        {
            textBoxIdCatalog.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "Id", true, DataSourceUpdateMode.Never));
            textBoxCatalogName.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "CatalogName", true, DataSourceUpdateMode.Never));
            textBoxCatalogDetail.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "CatalogDetails", true, DataSourceUpdateMode.Never));
            textBoxDateCreateCatalog.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "DateCreated", true, DataSourceUpdateMode.Never));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProduct = Convert.ToInt32(textBoxId.Text);
            service.deleteProduct(idProduct);
            loadProduct();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewProduct_SelectionChanged(object sender, EventArgs e)
        {
            int r = dataGridViewProduct.CurrentCell.RowIndex + 1;

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxId.Text.Equals("0"))
            {
                int idProduct = Convert.ToInt32(textBoxId.Text);
                ClassifyDTO classify = service.getClassifyByIdProduct(idProduct);

                int index = -1;
                int i = 0;
                foreach (ClassifyDTO item in comboBoxClassify2.Items)
                {
                    if (item.Id == classify.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBoxClassify2.SelectedIndex = index;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
            int amount = Convert.ToInt32(textBoxAmount.Text);
            decimal price = numericUpDownPrice.Value;
            string detail = textBoxDetail.Text;
            int idClassify = (comboBoxClassify2.SelectedItem as ClassifyDTO).Id;
            ProductDTO product = new ProductDTO();
            product.ProductName = productName;
            product.Amount = amount;
            product.Price = price;
            product.Detail = detail;
            product.IdClassify = idClassify;
            service.createProduct(product);
            loadProduct();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int idProduct = Convert.ToInt32(textBoxId.Text);
            string productName = textBoxProductName.Text;
            int amount = Convert.ToInt32(textBoxAmount.Text);
            decimal price = numericUpDownPrice.Value;
            string detail = textBoxDetail.Text;
            int idClassify = (comboBoxClassify2.SelectedItem as ClassifyDTO).Id;
            ProductDTO product = new ProductDTO();
            product.Id = idProduct;
            product.ProductName = productName;
            product.Amount = amount;
            product.Price = price;
            product.Detail = detail;
            product.IdClassify = idClassify;
            service.editProduct(product);
            loadProduct();
        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateCatalog_Click(object sender, EventArgs e)
        {
            string catalogName = textBoxCatalogName.Text;
            string catalogDetail = textBoxCatalogDetail.Text;
            CatalogDTO catalog = new CatalogDTO();
            catalog.CatalogDetails = catalogDetail;
            catalog.CatalogName = catalogName;
            service.createCatalog(catalog);
            loadCatalog();
        }

        private void buttonDeleteCatalog_Click(object sender, EventArgs e)
        {
            int idCatalog = Convert.ToInt32(textBoxIdCatalog.Text);
            service.deleteCatalog(idCatalog);
            loadCatalog();
        }

        private void buttonEditCatalog_Click(object sender, EventArgs e)
        {
            int catalogId = Convert.ToInt32(textBoxIdCatalog.Text);
            string catalogName = textBoxCatalogName.Text;
            string catalogDetail = textBoxCatalogDetail.Text;
            CatalogDTO catalog = new CatalogDTO();
            catalog.Id = catalogId;
            catalog.CatalogDetails = catalogDetail;
            catalog.CatalogName = catalogName;
            service.editCatalog(catalog);
            loadCatalog();
        }
    }
}
