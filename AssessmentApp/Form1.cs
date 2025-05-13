using System;
using System.Windows.Forms;
using AssessmentApp.Models;
using AssessmentApp.Repository;

namespace AssessmentApp
{
    public partial class Form1 : Form
    {
        private readonly ProductRepository _repo;
        TextBox txtCustomerName, txtProductName, txtRate, txtQuantity, txtPrice, txtMobileNo;
        public Form1()
        {
            InitializeComponent();
            SetupFormFields();
            //change the connection string accorting to your connection
            string connectionString = "Server=LAPTOP-UVACV3O5\\SQLEXPRESS;Database=CustomerProductDB;Trusted_Connection=True;TrustServerCertificate=True;";
            _repo = new ProductRepository(connectionString);
            LoadData();
        }

        private void SetupFormFields()
        {
            int labelX = 20;
            int inputX = 130;
            int y = 20;
            int gap = 35;

            // Customer Name
            Label lblCustomerName = new Label();
            lblCustomerName.Text = "Customer Name:";
            lblCustomerName.Location = new Point(labelX, y);
            this.Controls.Add(lblCustomerName);

            txtCustomerName = new TextBox();
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Location = new Point(inputX, y);
            this.Controls.Add(txtCustomerName);
            y += gap;

            // Product Name
            Label lblProductName = new Label();
            lblProductName.Text = "Product Name:";
            lblProductName.Location = new Point(labelX, y);
            this.Controls.Add(lblProductName);

            txtProductName = new TextBox();
            txtProductName.Name = "txtProductName";
            txtProductName.Location = new Point(inputX, y);
            this.Controls.Add(txtProductName);
            y += gap;

            // Rate
            Label lblRate = new Label();
            lblRate.Text = "Rate:";
            lblRate.Location = new Point(labelX, y);
            this.Controls.Add(lblRate);

            txtRate = new TextBox();
            txtRate.Name = "txtRate";
            txtRate.Location = new Point(inputX, y);
            this.Controls.Add(txtRate);
            y += gap;

            // Quantity
            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.Location = new Point(labelX, y);
            this.Controls.Add(lblQuantity);

            txtQuantity = new TextBox();
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Location = new Point(inputX, y);
            this.Controls.Add(txtQuantity);
            y += gap;

            // Price
            Label lblPrice = new Label();
            lblPrice.Text = "Price:";
            lblPrice.Location = new Point(labelX, y);
            this.Controls.Add(lblPrice);

            txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";
            txtPrice.Location = new Point(inputX, y);
            txtPrice.ReadOnly = true; // Price is calculated from Rate * Quantity
            this.Controls.Add(txtPrice);
            y += gap;

            // Mobile No
            Label lblMobileNo = new Label();
            lblMobileNo.Text = "Mobile No:";
            lblMobileNo.Location = new Point(labelX, y);
            this.Controls.Add(lblMobileNo);

            txtMobileNo = new TextBox();
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Location = new Point(inputX, y);
            this.Controls.Add(txtMobileNo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var list = _repo.GetAll();
            dataGridView1.DataSource = list;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var model = new CustomerProduct
            {
                CustomerName = txtCustomerName.Text,
                ProductName = txtProductName.Text,
                Rate = decimal.Parse(txtRate.Text),
                Quantity = decimal.Parse(txtQuantity.Text),
                MobileNo = txtMobileNo.Text
            };
            _repo.Insert(model);
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is CustomerProduct model)
            {
                _repo.Update(model);
                LoadData(); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is CustomerProduct model)
            {
                _repo.Delete(model.Id);
                LoadData();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is CustomerProduct model)
            {
                txtCustomerName.Text = model.CustomerName;
                txtProductName.Text = model.ProductName;
                txtRate.Text = model.Rate.ToString();
                txtQuantity.Text = model.Quantity.ToString();
                txtMobileNo.Text = model.MobileNo;
            }
        }
    }
}
