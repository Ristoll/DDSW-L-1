using DDSW_L_1.Windows;

namespace DDSW_L_1
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static event Action<List<Item>> ItemsChanged;
        private static List<User> usersList = DataSaver<User>.LoadData() ?? new List<User>();
        private static List<Item> itemsList = DataSaver<Item>.LoadData() ?? new List<Item>();
        private static List<Item> customerItems = DataSaver<Item>.LoadData("CustomerItem");
        private static MovingItemsReport report = new MovingItemsReport();
        static Program()
        {
            ItemsChanged += report.FillReport;
        }

        public static List<User> GetUsers() => usersList;
        public static List<Item> GetItems() => itemsList;
        public static List<Item> GetCustomerItems() => customerItems;
        public static void SetUsers(List<User> users) => usersList = users;
        public static void SetItems(List<Item> items) => itemsList = items;
        public static void InvokeItemsChanged()
        {
            ItemsChanged?.Invoke(GetItems());
        }

        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthorizationWindow());

            if (usersList != null) DataSaver<User>.SaveData(usersList);
            if (itemsList != null) DataSaver<Item>.SaveData(itemsList);
            if (customerItems != null) DataSaver<Item>.SaveData(customerItems, "CustomerItem");
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