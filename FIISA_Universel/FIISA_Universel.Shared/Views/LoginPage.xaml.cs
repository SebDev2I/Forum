using DALClientWS;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace FIISA_Universel
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        RubricViewModel rubricVM = new RubricViewModel();
        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = rubricVM;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private void cmdContinue_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), DataContext);
        }

        private void cmdRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdConnect_Click(object sender, RoutedEventArgs e)
        {
            Token token = new Token(0, txtLogin.Text, txtPwd.Password, 0);
            DALClient dal = new DALClient();
            DALWSR_Result r = dal.LoginAsync(token, CancellationToken.None);
            if(r.Data != null)
            {
                token = (Token)r.Data;
            }
            if(token.Valid != false)
            {
                Frame.Navigate(typeof(MainPage), DataContext);
            }

        }
    }
}
