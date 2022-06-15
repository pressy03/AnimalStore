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
    public partial class IdentifyForm : Form
    {
        private string state;
        private readonly ClientService service;

        public IdentifyForm(string state)
        {
            InitializeComponent();
            this.state = state;
            service = new ClientService();
        }

        private void IdentifyForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(state == "client")
            {
                var client = service.GetClientByNames(textBox1.Text, textBox2.Text);

                if (client == null)
                {
                    MessageBox.Show($"Клиентът {textBox1.Text} {textBox1.Text} не е намерен!");
                }
                else
                {
                    var form = new UserInfoForm(client);

                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
