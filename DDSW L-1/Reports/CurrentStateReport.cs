namespace DDSW_L_1
{
    public class CurrentStateReport
    {
        public string FileName { get; } = $"CurrentStateReport{DateTime.Today}.txt";
        public void FillReport()
        {
            if (Program.GetItems() == null || Program.GetItems().Count == 0)
            {
                MessageBox.Show("List of items is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (StreamWriter writer = new StreamWriter(FileName, false)) // Перезаписуємо файл
            {
                foreach (var item in Program.GetItems())
                {
                    writer.WriteLine($"{item.Name} ({item.Brand}) - {item.Count} шт.");
                }
            }
        }
    }
}
