using AnimalStore.Models;
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
    public partial class UserInfoForm : Form
    {
        private Client client;

        OrderService service = new OrderService();

        public UserInfoForm(Client client)
        {
            InitializeComponent();

            this.client = client;

            label4.Text = client.FirstName;
            label5.Text = client.MiddleName;
            label6.Text = client.LastName;

            label8.Text = client.PhoneNumber;
            label10.Text = client.ClientCard.Birthday.ToString();
            label12.Text = client.Email;

            label14.Text = client.Address.AddressName;
            label16.Text = client.Address.Town.TownName;

            dataGridView1.DataSource = service.GetOrders(client.ClientCardId);
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
