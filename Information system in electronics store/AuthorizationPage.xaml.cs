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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        // private ProductsWindow mainWindow = (ProductsWindow)Window.GetWindow(this);
        //ProductsWindow productsWindow = new ProductsWindow();
       

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (UsernameBox.Text=="Ilya" && passwordBox.Password=="1998")
            {
                //this.mainWindow.Frame.Navigate(new OtherPage());
                //ProductsWindow productsWindow = new ProductsWindow();
                //NavigationService.Navigate(new Uri("/ProductsWindow.xaml", UriKind.Relative));
                //NavigationService.Navigate(Pages);
                //Visibility = 0; 
                Visibility = Visibility.Hidden; //этот метод скрывает только элементы на странице
                
                 
            }
        }
    }
}
