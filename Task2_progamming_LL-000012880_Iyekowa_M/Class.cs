using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_progamming_LL_000012880_Iyekowa_M
{
    internal class Class
    {
    }
    public class RegistrationManager
    {
        // Singleton instance
        private static RegistrationManager _instance;

        // User registration details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Private constructor to prevent external instantiation
        private RegistrationManager() { }

        // Method to get the singleton instance
        public static RegistrationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RegistrationManager();
                }
                return _instance;
            }
        }

        // Method to clear registration details
        public void Clear()
        {
            FirstName = null;
            LastName = null;
            Email = null;
            Password = null;
        }

        // Method to set user registration details
        public void SetDetails(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

    }
}
