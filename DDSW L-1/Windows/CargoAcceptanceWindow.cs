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
        }
    }
}
