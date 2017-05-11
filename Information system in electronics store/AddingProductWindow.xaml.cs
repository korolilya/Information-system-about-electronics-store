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

namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для AddingProductWindow.xaml
    /// </summary>
    public partial class AddingProductWindow : Window
    {
        public AddingProductWindow(List<Country> countries)
        {
            InitializeComponent();
            comboBoxCountries.ItemsSource = countries;
        }
        Product _newProduct;

        public Product  NewProduct
        {
            get { return _newProduct; }
          
        }
       

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            
            
           if (string.IsNullOrWhiteSpace(textBoxType.Text))
            {
                MessageBox.Show("Укажите тип товара");
                textBoxType.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFirm.Text))
            {
                MessageBox.Show("Укажите фирму");
                textBoxFirm.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxModel.Text))
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

            if (quantity<0 || quantity == 0)
            {
                MessageBox.Show("Укажите количество товара (впишите целое ПОЛОЖИТЕЛЬНОЕ число)");
                textBoxQuantity.Focus();
                return;
            }

            if(comboBoxCountries.SelectedItem == null)
            {
                MessageBox.Show("Выберете страну-производителя");
                comboBoxCountries.Focus();
                return;
            }
            
            _newProduct = new Product(textBoxType.Text, textBoxFirm.Text, textBoxModel.Text, quantity);
            _newProduct.Country = comboBoxCountries.SelectedItem as Country;
            DialogResult = true;
        }
    }
}
