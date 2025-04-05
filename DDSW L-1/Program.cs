using DDSW_L_1.Windows;

namespace DDSW_L_1
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static event Action<List<Item>, string> ItemsChanged;
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
            if (itemsList.Count == previousStateItems.Count)
            {
                return null;
            }
            for (int i = 0; i < itemsList.Count; i++)
            {
                var item1 = itemsList[i];
                var item2 = previousStateItems[i];

                if (item1.Name != item2.Name || item1.Brand != item2.Brand || item1.Count != item2.Count || item1.Type != item2.Type)
                {
                    return item2;
                }
            }
            return null;
        }
        public static IEnumerable<string> CompareLists()
        {
            if (itemsList.Count != previousStateItems.Count)
            {
                yield break;
            }
            for (int i = 0; i < itemsList.Count; i++)
            {
                var item1 = itemsList[i];
                var item2 = previousStateItems[i];

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
            ItemsChanged?.Invoke(GetItems(), reason);
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