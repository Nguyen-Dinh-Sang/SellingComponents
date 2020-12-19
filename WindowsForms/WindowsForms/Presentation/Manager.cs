﻿using System;
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
        private BindingSource bindingSourceClassifyProduct = new BindingSource();
        private BindingSource bindingSourceComboProduct = new BindingSource();
        private BindingSource bindingSourceComboCatalog = new BindingSource();
        private BindingSource bindingSourceWareHouse = new BindingSource();

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
            dataGridViewClassifyProduct.DataSource = bindingSourceClassifyProduct;
            dataGridViewProductComBo.DataSource = bindingSourceComboProduct;
            dataGridViewDetailCatalog.DataSource = bindingSourceComboCatalog;
            dataGridViewWareHose.DataSource = bindingSourceWareHouse;
            loadProduct();
            addProductBinding();
            loadClassifies();
            loadCatalog();
            addCatalogBinding();
            loadCombo();
            addComboBinding();
            addClassifyBinding();
            loadWareHouse();
            addWareHouseBinding();
        }
        private void loadWareHouse()
        {
            bindingSourceWareHouse.DataSource = service.getWareHouses();
        }

        private void addWareHouseBinding()
        {
            textBoxIdWareHouse.DataBindings.Add(new Binding("Text", dataGridViewWareHose.DataSource, "Id", true, DataSourceUpdateMode.Never));
            numericUpDownAmountWareHouse.DataBindings.Add(new Binding("Text", dataGridViewWareHose.DataSource, "Amount", true, DataSourceUpdateMode.Never));
            textBoxDateCreateWareHouse.DataBindings.Add(new Binding("Text", dataGridViewWareHose.DataSource, "InputDate", true, DataSourceUpdateMode.Never));
        }

        private void loadProduct()
        {
            bindingSourceProduct.DataSource = productService.getProducts();
            comboBoxProductWareHouse.DataSource = productService.getProducts();
            comboBoxProductWareHouse.DisplayMember = "ProductName";
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
            string searchValue = textBoxSearchCombo.Text;
            if (searchValue.Equals(""))
            {
                bindingSourceCombo.DataSource = service.getCombos();
            }
            else
            {
                bindingSourceCombo.DataSource = service.getComboBySearchString(searchValue);
            }
        }

        private void comboBoxComboCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIdCombo_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxIdCombo.Text.Equals("0") && !textBoxIdCombo.Text.Equals(""))
            {
                int idCombo = Convert.ToInt32(textBoxIdCombo.Text);
                ComboDTO combo = service.getComboByID(idCombo);
                bindingSourceComboProduct.DataSource = service.getProductByIdCombo(idCombo);
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
            string searchValue = textBoxSearchClassify.Text;
            if (searchValue.Equals(""))
            {
                bindingSourceClassify.DataSource = service.getClassifies();
            }
            else
            {
                bindingSourceClassify.DataSource = service.getClassifyBySearchString(searchValue);
            }
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

        private void comboBoxClassify_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idClassify = (comboBoxClassify.SelectedItem as ClassifyDTO).Id;
            bindingSourceProduct.DataSource = service.getProductByIdClassify(idClassify);
        }

        private void buttonCreateClassify_Click(object sender, EventArgs e)
        {
            string classifyName = textBoxClassifyName.Text;
            string classifyDetail = textBoxClassifyDetail.Text;
            ClassifyDTO classify = new ClassifyDTO();
            classify.ClassifyName = classifyName;
            classify.ClassifyDetail = classifyDetail;
            service.createClassify(classify);
            loadClassifies();
        }

        private void buttonDeleteClassify_Click(object sender, EventArgs e)
        {
            int idClassify = Convert.ToInt32(textBoxIdClassify.Text);
            service.deleteClassify(idClassify);
            loadClassifies();
        }

        private void buttonEditClassify_Click(object sender, EventArgs e)
        {
            int classifyId = Convert.ToInt32(textBoxIdClassify.Text);
            string classifyName = textBoxClassifyName.Text;
            string classifyDetail = textBoxClassifyDetail.Text;
            ClassifyDTO classify = new ClassifyDTO();
            classify.Id = classifyId;
            classify.ClassifyName = classifyName;
            classify.ClassifyDetail = classifyDetail;
            service.editClassify(classify);
            loadClassifies();
        }

        private void textBoxIdClassify_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxIdClassify.Text.Equals("0") && !textBoxIdClassify.Text.Equals(""))
            {
                int idClassify = Convert.ToInt32(textBoxIdClassify.Text);
                bindingSourceClassifyProduct.DataSource = service.getProductByIdClassify(idClassify);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCatalogCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCatalog = (comboBoxCatalogCombo.SelectedItem as CatalogDTO).Id;
            bindingSourceCombo.DataSource = service.getCombosByIdCatalog(idCatalog);
        }

        private void buttonAddCombo_Click(object sender, EventArgs e)
        {
            string comboName = textBoxComboName.Text;
            decimal price = Convert.ToDecimal(textBoxPriceCombo.Text);
            string detail = textBoxComboDetail.Text;
            int idCatalog = (comboBoxComboCatalog.SelectedItem as CatalogDTO).Id;

            ComboDTO combo = new ComboDTO();
            combo.ComboName = comboName;
            combo.ComboDetails = detail;
            combo.Price = price;
            combo.IdCatalog = idCatalog;
            service.createCombo(combo);
            loadCombo();
        }

        private void buttonRemoveCombo_Click(object sender, EventArgs e)
        {
            int idCombo = Convert.ToInt32(textBoxIdCombo.Text);
            service.deleteCombo(idCombo);
            loadCombo();
        }

        private void buttonUpdateCombo_Click(object sender, EventArgs e)
        {
            int idCombo = Convert.ToInt32(textBoxIdCombo.Text);
            string comboName = textBoxComboName.Text;
            decimal price = Convert.ToDecimal(textBoxPriceCombo.Text);
            string detail = textBoxComboDetail.Text;
            int idCatalog = (comboBoxComboCatalog.SelectedItem as CatalogDTO).Id;

            ComboDTO combo = new ComboDTO();
            combo.Id = idCombo;
            combo.ComboName = comboName;
            combo.ComboDetails = detail;
            combo.Price = price;
            combo.IdCatalog = idCatalog;
            service.editCombo(combo);
            loadCombo();
        }

        private void textBoxIdCatalog_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxIdCatalog.Text.Equals("0") && !textBoxIdCatalog.Text.Equals(""))
            {
                int idCombo = Convert.ToInt32(textBoxIdCatalog.Text);
                bindingSourceComboCatalog.DataSource = service.getCombosByIdCatalog(idCombo);
            }
        }

        private void buttonSearchCatalog_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearchCatalog.Text;
            if (searchValue.Equals(""))
            {
                bindingSourceCatalog.DataSource = service.getCatalogs();
            }
            else
            {
                bindingSourceCatalog.DataSource = service.getCatalogBySearchString(searchValue);
            }
        }

        private void buttonSearchWareHouse_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearchWareHouse.Text;
            if (searchValue.Equals(""))
            {
                bindingSourceWareHouse.DataSource = service.getWareHouses();
            }
            else
            {
                bindingSourceWareHouse.DataSource = service.getWareHouseBySearchString(searchValue);
            }
        }

        private void textBoxIdWareHouse_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxIdWareHouse.Text.Equals("0") && !textBoxIdWareHouse.Text.Equals(""))
            {
                int idWareHouse = Convert.ToInt32(textBoxIdWareHouse.Text);
                WareHouseDTO wareHouseDTO = service.getWareHouseById(idWareHouse);
                
                int index = -1;
                int i = 0;
                foreach (ProductDTO item in comboBoxProductWareHouse.Items)
                {
                    if (item.Id == wareHouseDTO.IdProduct)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBoxProductWareHouse.SelectedIndex = index;
            }
        }

        private void buttonDetailCombo_Click(object sender, EventArgs e)
        {
            int idCombo = Convert.ToInt32(textBoxIdCombo.Text);
            ComboDetails comboDetail = new ComboDetails(idCombo);
            comboDetail.ShowDialog();
        }
    }
}
