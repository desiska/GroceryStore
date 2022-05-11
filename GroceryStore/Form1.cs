using Data;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class Form1 : Form
    {
        private ProductRepository productRepository;
        public Form1()
        {
            InitializeComponent();
            productRepository = new ProductRepository(new ProductContext());
        }

        private void ClearInput()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Text = "0";
            txtQuantity.Text = "0";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            decimal quantity = decimal.Parse(txtQuantity.Text);

            Product product = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity
            };

            productRepository.Add(product);

            ClearInput();
        }

        private void productsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearInput();
        }

        private void UpdateGrid()
        {
//            List<Product> products = productRepository.GetAll().ToList();
  //          products.Select(product => productsGrid.Rows.Add(product));
            productsGrid.DataSource = productRepository.GetAll().ToList();
            productsGrid.ReadOnly = true; //remove to allow data grid changes
            productsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
