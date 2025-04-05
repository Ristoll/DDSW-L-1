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
        public ItemCreationalWindow()
        {
            InitializeComponent();
            MainOperationsFunc.FillComboBox(comboBox1, true);
            MainOperationsFunc.FillComboBox(comboBox2, false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemCreationalWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
