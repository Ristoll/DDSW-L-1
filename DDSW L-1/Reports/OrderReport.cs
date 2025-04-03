namespace DDSW_L_1
{
    public class OrderReport
    {
        public string FileName { get; } = $"OrderReport{DateTime.Today}.txt";
        public void FillReport()
        {
            if (Program.GetItems() == null || Program.GetItems().Count == 0)
            {
                MessageBox.Show("List of items is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (StreamWriter writer = new StreamWriter(FileName, false)) // Перезаписуємо файл
            {
                writer.WriteLine("=== Remains Report ===");
                writer.WriteLine($"Date: {DateTime.UtcNow}");
                writer.WriteLine("--------------------");

                foreach (var item in Program.GetItems())
                {
                    writer.WriteLine($"{item.Name} ({item.Brand}) - {item.Count} шт.");
                }
            }
        }
    }
}
