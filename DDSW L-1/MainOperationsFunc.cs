using Mysqlx.Crud;
using System;

namespace DDSW_L_1
{
    public static class MainOperationsFunc
    {
        public static void LoadItems(ListBox listBox, bool isMain)
        {
            if (isMain)
            {
                foreach (var item in Program.GetItems())
                {
                    listBox.Items.Add(item.ToString());
                }
                return;
            }

            foreach (var item in Program.GetCustomerItems())
            {
                listBox.Items.Add(item.ToString());
            }
        }
        public static void LoadOrders(List<List<Item>> orders, ListBox customers, ListBox order, int customerIndex)
        {
            order.Items.Clear();
            if (customerIndex == -1)
            {
                return;
            }
            foreach (var item in orders[customerIndex])
            {
                order.Items.Add($"{item.Name} {item.Brand} - {item.Count}");
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

                Item selectedItem = Program.GetCustomerItems()[mainIndex];
                int selectedValue = quantity;

                if (selectedItem.Count < selectedValue || selectedItem.Count == 0)
                {
                    MessageBox.Show($"There is not enough stock.\n{selectedItem.Count} available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingItem = orderedItems.FirstOrDefault(item => item.Name == selectedItem.Name && item.Brand == selectedItem.Brand);
                if (existingItem != null)
                {
                    existingItem.SetCount(existingItem.Count + selectedValue);
                }
                else
                {
                    Item itemToOrder = new Item(selectedItem.Type, selectedItem.Name, selectedValue, selectedItem.Brand);
                    orderedItems.Add(itemToOrder);
                    orderListBox.Items.Add($"{itemToOrder.Name} {itemToOrder.Brand} - {itemToOrder.Count}");
                }

                selectedItem.SetCount(selectedItem.Count - selectedValue);

                UpdateListBox(Program.GetCustomerItems(), mainListBox, true);
                UpdateListBox(orderedItems, orderListBox, false);
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
        public static void DeleteItem(ListBox listBox, int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < listBox.Items.Count)
            {
                Program.GetItems().RemoveAt(selectedIndex);

                UpdateListBox(Program.GetItems(), listBox, true);
                DataSaver<Item>.SaveData(Program.GetItems());
                Program.InvokeItemsChanged("Item Utilization");
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public static void ApproveMoving(ListBox orders, ListBox orderItemsBox, ListBox mainListBox, List<List<Item>> items, int index, bool isOrder)
        {
            string selectedFileName = orders.Items[index]?.ToString();
            if (index == -1)
            {
                MessageBox.Show("Select order to approve", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Item> orderItems = items[index];

            foreach (var orderedItem in orderItems)
            {
                Item stockItem = Program.GetItems().FirstOrDefault(i => i.Name == orderedItem.Name && i.Brand == orderedItem.Brand);

                if (stockItem != null)
                {
                    if (isOrder)
                    {
                        if (stockItem.Count >= orderedItem.Count)
                        {
                            stockItem.Count -= orderedItem.Count;
                        }
                        else
                        {
                            MessageBox.Show($"Not enough stock for {stockItem.Name} {stockItem.Brand}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        stockItem.Count += orderedItem.Count;
                    }
                }
            }
            orders.Items.RemoveAt(index);
            items.RemoveAt(index);
            orderItemsBox.Items.Clear();
            DataSaver<Item>.DeleteFile(selectedFileName);
            DataSaver<Item>.SaveData(Program.GetItems());
            UpdateListBox(Program.GetItems(), mainListBox, true);

        }
        public static void FillComboBox(ComboBox comboBox, EStringData stringData)
        {
            List<string> items = DataSaver<string>.LoadFeatures(stringData);
            items.Add("Add New...");

            comboBox.DataSource = null;
            comboBox.DataSource = items;
        }
        public static void UtilizeSelectedItem(ListBox listBox, decimal quantity, int index)
        {
            if (index != null)
            {
                Program.GetItems()[index].SetCount(Program.GetItems()[index].Count - (int)quantity);
                Program.GetCustomerItems()[index].SetCount(Program.GetCustomerItems()[index].Count - (int)quantity);
                DataSaver<Item>.SaveData(Program.GetItems());
                UpdateListBox(Program.GetItems(), listBox, true);
            }
        }        
        public static void AddToSelectedItem(ListBox listBox, decimal quantity, int index)
        {
            if (index != null)
            {
                Program.GetItems()[index].SetCount(Program.GetItems()[index].Count + (int)quantity);
                Program.GetCustomerItems()[index].SetCount(Program.GetCustomerItems()[index].Count + (int)quantity);
                DataSaver<Item>.SaveData(Program.GetItems());
                UpdateListBox(Program.GetItems(), listBox, true);
            }
        }
    }
}


