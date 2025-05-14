using Microsoft.VisualBasic.ApplicationServices;

namespace DDSW_L_1.Windows
{
    public partial class AuthorizationWindow : Form
    {
        User existingUser;
        public User GetCurrentUser()
        {
            return existingUser;
        }
        public AuthorizationWindow()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void AuthorizationWindow_Load(object sender, EventArgs e)
        {
        }

        private void authorize_btn_Click(object sender, EventArgs e)
        {
            try
            {
                User newUser = new User(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                existingUser = Program.GetUsers().FirstOrDefault(user => user.Equals(newUser));

                if (existingUser != null)
                {
                    ShowNeededWindow(existingUser);
                }
                else
                {
                    newUser.CheckIfPhoneNumberExists(textBox3.Text.Trim());

                    if (comboBox1.SelectedIndex == 0)
                    {
                        newUser.SetAccess(EAccess.Provider);
                    }
                    Program.GetUsers().Add(newUser);
                    DataSaver<User>.SaveData(Program.GetUsers());
                    ShowNeededWindow(newUser);

                    label3.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (ArgumentException ex)
            {
                label3.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowNeededWindow(User user)
        {
            switch (user.Access)
            {
                case EAccess.Administrator:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    break;
                case EAccess.Guest:
                    OrderWindow orderWindow = new OrderWindow(user);
                    orderWindow.Show();
                    break;
                case EAccess.Provider:
                    DeliveryWindow deliveryWindow = new DeliveryWindow();
                    deliveryWindow.Show();
                    break;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
