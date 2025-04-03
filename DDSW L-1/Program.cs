using DDSW_L_1.Windows;

namespace DDSW_L_1
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static event Action<Dictionary<string, Item>> ItemsChanged;
        private static List<User> usersList = DataSaver<User>.LoadData() ?? new List<User>();
        private static List<Item> itemsList = DataSaver<Item>.LoadData() ?? new List<Item>();
        private static MovingItemsReport report = new MovingItemsReport();
        static Program()
        {
            ItemsChanged += report.FillReport;
        }

        public static List<User> GetUsers() => usersList;
        public static List<Item> GetItems() => itemsList;
        public static void SetUsers(List<User> users) => usersList = users;
        public static void SetItems(List<Item> items) => itemsList = items;
        public static void InvokeItemsChanged(Dictionary<string, Item> previousState)
        {
            ItemsChanged?.Invoke(previousState);
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthorizationWindow());

            if (usersList != null) DataSaver<User>.SaveData(usersList);
            if (itemsList != null) DataSaver<Item>.SaveData(itemsList);
        }
    }
}