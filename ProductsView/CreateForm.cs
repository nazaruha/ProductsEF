using System;
using ProductView.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsView
{
    public partial class CreateForm : Form
    {
        private AppEFContext context { get; set; }
        public CreateForm(AppEFContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Input name");
                return;
            }
            if (numCount.Value <= 0)
            {
                MessageBox.Show("Input count > 0");
                return;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Input price > 0");
                return;
            }
            if (CreateProduct())
            {
                this.Close();
            }
        }

        private bool CreateProduct()
        {
            Product product = new Product() { Name = txtName.Text, Count = (int)numCount.Value, Price = (int)numPrice.Value };
            var findProduct = context.Products.SingleOrDefault(x => x.Name == product.Name);
            if (findProduct == null)
            {
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Product is created");
                ClearForm();
                return true;
            }
            MessageBox.Show("This product already exists. Choose another name");
            return false;
        }
        private void ClearForm()
        {
            txtName.Clear();
            numCount.Value = 0;
            numPrice.Value = 0;
        }
    }
}
