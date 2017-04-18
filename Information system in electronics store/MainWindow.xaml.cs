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


namespace Information_system_in_electronics_store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class ProductsWindow : Window
    {
        const string FileName = "ListOfProducts.txt";
        List<Product> _products = new List<Product>();
        public ProductsWindow()
        {
            InitializeComponent();
        }

        private void buttonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddingProductWindow();
            if (window.ShowDialog().Value)
            {
                _products.Add(window.NewProduct);
                RefreshListBox();
            }

        }
        
        //private ProductsWindow mainWindow = (ProductsWindow)Window.GetWindow();

        private void RefreshListBox ()
        {
            listBoxProducts.ItemsSource = null;
            listBoxProducts.ItemsSource = _products;
        }
        // если нет товара, удаляем его из общего списка
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxProducts.SelectedIndex != -1)
            {
                _products.RemoveAt(listBoxProducts.SelectedIndex);
                RefreshListBox();
            }
        }

        private void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var product in _products)
                {
                    //sw.WriteLine($"{product.Type} - {product.Firm} - {product.Model} - {product.Quantity} - {product.Availability}");
                }
            }
        }
    }
}
