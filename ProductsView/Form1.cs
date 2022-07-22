using System;
using ProductView.Data;

namespace ProductsView
{
    public partial class Form1 : Form
    {
        public AppEFContext context { get; set; }
        public Form1()
        {
            InitializeComponent();
            context = new AppEFContext();
            GetProducts();
        }

        private void GetProducts()
        {
            var list = context.Products.ToList();
            dgProducts.DataSource = list;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm(context);
            createForm.ShowDialog();
            GetProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}