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
        private BindingSource bindingSourceCombo = new BindingSource();
        private BindingSource bindingSourceClassify = new BindingSource();

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
            dataGridViewCombo.DataSource = bindingSourceCombo;
            dataGridViewClassify.DataSource = bindingSourceClassify;
            loadProduct();
            addProductBinding();
            loadClassifies();
            loadCatalog();
            addCatalogBinding();
            loadCombo();
            addComboBinding();
            addClassifyBinding();
        }

        private void loadProduct()
        {
            bindingSourceProduct.DataSource = productService.getProducts();
        }

        private void loadClassifies()
        {
            comboBoxClassify2.DataSource = service.getClassifies();
            comboBoxClassify2.DisplayMember = "ClassifyName";
            bindingSourceClassify.DataSource = service.getClassifies();
            comboBoxClassify.DataSource = service.getClassifies();
            comboBoxClassify.DisplayMember = "ClassifyName";
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
            comboBoxCatalogCombo.DataSource = service.getCatalogs();
            comboBoxCatalogCombo.DisplayMember = "CatalogName";
            comboBoxComboCatalog.DataSource = service.getCatalogs();
            comboBoxComboCatalog.DisplayMember = "CatalogName";
        }

        private void addCatalogBinding()
        {
            textBoxIdCatalog.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "Id", true, DataSourceUpdateMode.Never));
            textBoxCatalogName.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "CatalogName", true, DataSourceUpdateMode.Never));
            textBoxCatalogDetail.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "CatalogDetails", true, DataSourceUpdateMode.Never));
            textBoxDateCreateCatalog.DataBindings.Add(new Binding("Text", dataGridViewCatalog.DataSource, "DateCreated", true, DataSourceUpdateMode.Never));
        }

        private void loadCombo()
        {
            bindingSourceCombo.DataSource = service.getCombos();
            comboBoxComBo.DataSource = service.getCombos();
            comboBoxComBo.DisplayMember = "ComboName";
        }

        private void addComboBinding()
        {
            textBoxIdCombo.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "Id", true, DataSourceUpdateMode.Never));
            textBoxComboName.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "ComboName", true, DataSourceUpdateMode.Never));
            textBoxComboDetail.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "ComboDetails", true, DataSourceUpdateMode.Never));
            textBoxDateCreateCombo.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "DateCreated", true, DataSourceUpdateMode.Never));
            textBoxPriceCombo.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "Price", true, DataSourceUpdateMode.Never));
            textBoxTotalCostCombo.DataBindings.Add(new Binding("Text", dataGridViewCombo.DataSource, "TotalCost", true, DataSourceUpdateMode.Never));
        }

        private void addClassifyBinding()
        {
            textBoxIdClassify.DataBindings.Add(new Binding("Text", dataGridViewClassify.DataSource, "Id", true, DataSourceUpdateMode.Never));
            textBoxClassifyName.DataBindings.Add(new Binding("Text", dataGridViewClassify.DataSource, "ClassifyName", true, DataSourceUpdateMode.Never));
            textBoxClassifyDetail.DataBindings.Add(new Binding("Text", dataGridViewClassify.DataSource, "ClassifyDetail", true, DataSourceUpdateMode.Never));
            textBoxDateCreateClassify.DataBindings.Add(new Binding("Text", dataGridViewClassify.DataSource, "DateCreated", true, DataSourceUpdateMode.Never));
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
            string searchValue = textBoxSearch.Text;
            if (searchValue.Equals(""))
            {
                bindingSourceProduct.DataSource = productService.getProducts();
            } else
            {
                bindingSourceProduct.DataSource = service.getProductBySearchString(searchValue);
            }
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewProduct_SelectionChanged(object sender, EventArgs e)
        {
            //int r = dataGridViewProduct.CurrentCell.RowIndex + 1;
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxId.Text.Equals("0") && !textBoxId.Text.Equals(""))
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

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSearchCombo_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxComboCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIdCombo_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxIdCombo.Text.Equals("0"))
            {
                int idCombo = Convert.ToInt32(textBoxIdCombo.Text);
                ComboDTO combo = service.getComboByID(idCombo);

                int index = -1;
                int i = 0;
                foreach (CatalogDTO item in comboBoxComboCatalog.Items)
                {
                    if (item.Id == combo.IdCatalog)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBoxComboCatalog.SelectedIndex = index;
            }
        }

        private void buttonSearchClassify_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCatalog = (comboBoxCatalog.SelectedItem as CatalogDTO).Id;
            bindingSourceProduct.DataSource = service.getProductsByIdCatalog(idCatalog);
        }

        private void comboBoxComBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCombo = (comboBoxComBo.SelectedItem as ComboDTO).Id;
            bindingSourceProduct.DataSource = service.getProductByIdCombo(idCombo);
        }

        private void comboBoxCatalog_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
