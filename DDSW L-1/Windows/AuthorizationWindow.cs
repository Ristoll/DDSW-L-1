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

        private void ShowNeededWindow(User user)
        {
            if (user.Access == EAccess.Administrator)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (user.Access == EAccess.Guest)
            {
                OrderWindow orderWindow = new OrderWindow(GetCurrentUser());
                orderWindow.Show();
            }
        }
    }
}
