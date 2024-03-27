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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string connStr = "server=ND-COMPSCI;" +
                 "user=TL_S2201379;" +
                 "database=tl_s2201379_ocp;" + // Schema name here
                 "port=3306;" +
                 "password=Notre100606";
        MySqlConnection conn;
        public Login()
        {
            InitializeComponent();
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                // Use parameterized query to prevent SQL injection
                string login = "SELECT  email, password  FROM Accounts " +
                               "WHERE email = @email AND password = SHA2(@password, 256)";
                MySqlCommand cmd = new MySqlCommand(login, conn);

                // Use parameters to avoid SQL injection and improve security
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", pass.Password);
                cmd.ExecuteReader();
                conn.Close();
                MessageBox.Show("Welcome back{First Name}");
            }
            catch (Exception ex)
            { 
            MessageBox.Show(ex.Message);
                MessageBox.Show("Something went wrong, please try again");
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
            MessageBox.Show("You are currently on this page");
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.Show();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
           
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
