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
    public partial class CargoDisposalWindow : Form
    {
        Dictionary<string, Item> currentState;
        public CargoDisposalWindow()
        {
            InitializeComponent();
            currentState = Program.GetItems().ToDictionary(item => item.Name, item => item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.InvokeItemsChanged(currentState);
        }

        private void CargoDisposalWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
