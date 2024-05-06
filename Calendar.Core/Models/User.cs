using Calendar.DataAccess.Entities;

namespace FamilyCalendar.Calendar.Core.Models
{
    public class User
    {
        public User() { }
        //private User(Guid id, string firstName, string lastName, string email, UserRoleEnum role, string passwordHash, string passwordSalt, string fullName)
        private User(Guid id, string firstName, string lastName, string email, UserRoleEnum role, string passwordHash, string fullName)
        {
            UserID = id;
            FirstName = firstName;
            LastName = lastName ?? ""; // чтобы в случае, когда в конструктор не передается никакое значение для LastName, оно было установлено в пустую строку ("")
            Email = email;
            Role = role;
            PasswordHash = passwordHash;
            //PasswordSalt = passwordSalt;
            FullName = fullName;
        }

        // Пришлось добавить set`еры т.к. не прокидывались данные.
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        //public string PasswordSalt { get; }
        public string FullName { get; set; }

        //public static (User user, string Error) CreateUser(Guid id, string firstName, string lastName, string email, UserRoleEnum role, string passwordHash, string passwordSalt, string fullName)
        public static User CreateUser(Guid id, string firstName, string lastName, string email, UserRoleEnum role, string password, string fullName)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(firstName))
            {
                error = "FirstName can`t be empty or loner then 100 symbols";
            }

            if (string.IsNullOrEmpty(email))
            {
                error = "Email can`t be empty or loner then 100 symbols";
            }

            if (string.IsNullOrEmpty(role.ToString()))
            {
                error = "Role can`t be empty";
            }

            //var user = new User(id, firstName, lastName, email, role, passwordHash, passwordSalt, fullName);
            var user = new User(id, firstName, lastName, email, role, password, fullName);
            Console.WriteLine($"Ошибка = {error}"); // Куда лутше кидать эти ошибки ???
            return (user);
        }

        // Блоки кода для хэширования пароля
        //public void SetPassword(string password)
        //{
        //    PasswordSalt = GenerateSalt();
        //    PasswordHash = HashPassword(password, PasswordSalt);
        //}

        //public bool VerifyPassword(string password)
        //{
        //    string hashedPassword = HashPassword(password, PasswordSalt);
        //    return PasswordHash == hashedPassword;
        //}

        //private string GenerateSalt()
        //{
        //    byte[] saltBytes = new byte[16];
        //    using (var rng = new RNGCryptoServiceProvider())
        //    {
        //        rng.GetBytes(saltBytes);
        //    }
        //    return Convert.ToBase64String(saltBytes);
        //}

        //private string HashPassword(string password, string salt)
        //{
        //    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        //    byte[] saltBytes = Convert.FromBase64String(salt);

        //    byte[] hashedBytes;
        //    using (var sha256 = SHA256.Create())
        //    {
        //        byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];
        //        Array.Copy(passwordBytes, passwordWithSaltBytes, passwordBytes.Length);
        //        Array.Copy(saltBytes, 0, passwordWithSaltBytes, passwordBytes.Length, saltBytes.Length);

        //        hashedBytes = sha256.ComputeHash(passwordWithSaltBytes);
        //    }

        //    return Convert.ToBase64String(hashedBytes);
        //}

    }
}

