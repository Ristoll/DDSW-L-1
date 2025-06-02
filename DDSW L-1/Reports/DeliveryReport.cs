using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DDSW_L_1
{
    public class DeliveryReport : Report
    {

        private static string folderPath = @"D:\source\repos\DDSW L-1\DDSW L-1\DDSW L-1\ReportsFiles\Deliveries\";
        public string FileName { get; set; }
        public DeliveryReport(string fileName)
        {
            FileName = fileName;
        }
        public void FillReport(List<Item> orderedItems)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullPath = Path.Combine(folderPath, FileName);

            using FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(fs, orderedItems, new JsonSerializerOptions { WriteIndented = true });
        }
        public static void OpenFolder()
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = folderPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("The folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
