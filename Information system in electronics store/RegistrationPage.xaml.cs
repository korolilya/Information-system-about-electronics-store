using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
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

namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        //регистрация
        string dbConnectionstring = @"Data Source=database.db;Version=3";
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

       
        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            string symb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!\"#$%&'()*+,-./::<=>?@[\\]:_{|}";
         
                // LogInWindow.CreateTable();
                SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionstring);
            try
            {
                if (textBoxPassword.Text.IndexOfAny(symb.ToCharArray())!=-1)
                {
                    if (textBoxPassword.Text.Count() >= 6)
                    {
                        sqliteCon.Open();
                        string Query = "insert into users (username, password) values('" + this.textBoxName.Text + "','" + CalculateHash(this.textBoxPassword.Text) + "')";
                        SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                        createCommand.ExecuteNonQuery();
                        MessageBox.Show("Вы успешно зарегистрированы!");
                        sqliteCon.Close();                      
                        NavigationService.Navigate(Pages.LoginPage);
                        textBoxName.Clear();
                        textBoxPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен быть не менее 6 символов");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать цифры и латинские буквы");
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
