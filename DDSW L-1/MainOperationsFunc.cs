using System.Windows.Forms;

namespace DDSW_L_1
{
    public class MainOperationsFunc
    {
        
        public static void LoadItems(ListBox listBox)
        {
            foreach (var item in Program.GetCustomerItems())
            {
                listBox.Items.Add(item.ToString());
            }
        }
        public static void UpdateItems(List<Item> items, ListBox listBox)
        {
            for (int i = 0; i < items.Count; i++)
            {
                listBox.Items[i] = items[i].ToString(); 
            }
        }

        public static void OrderItems(ListBox mainListBox, ListBox orderListBox, List<Item> orderedItems, int quantity)
        {
            try
            {
                int itemIndex = mainListBox.SelectedIndex;
                if(itemIndex == -1)
                {
                    return;
                }
                Item selectedItem = Program.GetItems()[itemIndex];
                int selectedValue = quantity;
                if (Program.GetCustomerItems()[itemIndex].Count < selectedValue || Program.GetCustomerItems()[itemIndex].Count == 0)
                {
                    MessageBox.Show($"There is not enough stock.\n{Program.GetCustomerItems()[itemIndex].Count} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selectedItem.SetCount(selectedValue);
                orderedItems.Add(selectedItem);
                orderListBox.Items.Add($"{selectedItem.Name} {selectedItem.Brand} - {selectedItem.Count}");
                Program.GetCustomerItems()[itemIndex].SetCount(Program.GetCustomerItems()[itemIndex].Count - selectedValue);
                UpdateItems(Program.GetCustomerItems(), mainListBox);
                DataSaver<Item>.SaveData(Program.GetCustomerItems(), "CustomerItem");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select item from left list of items to continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetCounterValue(ListBox mainListBox, NumericUpDown numericUpDown)
        {
            if (mainListBox.SelectedIndex == -1)
            {
                return;
            }
            int itemIndex = mainListBox.SelectedIndex;
            Item selectedItem = Program.GetCustomerItems()[itemIndex];
            if (selectedItem.Count == numericUpDown.Value)
            {
                numericUpDown.Value = selectedItem.Count;
            }
        }

        public static void DeleteItem(ListBox mainListBox, ListBox orderListBox, List<Item> orderedItems, int selectedIndex)
        {
            orderListBox.Items.RemoveAt(selectedIndex);
            Item itemToFind = orderedItems[selectedIndex];
            int quantity = itemToFind.Count;
            Program.GetCustomerItems().FirstOrDefault(item => item.Name == itemToFind.Name && item.Brand == itemToFind.Brand).Count += quantity;
            orderedItems.RemoveAt(selectedIndex);
            UpdateItems(Program.GetCustomerItems(), mainListBox);
        }


        }
}
