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

        private int GetSelectedProductId()
        {
            if (dgProducts.SelectedRows.Count != 1)
                return -1;
            int rowIndex = dgProducts.SelectedRows[0].Index;
            int id = int.Parse(dgProducts[0, rowIndex].Value.ToString());
            return id;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm(context);
            createForm.ShowDialog();
            GetProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int productId = GetSelectedProductId();
            if (productId == -1) return;
            EditForm editForm = new EditForm(productId, context);
            editForm.ShowDialog();
            GetProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = GetSelectedProductId();
            if (productId == -1) return;
            var product = context.Products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
                GetProducts();
            }
        }
    }
}