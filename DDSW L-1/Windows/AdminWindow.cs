namespace DDSW_L_1
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Access accessWindow = new Access();
            accessWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportsWindow reports = new ReportsWindow();
            reports.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainOperationsWindow mainOperationsWindow = new MainOperationsWindow();
            mainOperationsWindow.ShowDialog();
        }
    }
}
