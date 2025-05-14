namespace DDSW_L_1
{
    public partial class CargoApprovalWindow : Form
    {
        List<List<Item>> deliveriesData = DataSaver<List<Item>>.LoadFilesData(EStringData.Delivery);
        int listBox1Index;
        public CargoApprovalWindow()
        {
            InitializeComponent();
            MainOperationsFunc.LoadItems(listBox3, true);
            DataSaver<string>.LoadFilesToListBox(listBox1, EStringData.Delivery);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1Index = listBox1.SelectedIndex;
            if (listBox1Index == -1) return;
            MainOperationsFunc.LoadOrders(deliveriesData, listBox1, listBox2, listBox1Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.ApproveMoving(listBox1, listBox2, listBox3, deliveriesData, listBox1Index, false);
            MainOperationsFunc.UpdateListBox(Program.GetItems(), listBox3, true);
            Program.InvokeItemsChanged("New Cargo Approval");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
