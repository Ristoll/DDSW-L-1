﻿using System.IO;
using System.Text.Json;

namespace DDSW_L_1
{
    public static class DataSaver<T>
    {
        public static string BrandFilePath = "BrandsData.txt";
        public static string TypeFilePath = "TypesData.txt";
        public static string ReasonsFilePath = "ReasonsData.txt";
        public static string OrderFolderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Orders";
        public static string DeliveryFolderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Deliveries";

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
        public static List<List<Item>> LoadFilesData(bool isOrder)
        {
            string folderPath;
            if (isOrder)
            {
                folderPath = OrderFolderPath;
            }
            else
            {
                folderPath = DeliveryFolderPath;
            }
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

        public static void LoadFilesToListBox(ListBox listBox, bool isOrder)
        {
            string folderPath;
            if (isOrder)
            {
                folderPath = OrderFolderPath;
            }
            else
            {
                folderPath = DeliveryFolderPath;
            }
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
        public static void DeleteFile(string fileName)
        {
            string folderPath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\Orders";
            string fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void AddFeature(string brand, bool isBrand)
        {
            string path;
            if (isBrand)
            {
                path = BrandFilePath;
            }
            else
            {
               path = TypeFilePath;
            }

            List<string> brands = File.ReadAllLines(path).ToList();

            if (!brands.Contains(brand, StringComparer.OrdinalIgnoreCase))
            {
                File.AppendAllText(path, brand + Environment.NewLine);
            }
        }
        public static List<string> LoadFeatures(EStringData stringData)
        {
            string filePath;
            try
            {
                switch (stringData)
                {
                    case EStringData.Brand:
                        filePath = BrandFilePath;
                        break;
                    case EStringData.Type:
                        filePath = TypeFilePath;
                        break;
                    case EStringData.Reason:
                        filePath = ReasonsFilePath;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(stringData), stringData, null);
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
                return new List<string>();
            }

            var lines = File.ReadAllLines(filePath)
                            .Where(line => !string.IsNullOrWhiteSpace(line))
                            .Select(line => line.Trim())
                            .ToList();

            return lines;
        }
    }
}

