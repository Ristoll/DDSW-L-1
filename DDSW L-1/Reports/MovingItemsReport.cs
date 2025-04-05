using System;
namespace DDSW_L_1
{
    public class MovingItemsReport
    {
        public string FileName { get; } = $"MovingReport.txt";

        public MovingItemsReport()
        {
        }
        public static List<string> GetMessages()
        {
            List<string> messages = new List<string>();
            if (Program.GetItems().Count == Program.GetPreviousStateItems().Count)
            {
                bool areListsEqual = true;
                for (int i = 0; i < Program.GetItems().Count; i++)
                {
                    var item1 = Program.GetItems()[i];
                    var item2 = Program.GetPreviousStateItems()[i];

                    if (item1.Name != item2.Name || item1.Brand != item2.Brand || item1.Count != item2.Count || item1.Type != item2.Type)
                    {
                        areListsEqual = false;
                        break;
                    }
                }
                if (!areListsEqual)
                {
                    messages = Program.CompareLists().ToList();
                }
                else
                {
                    messages.Add("Nothing changed.");
                    return messages;
                }
            }
            else
            {
                if (Program.GetItems().Count > Program.GetPreviousStateItems().Count)
                {
                    Item item = Program.GetItems()[Program.GetItems().Count - 1];
                    string message = $"+ new item {item.Type} {item.Brand} {item.Name} + {item.Count}";
                    messages.Add(message);
                }
                else
                {
                    Item item = Program.GetDeletedItem()!;
                    string message = $"- deleted item {item.Type} {item.Brand} {item.Name} - {item.Count}";
                    messages.Add(message);
                }
            }
            messages.Add("Nothing changed.");
            return messages;
        }
        public void FillReport(List<Item> previousState, string reason)
        {
            List<Item> items = Program.GetItems();
            if (items == null || items.Count == 0) return;

            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine($"\n--- Changes {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");
                writer.WriteLine($"Reason: {reason}");

                List<string> messages = GetMessages();

                foreach (var message in messages)
                {
                    writer.WriteLine(message);
                }
            }
            Program.SetPreviousStateItems();
        }
    }
}

