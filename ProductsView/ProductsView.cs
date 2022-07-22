using System;
using ProductsView.Data;
using System.Windows.Forms;

namespace ProductsView
{
    public partial class ProductsView : Form
    {
        public ProductsView()
        {
            InitializeComponent();
            AppEFContext context = new AppEFContext();

        }

        private void GetProducts(AppEFContext con)
        {
            var list = con.Products.ToList();
        }
    }
}