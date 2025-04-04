using System.Linq;

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
        public static void UpdateListBox(List<Item> items, ListBox listBox, bool isMain)
        {
            if (isMain)
            {
                listBox.Items.Clear();
                foreach (var item in items)
                {
                    listBox.Items.Add(item.ToString());
                }
                return;
            }

            listBox.Items.Clear();
            foreach (var item in items)
            {
                listBox.Items.Add($"{item.Name} {item.Brand} - {item.Count}");
            }
        }
        public static void OrderItem(ListBox mainListBox, ListBox orderListBox, List<Item> orderedItems, int quantity, int mainIndex)
        {
            try
            {
                
                if (mainIndex == -1)
                {
                    return;
                }

                Item selectedItem = Program.GetItems()[mainIndex];
                int selectedValue = quantity;

                // Перевірка на достатність товару на складі
                if (Program.GetCustomerItems()[mainIndex].Count < selectedValue || Program.GetCustomerItems()[mainIndex].Count == 0)
                {
                    MessageBox.Show($"There is not enough stock.\n{Program.GetCustomerItems()[mainIndex].Count} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка, чи вже є цей товар у списку замовлених
                var existingItem = orderedItems.FirstOrDefault(item => item.Name == selectedItem.Name && item.Brand == selectedItem.Brand);
                if (existingItem != null)
                {
                    // Якщо товар вже є в замовленні, збільшуємо кількість
                    existingItem.SetCount(existingItem.Count + selectedValue);

                    // Оновлюємо кількість товару на складі
                    Program.GetCustomerItems()[mainIndex].SetCount(Program.GetCustomerItems()[mainIndex].Count - selectedValue);
                    UpdateListBox(Program.GetCustomerItems(), mainListBox, true);
                    UpdateListBox(orderedItems, orderListBox, false);
                    DataSaver<Item>.SaveData(Program.GetCustomerItems(), "CustomerItem");

                    return;
                }

                // Якщо товару ще немає в замовленні, додаємо новий товар
                selectedItem.SetCount(selectedValue);
                orderedItems.Add(selectedItem);
                orderListBox.Items.Add($"{selectedItem.Name} {selectedItem.Brand} - {selectedItem.Count}");

                // Оновлюємо кількість товару на складі
                Program.GetCustomerItems()[mainIndex].SetCount(Program.GetCustomerItems()[mainIndex].Count - selectedValue);
                UpdateListBox(Program.GetCustomerItems(), mainListBox, true);
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
            UpdateListBox(Program.GetCustomerItems(), mainListBox, true);
        }


        }
}
