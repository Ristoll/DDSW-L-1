namespace DDSW_L_1.Windows
{
    public partial class OrderWindow : Form
    {
        User currentUser;
        private List<Item> orderedItems = new List<Item>();
        private int selectedMainIndex;
        private int selectedOrderIndex;
        public OrderWindow(User user)
        {
            InitializeComponent();
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            currentUser = user;
            MainOperationsFunc.LoadItems(listBox1, false);
        }

        private void OrderWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.OrderItem(listBox1, listBox2, orderedItems, (int)numericUpDown1.Value, selectedMainIndex);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MainOperationsFunc.SetCounterValue(listBox1, numericUpDown1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                OrderReport orderReport = new OrderReport($"{currentUser.Surname}-{currentUser.Name}-`sOrder-{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt");
                orderReport.FillReport(orderedItems);
                orderReport.OpenReport();
                MessageBox.Show("You have finished placing your order.\nReturn to the initial window.", "The order was successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox2.Items.Clear();
                orderedItems.Clear();
                DataSaver<Item>.SaveData(Program.GetCustomerItems(), "CustomerItem");
            }
            else
            {
                MessageBox.Show("Your order is empty. Order something or exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMainIndex = listBox1.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedOrderIndex != -1)
            {
                MainOperationsFunc.DeleteItem(listBox1, listBox2, orderedItems, selectedOrderIndex);
            }
            else
            {
                MessageBox.Show("Select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOrderIndex = listBox2.SelectedIndex;
        }
    }
}
