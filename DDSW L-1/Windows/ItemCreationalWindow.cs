using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDSW_L_1
{
    public partial class ItemCreationalWindow : Form
    {
        private int TypeIndex;
        private int BrandIndex;
        public List<Item> DeliveryList = Program.GetDeliveryItems(); 
        private User user = new User();


        public ItemCreationalWindow(User user)
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            MainOperationsFunc.FillComboBox(comboBox1, EStringData.Type);
            MainOperationsFunc.FillComboBox(comboBox2, EStringData.Brand);
            this.user = user;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeIndex = comboBox1.SelectedIndex;
            if (TypeIndex == comboBox1.Items.Count - 1)
            {
                label5.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemCreationalWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type;
            string brand;
            string name = textBox1.Text;
            int count;
            if (TypeIndex == comboBox1.Items.Count - 1)
            {
                type = textBox3.Text;
                if (!DataSaver<string>.LoadFeatures(EStringData.Type).Contains(type, StringComparer.OrdinalIgnoreCase))
                {
                    DataSaver<string>.AddFeature(type, EStringData.Type);
                }
            }
            else
            {
                type = comboBox1.SelectedItem!.ToString()!;
            }
            if (BrandIndex == comboBox2.Items.Count - 1)
            {
                brand = textBox4.Text;
                if (!DataSaver<string>.LoadFeatures(EStringData.Brand).Contains(brand, StringComparer.OrdinalIgnoreCase))
                {
                    DataSaver<string>.AddFeature(brand, EStringData.Brand);
                }
            }
            else
            {
                brand = comboBox2.SelectedItem!.ToString()!;
            }

            if (!int.TryParse(textBox2.Text, out count))
            {
                MessageBox.Show("Invalid count value.\nInput integer!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Item newItem = new Item(type, name, count, brand);
            
            DeliveryList.Add(newItem);
            Program.InvokeDeliveryItemsChanged();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandIndex = comboBox2.SelectedIndex;
            if (BrandIndex == comboBox2.Items.Count - 1)
            {
                label6.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label6.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
