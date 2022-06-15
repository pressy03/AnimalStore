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
    public partial class АddStockForm : Form
    {
        private Repository repo = new Repository();

        public АddStockForm()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(repo.All<TypeOfType>()
                .Select(tp => tp.TypeOfTypeName)
                .ToArray());

            comboBox2.Items.AddRange(repo.All<Animal>()
                .Select(a => a.AnimalName)
                .ToArray());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int quantity = int.Parse(textBox2.Text);
            decimal price = decimal.Parse(textBox3.Text);
            string typeName = comboBox1.Text;
            string animalName = comboBox2.Text;

            TypeOfType type = repo.All<TypeOfType>()
                .FirstOrDefault(tt => tt.TypeOfTypeName == typeName);

            Animal animal = repo.All<Animal>()
                .FirstOrDefault(a => a.AnimalName == animalName);

            repo.Add(new TypesOfProduct()
            {
                TypeName = name,
                Animal = animal,
                TypeOfType = type,
                Price = price,
                AvailableQuantity = quantity
            });

            repo.SaveChanges();

            Close();
        }
    }
}
