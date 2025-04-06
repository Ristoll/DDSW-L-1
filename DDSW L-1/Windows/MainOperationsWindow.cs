namespace DDSW_L_1
{
    public partial class MainOperationsWindow : Form
    {
        public MainOperationsWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderManagementWindow managementWindow = new OrderManagementWindow();
            managementWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargoApprovalWindow cargoAcceptanceWindow = new CargoApprovalWindow();
            cargoAcceptanceWindow.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargoInventarisationWindow cargoDisposalWindow = new CargoInventarisationWindow();
            cargoDisposalWindow.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
