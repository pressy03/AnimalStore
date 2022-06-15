using AnimalStore.DataOperators;
using AnimalStore.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AnimalStore
{
    public partial class DeleteStockForm : Form
    {
        Repository repo = new Repository();

        public DeleteStockForm()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(repo.All<TypesOfProduct>()
                .Select(p => p.TypeName)
                .ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;

            var product = repo.All<TypesOfProduct>().FirstOrDefault(p => p.TypeName == name);

            int productId = product.TypeId;

            var orderIds = repo.All<OrderDetail>().Select(od => od.OrderId).ToList();

            foreach (var orderDetail in repo.All<OrderDetail>().ToList())
            {
                if(orderDetail.TypeId == productId)
                {
                    repo.Remove(orderDetail);
                }
            }

            repo.SaveChanges();

            foreach (var order in repo.All<Order>().ToList())
            {
                if (orderIds.Contains(order.OrderId))
                {
                    repo.Remove(order);
                }
            }

            repo.SaveChanges();

            repo.Remove(product);

            repo.SaveChanges();

            Close();
        }
    }
}
