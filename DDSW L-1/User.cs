using System.Text.RegularExpressions;
using System.Text.Json.Serialization;


namespace DDSW_L_1
{
    public class User
    {
        private string telNum;

        [JsonInclude]
        public EAccess Access { get; private set; }
        [JsonInclude]
        public string Surname { get; private set;}
        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public string TelNum
        {
            get => telNum;
            private set
            {
                ValidatePhoneNumber(value);
                telNum = value;
            }
        }
        [JsonInclude]
        public string Password { get; private set;}
        public User() { }
        public User(string surname, string name, string telNum, string password)
        {
            Surname = surname;
            Name = name;
            TelNum = telNum;
            Password = password;
            Access = EAccess.Guest;
        }
        public void SetAccess(EAccess access)
        {
            Access = access;
        }
        private static void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Номер телефону не може бути пустим!");
            }

            string pattern = @"^[0]{1}[0-9]{9}$";

            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                throw new ArgumentException("Некоректний формат номера телефону! Введіть у форматі 0XXXXXXXXX.");
            }
        }
        public void CheckIfPhoneNumberExists(string phoneNumber)
        {
            List<User> existingUsers = Program.GetUsers();
            if (existingUsers != null && existingUsers.Count > 0)
            {
                User? existingUser = existingUsers.FirstOrDefault(u => u.TelNum == phoneNumber);
                if (existingUser != null &&
                    (existingUser.Surname != Surname || existingUser.Name != Name || existingUser.Password != Password))
                {
                    throw new ArgumentException($"Користувач з номером {phoneNumber} вже існує!");
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is User otherUser)
            {
                return this.Surname == otherUser.Surname &&
                       this.Name == otherUser.Name &&
                       this.TelNum == otherUser.TelNum &&
                       this.Password == otherUser.Password;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Surname, Name, TelNum, Password);
        }
    }
}
