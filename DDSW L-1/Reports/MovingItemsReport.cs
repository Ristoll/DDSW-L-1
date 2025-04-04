using System;
namespace DDSW_L_1
{
    public class MovingItemsReport
    {
        public string FileName { get; } = $"MovingReport{DateTime.Today}.txt";

        public MovingItemsReport()
        {
        }
        public void FillReport(List<Item> previousState)
        {
            List<Item> items = Program.GetItems();
            if (items == null || items.Count == 0) return;

            using (StreamWriter writer = new StreamWriter(FileName, true)) // Додаємо в файл
            {
                writer.WriteLine($"\n--- Зміни {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");

                // Порівнюємо попередній та поточний стани
                foreach (var currentItem in items)
                {
                    // Знайдемо елемент в попередньому стані
                    var previousItem = previousState.FirstOrDefault(item => item.Name == currentItem.Name && item.Brand == currentItem.Brand);

                    if (previousItem != null)
                    {
                        // Якщо елемент існує в обох станах
                        if (currentItem.Count > previousItem.Count)
                            writer.WriteLine($"{currentItem.Name} ({currentItem.Type}, {currentItem.Brand}) +{currentItem.Count - previousItem.Count}");
                        else if (currentItem.Count < previousItem.Count)
                            writer.WriteLine($"{currentItem.Name} ({currentItem.Type}, {currentItem.Brand}) -{previousItem.Count - currentItem.Count}");
                    }
                    else
                    {
                        // Якщо елемент є в поточному стані, але немає в попередньому
                        writer.WriteLine($"+ {currentItem.Name} ({currentItem.Type}, {currentItem.Brand}) {currentItem.Count}");
                    }
                }

                // Видалені предмети (ті, що є в попередньому стані, але немає в поточному)
                foreach (var previousItem in previousState)
                {
                    var currentItem = items.FirstOrDefault(item => item.Name == previousItem.Name && item.Brand == previousItem.Brand);
                    if (currentItem == null)
                    {
                        writer.WriteLine($"- {previousItem.Name} ({previousItem.Type}, {previousItem.Brand}) {previousItem.Count}");
                    }
                }

                // Оновлюємо стан попереднього списку
                previousState.Clear();
                previousState.AddRange(items);
            }
        }
    }
}

