namespace DDSW_L_1
{
    public partial class OrderManagementWindow : Form
    {
        List<List<Item>> ordersData = DataSaver<List<Item>>.LoadOrdersData();
        int listBox1Index;
        public OrderManagementWindow()
        {
            InitializeComponent();
            DataSaver<string>.LoadReportsToListBox(listBox1);
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
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
            Program.InvokeItemsChanged();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1Index = listBox1.SelectedIndex;
            MainOperationsFunc.LoadOrders(ordersData, listBox1, listBox2, listBox1Index);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
