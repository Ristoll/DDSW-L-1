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
    }

}

