namespace DDSW_L_1
{
    public partial class CargoDisposalWindow : Form
    {
        int listBox1Index;
        public CargoDisposalWindow()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            MainOperationsFunc.LoadItems(listBox1, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void CargoDisposalWindow_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1Index = listBox1.SelectedIndex;
        }
    }
}
