using System.Text.Json;

namespace DDSW_L_1
{
    public static class DataSaver<T>
    {
        public static void SaveData(List<T> dataList)
        {
            string fileName = $"{typeof(T).Name}sData.txt";

            using FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(fs, dataList, new JsonSerializerOptions { WriteIndented = true });
        }
        public static void SaveData(List<T> dataList, string header)
        {
            string fileName = $"{header}sData.txt";

            using FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(fs, dataList, new JsonSerializerOptions { WriteIndented = true });
        }

        public static void SaveOrderData(List<T> dataList, string fileName)
        {
            string folderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Orders";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullPath = Path.Combine(folderPath, fileName);

            using FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(fs, dataList, new JsonSerializerOptions { WriteIndented = true });
        }

        public static List<T> LoadData(string name)
        {
            string fileName = $"{name}sData.txt";

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var result = JsonSerializer.Deserialize<List<T>>(fs);
                return result ?? new List<T>();
            }
        }
        public static List<T> LoadData()
        {
            string fileName = $"{typeof(T).Name}sData.txt";

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var result = JsonSerializer.Deserialize<List<T>>(fs);
                return result ?? new List<T>();
            }
        }
        public static List<List<Item>> LoadOrdersData()
        {
            string folderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Orders";
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    throw new DirectoryNotFoundException("Folder does not exist.");
                }

                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");
                List<List<Item>> allItems = new List<List<Item>>();

                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath);

                    // Тут десеріалізується саме List<Item>, не List<List<Item>>
                    List<Item> deserializedOrder = JsonSerializer.Deserialize<List<Item>>(fileContent);

                    if (deserializedOrder != null)
                    {
                        allItems.Add(deserializedOrder);
                    }
                }

                return allItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<List<Item>>();
            }
        }

        public static void LoadReportsToListBox(ListBox listBox)
        {
            string folderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Orders";

            try
            {
                // Перевіряємо, чи існує вказана папка
                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show("Folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Отримуємо всі файли в папці
                string[] filePaths = Directory.GetFiles(folderPath);

                // Очищаємо список перед додаванням нових елементів
                listBox.Items.Clear();

                foreach (string filePath in filePaths)
                {
                    // Отримуємо назву файлу
                    string fileName = Path.GetFileName(filePath);

                    // Додаємо інформацію до списку
                    listBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                // Виводимо повідомлення про помилку, якщо виникла проблема
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

