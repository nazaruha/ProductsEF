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
    public partial class EditForm : Form
    {
        private AppEFContext context { get; set; }
        public Product product { get; set; }

        public EditForm(int productId, AppEFContext context)
        {
            InitializeComponent();
            this.context = context;
            product = context.Products.SingleOrDefault(p => p.Id == productId);
            InitializeForm();
        }

        private void InitializeForm()
        {
            txtName.Text = product.Name;
            numCount.Value = product.Count;
            numPrice.Value = product.Price;
        }

        private void ReinitializeProduct()
        {
            product.Name = txtName.Text;
            product.Count = (int)numCount.Value;
            product.Price = (int)numPrice.Value;
        }

        private List<Product> GetProducts()
        {
            List<Product> list = context.Products.ToList();
            return list;
        }

        private void Edit()
        {
            ReinitializeProduct();
            List<Product> list = GetProducts();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == product.Id)
                {
                    list[i].Name = product.Name;
                    list[i].Count = product.Count;
                    list[i].Price = product.Price;
                    context.SaveChanges();
                    return;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            MessageBox.Show($"Product #{product.Id} has been changed");
            this.Close();
        }
    }
}
