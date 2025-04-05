namespace DDSW_L_1
{
    public partial class CargoAcceptanceWindow : Form
    {
        List<List<Item>> deliveriesData = DataSaver<List<Item>>.LoadFilesData(false);
        int listBox1Index;
        public CargoAcceptanceWindow()
        {
            InitializeComponent();
            MainOperationsFunc.LoadItems(listBox3, true);
            DataSaver<string>.LoadFilesToListBox(listBox1, EStringData.Order);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void CargoAcceptanceWindow_Load(object sender, EventArgs e)
        {

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
            Program.InvokeItemsChanged();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItemCreationalWindow itemCreationalWindow = new ItemCreationalWindow();
            itemCreationalWindow.ShowDialog();
        }
    }
}
