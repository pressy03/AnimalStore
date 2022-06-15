using AnimalStore.Services;
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
    public partial class ShopInfoForm : Form
    {
        private ProductService productService = new ProductService();
        private OrderService orderService = new OrderService();
        public ShopInfoForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = productService.GetProducts();
            dataGridView2.DataSource = orderService.GetOrders();
        }

        private void ShopInfoForm_Load(object sender, EventArgs e)
        {

        }

        //Apply [Products] <ProductName> Filter
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Празни полета!");
            }
            else
            {
                dataGridView1.DataSource = productService.GetProducts(textBox1.Text);
                DayTextBox.Text = null;
            }
        }

        //Apply [Products] <Price> Filter
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Празни полета!");
            }
            else
            {
                dataGridView1.DataSource = productService
                    .GetProducts(decimal.Parse(textBox3.Text), decimal.Parse(textBox2.Text));
                textBox3.Text = null;
                textBox2.Text = null;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Apply [Orders] <Date> Filter
        private void button5_Click(object sender, EventArgs e)
        {
            string date = $"{DayTextBox.Text}.{MonthTextBox.Text}.{YearTextBox.Text}";

            dataGridView2.DataSource = orderService.GetOrders(date);
        }

        //Apply [Orders] <Price> Filter
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = orderService.GetOrders(decimal.Parse(minPriceTextBox.Text), decimal.Parse(maxPriceTextBox.Text));
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var products  = productService.GetProducts(textBox1.Text);
            dataGridView1.DataSource = products;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetProducts(decimal.Parse(textBox3.Text), decimal.Parse(textBox2.Text));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
