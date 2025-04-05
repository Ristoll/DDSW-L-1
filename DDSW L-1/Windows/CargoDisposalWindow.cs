namespace DDSW_L_1
{
    public partial class CargoDisposalWindow : Form
    {
        public int ListBox1Index;
        public int ReasonIndex;
        public CargoDisposalWindow()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

            MainOperationsFunc.FillComboBox(comboBox1, EStringData.Reason);
            MainOperationsFunc.LoadItems(listBox1, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargoDisposalWindow_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1Index = listBox1.SelectedIndex;
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.UtilizeSelectedItem(listBox1, numericUpDown1.Value, ListBox1Index);
            Program.InvokeItemsChanged($"Utilization Because Of The Reason: {comboBox1.Items[ReasonIndex].ToString()}");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainOperationsFunc.DeleteItem(listBox1, ListBox1Index);
        }
    }
}
