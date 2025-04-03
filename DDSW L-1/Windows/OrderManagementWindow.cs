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
    public partial class OrderManagementWindow : Form
    {
        Dictionary<string, Item> currentState;
        public OrderManagementWindow()
        {
            InitializeComponent();
            currentState = Program.GetItems().ToDictionary(item => item.Name, item => item);
        }

        private void Program_ItemsChanged()
        {
            throw new NotImplementedException();
        }

        private void OrderManagementWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.InvokeItemsChanged(currentState);
        }
    }
}
