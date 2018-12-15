namespace SpringHeroBank.entity
{
    public class Account
    {
        private string _username;
        private string _password;
        private string _salt;
        private string _accountNumber; // số tài khoản.
        private string _identityCard; // chứng minh nhân dân.
        private decimal _balance; // số dư.
        private string _phone;
        private string _email;
        private string _fullName;
        private string _createdAt;
        private string _updatedAt;
        private int _status; // 0. inactive, 1. active, 2.locked.

        public string Salt
        {
            get => _salt;
            set => _salt = value;
        }

        public string CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public string UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        public string IdentityCard
        {
            get => _identityCard;
            set => _identityCard = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public int Status
        {
            get => _status;
            set => _status = value;
        }
    }
}