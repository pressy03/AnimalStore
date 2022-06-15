using AnimalStore.DataOperators;
using AnimalStore.Models;
using AnimalStore.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalStore
{
    public partial class AddDeleteForm : Form
    {
        private Repository repo = new Repository();
        private OrderService orderService = new OrderService();

        public AddDeleteForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = repo.All<TypesOfProduct>()
                .Include(x => x.Animal)
                .Include(x => x.TypeOfType)
                .Select(x => new
                {
                    Product = x.TypeName,
                    Animal = x.Animal.AnimalName,
                    Type = x.TypeOfType.TypeOfTypeName,
                    x.AvailableQuantity,
                    x.Price
                })
                .ToList();

            dataGridView2.DataSource = orderService.GetOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            АddStockForm form = new АddStockForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteStockForm form = new DeleteStockForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddOrderForm form = new AddOrderForm();
            form.ShowDialog();
        }
    }
}
