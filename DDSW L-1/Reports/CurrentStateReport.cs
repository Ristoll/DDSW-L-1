using System.Diagnostics;

namespace DDSW_L_1
{
    public class CurrentStateReport : Report
    {
        private static readonly string ReportsDirectory = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Reports\CurrentStateReports";
        private string FileName = $"CurrentStateReport{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt";
        public void FillReport()
        {
            if (Program.GetItems() == null || Program.GetItems().Count == 0)
            {
                MessageBox.Show("List of items is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(ReportsDirectory))
            {
                Directory.CreateDirectory(ReportsDirectory);
            }

            string fullPath = Path.Combine(ReportsDirectory, FileName);

            using (StreamWriter writer = new StreamWriter(fullPath, false))
            {
                foreach (var item in Program.GetItems())
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        public override void OpenReport()
        {
            FillReport();
            base.OpenReport();
        }

    }
}
