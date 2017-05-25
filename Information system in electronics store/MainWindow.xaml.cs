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
using System.IO;
using System.Runtime.Serialization.Json;
using System.Data.SQLite;

namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class ProductsWindow : Window
    {
       // const string FileName = "ListOfProducts.txt";
       // List<Product> _products = new List<Product>();
       // List<Country> _countries = new List<Country>();
        

       
        
        public ProductsWindow()
        {
            InitializeComponent();
            frameMainWindow.NavigationService.Navigate(Pages.LoginPage);
            try
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                SQLiteDataReader sqlite_datareader;
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New = true; Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "CREATE TABLE users (id integer primary key, username varchar(100), password varchar(100));";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO users (id, username, password) VALUES (1, 'Ben', 'QaZ12345');";
                sqlite_cmd.ExecuteNonQuery();
            }
            catch { }
        }

      /*  private void RefreshListBox()
        {
            listBoxProducts.ItemsSource = null;
            listBoxProducts.ItemsSource = _products;
        }

        public void buttonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddingProductWindow(_countries);
            if (window.ShowDialog().Value)
            {
                _products.Add(window.NewProduct);
                SaveData();
                RefreshListBox();
            }

        }
        
       

     
        // если нет товара, удаляем его из общего списка
        public void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxProducts.SelectedIndex != -1)
            {
                _products.RemoveAt(listBoxProducts.SelectedIndex);
                SaveData();
                RefreshListBox();
            }
        }

        private void listBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonRemove.IsEnabled = listBoxProducts.SelectedIndex != -1;
        }

        private void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var product in _products)
                {
                    sw.WriteLine($"{product.Type}-{product.Firm}-{product.Model}-{product.Country.Name}-{product.Quantity}");
                    //sw.WriteLine($"{product.Type}-{product.Firm}-{product.Model}-{product.Quantity}-{product.Country.Name}");
                    //sw.WriteLine($"{product.Type} - {product.Firm} - {product.Model} - {product.Quantity}");
                }
            }

           

                  
        }

        private void LoadData() // !ПРОВЕРЬ ЭТО НЕСКОЛЬКО РАЗ!
        {
            try
            {
                _products = new List<Product>();
                _countries = new List<Country>();
                //

                using (var sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split('-');
                        if (parts.Length == 5)
                        {
                            int i = 0;
                            while (i < _countries.Count && _countries[i].Name != parts[3])
                                i++;
                            Country c;
                            if (i<_countries.Count)
                            {
                                c = _countries[i];
                            }
                            else
                            {
                                c = new Country(parts[3]);
                                _countries.Add(c);
                            }
                            var product = new Product(parts[0], parts[1], parts[2], int.Parse(parts[4]));
                            product.Country = c;
                            _products.Add(product);
                            
                        }
                       
                    }
                }
            }

            catch(FileNotFoundException)
            {

                _countries.Add(new Country("Китай"));
                _countries.Add(new Country("Япония"));
                _countries.Add(new Country("США"));
                _countries.Add(new Country("Южная Корея"));
                _countries.Add(new Country("Сингапур"));
            }

            catch
            {
                MessageBox.Show("Ошибка при чтении из файла");
            }
            RefreshListBox();
        }

        //поиск в листбоксе

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = textBoxSearch.Text;
            if (text =="")
            {
                listBoxProducts.ItemsSource =_products;
            }

            else
            {
                listBoxProducts.ItemsSource = SearchProducts(text);
            }

           

        }

        public List<Product> SearchProducts (string input)
        {
            List<Product> tmp = new List<Product>();
            foreach (var item in _products )
            {
                if (input == item.InfType|| input == item.InfFirm || input == item.InfModel || input == item.InfQuant || input == item.InfCountry)
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }

        #region Json
        public void JsonSerializer()
        {
            _products = new List<Product>();
            _countries = new List<Country>();
            var window = new AddingProductWindow(_countries);
            _products.Add(window.NewProduct);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Product));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, _products);
            }
        }







         private void JSONSerialize(Product objStudent)
         {
             MemoryStream stream = new MemoryStream();
             DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Product));
             jsonSer.WriteObject(stream, objStudent);
             stream.Position = 0;
             StreamReader sr = new StreamReader(stream);
              = sr.ReadToEnd();
         }
        #endregion

        private void buttonSerialize_Click(object sender, RoutedEventArgs e)
        {
            _products = new List<Product>();
            _countries = new List<Country>();
            var window = new AddingProductWindow(_countries);
            _products.Add(window.NewProduct);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Product));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, _products);
            }
            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {

               
                /*Product newproduct = (Product)jsonFormatter.ReadObject(fs);
                foreach (var Product in newproduct)
                {
                    MessageBox.Show("Фирма: {0} --- Возраст: {1}", p.Name, p.Age);
                }*/
           // }
        //}

      /*  public void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow login = new LogInWindow();
            login.Show();
            this.Close();

        }

        private void buttonRedact_Click(object sender, RoutedEventArgs e)
        {

            var window = new AddingProductWindow(_countries);
            window.AddingProductInfo();
            if (window.ShowDialog().Value)
            {
                //_products.Add(window.NewProduct);
               // window.AddingProductInfo();
                SaveData();
                RefreshListBox();
                
                
            }

        }*/
    }
}
