namespace DDSW_L_1
{
    public partial class ReportsWindow : Form
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CurrentStateReport currentStateReport = new CurrentStateReport();
            currentStateReport.OpenReport();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MovingItemsReport movingItemsReport = new MovingItemsReport();
            movingItemsReport.OpenReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderReport.OpenFolder();
        }
    }
}
