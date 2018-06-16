using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Information_system_in_electronics_store
{
    static class Pages
    {
        private static LoginPage _loginPage = new LoginPage();
        private static RegistrationPage _registrationPage = new RegistrationPage();
        private static MainPage _mainPage = new MainPage();
       // private static EditPage _editPage = new EditPage();
      //  private static AddingProductPage _addingproductPage = new AddingProductPage();
       

        public static LoginPage LoginPage
        {
            get {return _loginPage;}
            
        }

        public static RegistrationPage RegistrationPage
        {
            get { return _registrationPage; }
        }

       /* public static void Close()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
            
        }*/

        public static MainPage Mainpage
        {
            get { return _mainPage; }
        }

    /* public static EditPage EditPage
        {
            get { return _editPage; }
        }*/

    }
}
