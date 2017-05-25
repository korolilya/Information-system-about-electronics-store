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

namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для AddingProductPage.xaml
    /// </summary>
    public partial class AddingProductPage : Page
    {
        public AddingProductPage(List<Country> countries)
        {
            InitializeComponent();
            comboBoxCountries.ItemsSource = countries;
        }

        // List<Product> _products = new List<Product>();
        //List<Country> _countries = new List<Country>();


        public Product chosenProduct;

        Product _newProduct;

        public Product NewProduct
        {
            get { return _newProduct; }

        }

       
       
        
        //добавляем товар

        public void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            //data = false;
            double a;
            if (string.IsNullOrWhiteSpace(textBoxType.Text)||( double.TryParse(textBoxType.Text, out a)==true) )
            {
                MessageBox.Show("Укажите тип товара (введите слово)");
                textBoxType.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFirm.Text) || (double.TryParse(textBoxFirm.Text, out a) == true))
            {
                MessageBox.Show("Укажите фирму");
                textBoxFirm.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxModel.Text)|| (double.TryParse(textBoxModel.Text, out a) == true))
            {
                MessageBox.Show("Укажите модель товара");
                textBoxModel.Focus();
                return;
            }

            if (!int.TryParse(textBoxQuantity.Text, out quantity))
            {
                MessageBox.Show("Укажите количество товара (впишите целое число)");
                textBoxQuantity.Focus();
                return;
            }

            if (quantity < 0 || quantity == 0)
            {
                MessageBox.Show("Укажите количество товара (впишите целое ПОЛОЖИТЕЛЬНОЕ число)");
                textBoxQuantity.Focus();
                return;
            }

            if (comboBoxCountries.SelectedItem == null)
            {
                MessageBox.Show("Выберете страну-производителя");
                comboBoxCountries.Focus();
                return;
            }

            MessageBoxResult confirm = MessageBox.Show("Добавить товар?", "Подтвердите добавление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.OK)
            {
                _newProduct = new Product(textBoxType.Text, textBoxFirm.Text, textBoxModel.Text, quantity);
                _newProduct.Country = comboBoxCountries.SelectedItem as Country;
                // MainPage mp = new MainPage();
                Pages.Mainpage._products.Add(_newProduct);
               // mp._products.Add(_newProduct);
                NavigationService.Navigate(Pages.Mainpage);
                Pages.Mainpage.RefreshListBox();
                Pages.Mainpage.SaveData();
            }
            else
            {
                NavigationService.Navigate(this);
            }
           
           

        }

       
      
    }
}

