using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;

namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
            RefreshListBox();
            //добавляем страны
            _countries.Add(new Country("Китай"));
            _countries.Add(new Country("Япония"));
            _countries.Add(new Country("США"));
            _countries.Add(new Country("Южная Корея"));
            _countries.Add(new Country("Сингапур"));
        }

        const string FileName = "ListOfProducts.txt";
        public List<Product> _products = new List<Product>();
        List<Country> _countries = new List<Country>();







        public void RefreshListBox()
        {
            listBoxProducts.ItemsSource = null;
            listBoxProducts.ItemsSource = _products;
        }

        public void buttonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddingProductPage(_countries);
            NavigationService.Navigate(window);
        }




        // удаление 
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

        public void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var product in _products)
                {
                    sw.WriteLine($"{product.Type}-{product.Firm}-{product.Model}-{product.Country.Name}-{product.Quantity}");
                   
                }
            }




        }

        private void LoadData() 
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
                            if (i < _countries.Count)
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


            catch (FileNotFoundException)
            {

                /*_countries.Add(new Country("Китай"));
                _countries.Add(new Country("Япония"));
                _countries.Add(new Country("США"));
                _countries.Add(new Country("Южная Корея"));
                _countries.Add(new Country("Сингапур"));*/
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
            if (text == "")
            {
                listBoxProducts.ItemsSource = _products;
            }

            else
            {
                listBoxProducts.ItemsSource = SearchProducts(text);
            }



        }

        public List<Product> SearchProducts(string input)
        {
            List<Product> tmp = new List<Product>();
            foreach (var item in _products)
            {
                if (input == item.InfType || input == item.InfFirm || input == item.InfModel || input == item.InfQuant || input == item.InfCountry)
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }

        #region Json
        /*  public void JsonSerializer()
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
          }*/







        /* private void JSONSerialize(Product objStudent)
         {
             MemoryStream stream = new MemoryStream();
             DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Product));
             jsonSer.WriteObject(stream, objStudent);
             stream.Position = 0;
             StreamReader sr = new StreamReader(stream);
              = sr.ReadToEnd();
         }*/
        #endregion

        private void buttonSerialize_Click(object sender, RoutedEventArgs e)
        {
            /* _products = new List<Product>();
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
                 }
             }*/
        }

        public void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            //LogInWindow login = new LogInWindow();
            //login.Show();
            // this.Close();
            NavigationService.Navigate(Pages.LoginPage);
        }

        private void buttonRedact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddingProductPage p = new AddingProductPage(_countries);
                p.chosenProduct = Pages.Mainpage._products[Pages.Mainpage.listBoxProducts.SelectedIndex];
                EditPage edit = new EditPage(_countries);

                foreach (var product in Pages.Mainpage._products)
                {

                    //sw.WriteLine($"{product.Type}-{product.Firm}-{product.Model}-{product.Country.Name}-{product.Quantity}");
                    edit.textBoxFirm.Text = product.Firm;
                    edit.textBoxModel.Text = product.Model;
                    edit.textBoxQuantity.Text = Convert.ToString(product.Quantity);
                    edit.textBoxType.Text = product.Type;



                }

                NavigationService.Navigate(edit);
            }
            catch
            {
                MessageBox.Show("Ничего не выбрано!");
            }

        }
    }

}


