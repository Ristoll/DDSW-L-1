using System;
namespace DDSW_L_1
{
    public class MovingItemsReport
    {
        public string FileName { get; } = $"MovingReport{DateTime.Today}.txt";

        public MovingItemsReport()
        {
        }
        public void FillReport(Dictionary<string, Item> previousState)
        {
            List<Item> items = Program.GetItems();
            if (items == null || items.Count == 0) return;

            using (StreamWriter writer = new StreamWriter(FileName, true)) // Додаємо в файл
            {
                writer.WriteLine($"\n--- Зміни {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");

                Dictionary<string, Item> currentState = items.ToDictionary(item => item.Name, item => item);

                // Визначаємо зміни
                foreach (var item in currentState)
                {
                    if (previousState.ContainsKey(item.Key))
                    {
                        var previousItem = previousState[item.Key];
                        var currentItem = item.Value;

                        if (currentItem.Count > previousItem.Count)
                            writer.WriteLine($"{currentItem.Name} ({currentItem.Type}, {currentItem.Brand}) +{currentItem.Count - previousItem.Count}");
                        else if (currentItem.Count < previousItem.Count)
                            writer.WriteLine($"{currentItem.Name} ({currentItem.Type}, {currentItem.Brand}) -{previousItem.Count - currentItem.Count}");
                    }
                    else
                    {
                        writer.WriteLine($"+ {item.Value.Name} ({item.Value.Type}, {item.Value.Brand}) {item.Value.Count}");
                    }
                }

                // Видалені предмети
                foreach (var item in previousState.Keys.Except(currentState.Keys))
                {
                    var previousItem = previousState[item];
                    writer.WriteLine($"- {previousItem.Name} ({previousItem.Type}, {previousItem.Brand}) {previousItem.Count}");
                }

                previousState = new Dictionary<string, Item>(currentState); // Оновлюємо стан
            }
        }

    }
}
