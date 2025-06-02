using System.Windows.Forms;

namespace DDSW_L_1
{
    public partial class DeliveryWindow : Form
    {
        User currentUser = new User();
        public List<Item> DeliveryItems = Program.GetDeliveryItems();
        public DeliveryWindow(User user)
        {
            InitializeComponent();
            MainOperationsFunc.UpdateListBox(DeliveryItems, listBox1, false);
            Program.DeliveryItemsChanged += this.UpdateWin;
        }
        private void UpdateWin()
        {
            DeliveryItems = Program.GetDeliveryItems(); // ← обов’язково перезчитати з джерела
            MainOperationsFunc.UpdateListBox(DeliveryItems, listBox1, false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ItemCreationalWindow itemCreationalWindow = new ItemCreationalWindow(currentUser);
            itemCreationalWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.DeleteItemInDeliveryBox(listBox1, listBox1.SelectedIndex);
            Program.InvokeDeliveryItemsChanged();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                DeliveryReport deliveryReport = new DeliveryReport($"{currentUser.Surname}-{currentUser.Name}-`sDelivery-{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt");
                deliveryReport.FillReport(DeliveryItems);
                MessageBox.Show("You have finished placing your delivery.\nReturn to the initial window.", "The delivery was successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.Items.Clear();
                Program.SetDeliveryItems(new());
            }
            else
            {
                MessageBox.Show("Your order is empty. Order something or exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
