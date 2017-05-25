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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage(List<Country> countries)
        {
            InitializeComponent();
            comboBoxCountries.ItemsSource = countries;
        }
        List<Country> _countries = new List<Country>();
        
        //меняем свойства
        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            AddingProductPage p = new AddingProductPage(_countries);
           // p.chosenProduct = Pages.Mainpage._products[Pages.Mainpage.listBoxProducts.SelectedIndex];
            int quantity;
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
                        
            p.chosenProduct = new Product(textBoxType.Text, textBoxFirm.Text, textBoxModel.Text, quantity);
            p.chosenProduct.Country = comboBoxCountries.SelectedItem as Country;
            Pages.Mainpage._products.Remove(Pages.Mainpage._products[Pages.Mainpage.listBoxProducts.SelectedIndex]);
            Pages.Mainpage._products.Add(p.chosenProduct);   
            Pages.Mainpage.SaveData();
            Pages.Mainpage.RefreshListBox();
            NavigationService.Navigate(Pages.Mainpage);
        }
    }
}
