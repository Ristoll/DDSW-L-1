using System;
using System.Diagnostics;

namespace DDSW_L_1
{
    public partial class Access : Form
    {
        public Access()
        {
            InitializeComponent();
        }

        private void Access_Load(object sender, EventArgs e)
        {
            LoadAndDisplayUsers();
        }

        void FillTableLayoutPanel(List<User> users)
        {
            tableLayoutPanel1.Controls.Clear(); // Очищення перед додаванням нових даних
            tableLayoutPanel1.RowCount = users.Count + 1; // +1 для заголовка (опціонально)
            tableLayoutPanel1.RowStyles.Clear();

            // Додаємо заголовки (опціонально)
            string[] headers = { "No", "Access", "Surname", "Name", "TelNum", "Password" };
            for (int col = 0; col < headers.Length; col++)
            {
                Label headerLabel = new Label
                {
                    Text = headers[col],
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                tableLayoutPanel1.Controls.Add(headerLabel, col, 0);
            }

            // Додаємо дані користувачів
            int row = 1;
            foreach (var user in users)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                string[] userData = { row.ToString(), user.Access.ToString(), user.Surname, user.Name, user.TelNum, user.Password };

                for (int col = 0; col < userData.Length; col++)
                {
                    Label lbl = new Label
                    {
                        Text = userData[col],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    tableLayoutPanel1.Controls.Add(lbl, col, row);
                }

                row++;
            }
        }
        private void LoadAndDisplayUsers()
        {
            Program.GetUsers().Clear();
            Program.SetUsers(DataSaver<User>.LoadData());
            FillTableLayoutPanel(Program.GetUsers());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Крістіна\source\repos\DDSW L-1\DDSW L-1\bin\Debug\net8.0-windows\UsersData.txt";

            if (File.Exists(filePath))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "notepad.exe", // Відкриваємо у Блокноті
                    Arguments = filePath,
                    UseShellExecute = false
                };

                Process process = Process.Start(psi);

                // Запускаємо асинхронне очікування закриття файлу
                Task.Run(() =>
                {
                    process.WaitForExit(); // Чекаємо, поки користувач закриє Блокнот
                    Invoke((MethodInvoker)(() =>
                    {
                        Program.GetUsers().Clear(); // Очищаємо поточний список
                        Program.SetUsers(DataSaver<User>.LoadData()); // Завантажуємо нові дані
                        LoadAndDisplayUsers(); // Оновлюємо таблицю
                    }));
                });
            }
            else
            {
                MessageBox.Show("Файл не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
