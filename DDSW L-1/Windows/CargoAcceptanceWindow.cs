namespace DDSW_L_1
{
    public partial class CargoAcceptanceWindow : Form
    {
        public CargoAcceptanceWindow()
        {
            InitializeComponent();
        }

        private void CargoAcceptanceWindow_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.InvokeItemsChanged();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemCreationalWindow itemCreationalWindow = new ItemCreationalWindow();
            itemCreationalWindow.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //the same window as an report management
        }
    }
}
