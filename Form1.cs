using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            { 
                Name = TbxName.Text,
                UnitPrice = Convert.ToDecimal(TbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(TbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Added!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TbxNameUpd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TbxUnitpriceUpd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            TbxStockUpdt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = TbxNameUpd.Text,
                UnitPrice = Convert.ToDecimal(TbxUnitpriceUpd.Text),
                StockAmount = Convert.ToInt32(TbxStockUpdt.Text)
            });
            LoadProducts();
            MessageBox.Show("Updated");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product

            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted");
        }
    }
}

