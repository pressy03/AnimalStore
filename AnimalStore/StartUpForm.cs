using AnimalStore.DataOperators;
using AnimalStore.Models;
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
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IdentifyForm form = new IdentifyForm("client");
            form.Text = "Kлиент";
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShopInfoForm form = new ShopInfoForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDeleteForm form = new AddDeleteForm();
            form.ShowDialog();
        }
    }
}
