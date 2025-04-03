using System.Windows.Forms;

namespace DDSW_L_1
{
    public class MainOperationsFunc
    {
        public static void LoadItems(List<Item> items, ListBox listBox)
        {
            foreach (var item in items)
            {
                listBox.Items.Add(item.ToString());
            }
        }
        public static void UpdateItems(List<Item> items, ListBox listBox)
        {
            listBox.Items.Clear();
            LoadItems(items, listBox);
        }
        public static void SelectItem(ListBox mainListBox, ListBox orderListBox, List<Item> mainItems, List<Item> orderedItems, int quantity)
        {
            try
            {
                int itemIndex = mainListBox.SelectedIndex;
                Item selectedItem = Program.GetItems()[itemIndex];
                int selectedValue = quantity;
                if (mainItems[itemIndex].Count < selectedValue || mainItems[itemIndex].Count == 0)
                {
                    MessageBox.Show($"There is not enough stock.\n{mainItems[itemIndex].Count} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selectedItem.SetCount(selectedValue);
                orderedItems.Add(selectedItem);
                orderListBox.Items.Add($"{selectedItem.Name} {selectedItem.Brand} - {selectedItem.Count}");
                mainItems[itemIndex].SetCount(mainItems[itemIndex].Count - selectedValue);
                UpdateItems(mainItems, mainListBox);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select item from left list of items to continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
