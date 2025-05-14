namespace DDSW_L_1
{
    public partial class DeliveryWindow : Form
    {
        public List<Item> DeliveryItems = new List<Item>();
        public DeliveryWindow()
        {
            InitializeComponent();
        }
        public DeliveryWindow(List<Item> deliveryItems)
        {
            InitializeComponent();
            DeliveryItems = deliveryItems;
            MainOperationsFunc.UpdateListBox(DeliveryItems, listBox1, false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ItemCreationalWindow itemCreationalWindow = new ItemCreationalWindow(DeliveryItems);
            itemCreationalWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.DeleteItem(listBox1, listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
