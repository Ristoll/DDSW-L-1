using System.Diagnostics;

namespace DDSW_L_1
{
    public abstract class Report
    {
        string FileName { get; set; }
        public virtual void OpenReport()
        {
            try
            {
                Process.Start("notepad.exe", FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Report opening is not available: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
