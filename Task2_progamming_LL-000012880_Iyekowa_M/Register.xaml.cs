using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task2_progamming_LL_000012880_Iyekowa_M
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private bool ValidateInput()
        {
            // Validate first name
            if (string.IsNullOrEmpty(FN.Text))
            {
                MessageBox.Show("Please enter your first name.");
                return false;
            }

            // Validate last name
            if (string.IsNullOrEmpty(LN.Text))
            {
                MessageBox.Show("Please enter your last name.");
                return false;
            }

            // Validate email
            if (string.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Please enter your email.");
                return false;
            }
            else if (!IsValidEmail(email.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            // Validate password
            if (string.IsNullOrEmpty(pass.Password))
            {
                MessageBox.Show("Please enter your password.");
                return false;
            }
            else if (pass.Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btncreateaccount_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Input validation failed, do not proceed with registration
            }

            // If validation passes, proceed with registration
            string connStr = "YourConnectionStringHere";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Insert user details into the database
                string check = $"INSERT INTO customers (FirstName, LastName, Email, Password) VALUES (@firstName, @lastName, @email, SHA2(@password, 256))";
                MySqlCommand cmd = new MySqlCommand(check, conn);

                cmd.Parameters.AddWithValue("@firstName", FN.Text);
                cmd.Parameters.AddWithValue("@lastName", LN.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", pass.Password);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration successful. Please sign in.");
                    Login login = new Login();
                    login.Show();
                    this.Close(); // Close registration window after successful registration
                }
                else
                {
                    MessageBox.Show("Registration failed. Please check your details and try again.");
                }
            }
        }
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            this.Close();
            account.Show();
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            this.Close();
            map.Show();
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
           this.Close();
            booking.Show();
        }

        private void Vist_Click(object sender, RoutedEventArgs e)
        {
            Visiting visiting = new Visiting();
            this.Close();
            visiting.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            AboutUs aboutus = new AboutUs();
            this.Close();
            aboutus.Show();
        }

        private void Articles_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            this.Close();
            info.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        { MessageBox.Show("You are currently on this page");
           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
           
        }

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            Discount discount = new Discount();
            this.Close();
            discount.Show();
        }

        private void Message_Click(object sender, RoutedEventArgs e)
        {
            ContactUs contactUs = new ContactUs();
            this.Close();
            contactUs.Show();
        }

        private void Policy_Click(object sender, RoutedEventArgs e)
        {
            Policy policy = new Policy();
            this.Close();
            policy.Show();
        }

        private void Ts_and_Cs_Click(object sender, RoutedEventArgs e)
        {
            Terms terms = new Terms();
            this.Close();
            terms.Show();
        }

    }
}
