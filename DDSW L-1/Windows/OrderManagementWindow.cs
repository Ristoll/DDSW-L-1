using Mysqlx.Crud;

namespace DDSW_L_1
{
    public partial class OrderManagementWindow : Form
    {
        List<List<Item>> ordersData = DataSaver<List<Item>>.LoadFilesData(true);
        int listBox1Index;
        public OrderManagementWindow()
        {
            InitializeComponent();
            MainOperationsFunc.LoadItems(listBox3, true);
            DataSaver<string>.LoadFilesToListBox(listBox1, true);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void OrderManagementWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.ApproveMoving(listBox1, listBox2, listBox3, ordersData, listBox1Index, true);
            MainOperationsFunc.UpdateListBox(Program.GetItems(), listBox3, true);
            Program.InvokeItemsChanged();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1Index = listBox1.SelectedIndex;
            if (listBox1Index == -1) return;
            MainOperationsFunc.LoadOrders(ordersData, listBox1, listBox2, listBox1Index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
