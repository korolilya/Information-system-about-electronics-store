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
        public AddingProductWindow()
        {
            InitializeComponent();
        }
        Product _newProduct;

        public Product  NewProduct
        {
            get { return _newProduct; }
          
        }

    }
}
