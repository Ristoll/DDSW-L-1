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
    public partial class CargoAcceptanceWindow : Form
    {
        Dictionary<string, Item> currentState;
        public CargoAcceptanceWindow()
        {
            InitializeComponent();
            currentState = Program.GetItems().ToDictionary(item => item.Name, item => item);
        }

        private void CargoAcceptanceWindow_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.InvokeItemsChanged(currentState);
        }
    }
}
