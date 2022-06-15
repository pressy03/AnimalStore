using AnimalStore.DataOperators;
using AnimalStore.Models;
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
    public partial class AddOrderForm : Form
    {
        private Repository repo = new Repository();

        public AddOrderForm()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(repo.All<TypesOfProduct>()
                .Select(t => t.TypeName)
                .ToArray());

            comboBox2.Items.AddRange(repo.All<ClientCard>()
                .Select(c => $"{c.CardId}")
                .ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clientCardId = int.Parse(comboBox2.Text);
            var productName = comboBox1.Text;
            var count = int.Parse(textBox1.Text);

            Order order = new Order()
            {
                ClientCardId = clientCardId,
                DateAndTime = DateTime.Now,
                Fullfilled = false
            };

            repo.Add(order);
            repo.SaveChanges();

            OrderDetail orderDetail = new OrderDetail()
            {
                OrderedQuantity = count,
                Type = repo.All<TypesOfProduct>().FirstOrDefault(p => p.TypeName == productName)
            };

            repo.Add(orderDetail);
            repo.SaveChanges();

            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
