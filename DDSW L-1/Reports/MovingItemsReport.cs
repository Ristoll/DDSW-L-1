using System;
using System.Diagnostics;
namespace DDSW_L_1
{
    public class MovingItemsReport : Report
    {
        public string FileName { get; } = $"MovingReport.txt";
        public static List<string> GetMessages()
        {
            List<Item> mainList = DataSaver<Item>.LoadData();
            List<Item> previousList = DataSaver<Item>.LoadData("PreviousStateItem");
            List<string> messages = new List<string>();
            if (mainList.Count == previousList.Count)
            {
                bool areListsEqual = true;
                for (int i = 0; i < mainList.Count; i++)
                {
                    var item1 = mainList[i];
                    var item2 = previousList[i];

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
                if (mainList.Count > previousList.Count)
                {
                    Item item = mainList[mainList.Count - 1];
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
            return messages;
        }
        public void FillReport(string reason)
        {
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
        public override void OpenReport()
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

