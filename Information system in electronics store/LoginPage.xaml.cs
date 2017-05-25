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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SQLite;





namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        
        public LoginPage()
        {
            InitializeComponent();
           
           
        }



        //хэширование
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        string dbConnectionstring = @"Data Source=database.db;Version=3";
        private void button_Click(object sender, RoutedEventArgs e)
        {
         //чтение из БД
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionstring);
            try
            {
                sqliteCon.Open();
                string Query = "Select * From users where username='" + this.textBoxUsername.Text + "' and password='" + CalculateHash(this.passwordBox.Password) + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;

                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MessageBox.Show("Учетные данные найдены в базе данных.");
                    Pages.Mainpage.buttonNewProduct.Visibility = Visibility.Visible;
                    Pages.Mainpage.buttonRemove.Visibility = Visibility.Visible;
                    Pages.Mainpage.buttonRedact.Visibility = Visibility.Visible;
                    
                    NavigationService.Navigate(Pages.Mainpage);
                  //проверка логина и пароля 
                }
                if (count > 1)
                {
                    MessageBox.Show("Пользователь с этими данными уже авторизован!");
                }
                if (count < 1)
                {
                    MessageBox.Show("Учетной записи не найдено!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Mainpage);
            Pages.Mainpage.buttonNewProduct.Visibility = Visibility.Hidden;
            Pages.Mainpage.buttonRemove.Visibility = Visibility.Hidden;
            Pages.Mainpage.buttonRedact.Visibility = Visibility.Hidden;
          
            

        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.RegistrationPage);


        }
    }
}
