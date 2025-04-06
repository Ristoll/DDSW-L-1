using DDSW_L_1.Windows;
using System.Windows.Forms;

namespace DDSW_L_1
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static event Action<string> ItemsChanged;
        private static List<User> usersList = DataSaver<User>.LoadData() ?? new List<User>();
        private static List<Item> itemsList = DataSaver<Item>.LoadData() ?? new List<Item>();
        private static List<Item> customerItems = DataSaver<Item>.LoadData("CustomerItem") ?? new List<Item>();
        private static List<Item> previousStateItems = itemsList;
        private static MovingItemsReport report = new MovingItemsReport();
        static Program()
        {
            ItemsChanged += report.FillReport;
        }

        public static List<User> GetUsers() => usersList;
        public static List<Item> GetItems() => itemsList;
        public static List<Item> GetCustomerItems() => customerItems;
        public static List<Item> GetPreviousStateItems() => previousStateItems;
        public static void SetUsers(List<User> users) => usersList = users;
        public static void SetItems(List<Item> items) => itemsList = items;
        public static void SetPreviousStateItems()
        {
            previousStateItems = itemsList;
            DataSaver<Item>.SaveData(previousStateItems, "PreviousStateItem");
        }
        public static Item? GetDeletedItem()
        {
            List<Item> mainList = DataSaver<Item>.LoadData();
            List<Item> previousList = DataSaver<Item>.LoadData("PreviousStateItem");

            // Повертаємо перший елемент з previousList, якого немає в mainList
            foreach (var prevItem in previousList)
            {
                bool found = mainList.Any(mainItem =>
                    mainItem.Name == prevItem.Name &&
                    mainItem.Brand == prevItem.Brand &&
                    mainItem.Count == prevItem.Count &&
                    mainItem.Type == prevItem.Type);

                if (!found)
                {
                    return prevItem;
                }
            }

            return null;
        }

        public static IEnumerable<string> CompareLists()
        {
            List<Item> mainList = DataSaver<Item>.LoadData();
            List<Item> previousList = DataSaver<Item>.LoadData("PreviousStateItem");
            if (mainList.Count != previousList.Count)
            {
                yield break;
            }
            for (int i = 0; i < mainList.Count; i++)
            {
                var item1 = mainList[i];
                var item2 = previousList[i];

                if (item1.Name != item2.Name || item1.Brand != item2.Brand || item1.Count != item2.Count || item1.Type != item2.Type)
                {
                    char sign = item1.Count >= item2.Count ? '+' : '-';
                    int count = Math.Abs(item1.Count - item2.Count);
                    yield return $"{sign} {count} {item1.Name} {item1.Brand} {item1.Type}";
                }
            }
        }
        public static void InvokeItemsChanged(string reason)
        {
            ItemsChanged?.Invoke(reason);
        }

        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthorizationWindow());

            if (usersList != null) DataSaver<User>.SaveData(usersList);
            if (itemsList != null) DataSaver<Item>.SaveData(itemsList);
            if (customerItems != null) DataSaver<Item>.SaveData(customerItems, "CustomerItem");
            if (previousStateItems != null) DataSaver<Item>.SaveData(previousStateItems, "PreviousStateItem");
        }
    }
}
/*
 *
            itemsList.Add(new Item("Structural", "Brick", 100, "Wienerberger"));
            itemsList.Add(new Item("Finishing", "Plaster", 50, "Knauf"));
            itemsList.Add(new Item("Roofing", "Tile", 200, "Braas"));
            itemsList.Add(new Item("WindowsAndDoors", "Window", 10, "Veka"));
            itemsList.Add(new Item("Mixtures", "Concrete", 500, "Heidelberg"));
            itemsList.Add(new Item("Plumbing", "Pipe", 300, "Rehau"));
            itemsList.Add(new Item("Heating", "Radiator", 150, "Kermi"));
            itemsList.Add(new Item("Specialised", "Insulation", 80, "Isover"));
            itemsList.Add(new Item("Structural", "Steel", 200, "ArcelorMittal"));
            itemsList.Add(new Item("Finishing", "Paint", 60, "Dulux"));
            itemsList.Add(new Item("Roofing", "Shingle", 120, "GAF"));
            itemsList.Add(new Item("WindowsAndDoors", "Door", 15, "Hormann"));
            itemsList.Add(new Item("Mixtures", "Mortar", 400, "Cemex"));
            customerItems = itemsList;
*/