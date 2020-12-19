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
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.Presentation
{
    public partial class ComboDetails : Form
    {
        private ProductService productService = ProductService.getInstance();
        private Service service = Service.getInstance();
        private BindingSource bindingSourceProductNotIn = new BindingSource();
        private BindingSource bindingSourceProductIn = new BindingSource();
        private int IdProductSend;
        private int IdProductBack;
        private int IdComboSend;
        public ComboDetails(int idCombo)
        {
            IdComboSend = idCombo;
            InitializeComponent();
            load(idCombo);
        }
        private void load(int idCombo)
        {
            dataGridViewListProductIn.DataSource = bindingSourceProductIn;
            dataGridViewListProductNotIn.DataSource = bindingSourceProductNotIn;
            loadProduct(idCombo);
        }
        private void loadProduct(int idCombo)
        {
            bindingSourceProductIn.DataSource = productService.getProductByIdCombo(idCombo);
            bindingSourceProductNotIn.DataSource = productService.getProductNotInCombo(idCombo);
        }

        private void dataGridViewListProductNotIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewListProductNotIn.Rows[e.RowIndex];
                IdProductSend = (int)row.Cells["Id"].Value;
            }
            Debug.WriteLine("voo rooif nef");
            
            Debug.WriteLine(IdProductSend);

        }

        private void buttonsendone_Click(object sender, EventArgs e)
        {
            ComboDetailDTO comboDetail = new ComboDetailDTO();
            comboDetail.IdProduct = IdProductSend;
            comboDetail.IdCombo = IdComboSend;
            service.createaComboDetail(comboDetail);
            loadProduct(IdComboSend);
        }
    }
}

