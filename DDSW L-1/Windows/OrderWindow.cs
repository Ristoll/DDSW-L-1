namespace DDSW_L_1.Windows
{
    public partial class OrderWindow : Form
    {
        User currentUser;
        private List<Item> orderedItems = new List<Item>();
        private List<Item> items;
        public OrderWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            MainOperationsFunc.LoadItems(listBox1);
        }

        private void OrderWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.OrderItems(listBox1, listBox2, orderedItems, (int)numericUpDown1.Value);
            numericUpDown1.Value = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MainOperationsFunc.SetCounterValue(listBox1, numericUpDown1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                DataSaver<Item>.SaveOrderData(orderedItems, $"{currentUser.Surname}-{currentUser.Name}-`sOrder-{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt");
                MessageBox.Show("You have finished placing your order.\nReturn to the initial window.", "The order was successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox2.Items.Clear();
                orderedItems.Clear();
            }
            else
            {
                MessageBox.Show("Your order is empty. Order something or exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
