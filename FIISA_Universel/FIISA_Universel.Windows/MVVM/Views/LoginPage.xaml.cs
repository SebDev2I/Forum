using DALClientWS;
using DLLAuth;
using DLLForumV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        MainViewModel mainVM = new MainViewModel();
        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = mainVM;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        private void cmdContinue_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MyForum.TokenUser = null;
            mainVM.IsLogged = false;
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
            if (r.Data != null)
            {
                token = (Token)r.Data;
            }
            else
            {
                mainVM.MessagePopup = "Problème de connexion.";
                ModalPopupError.IsOpen = true;
                //MessageDialog essai = new MessageDialog("Problème de connexion");
                //essai.ShowAsync();
            }
            if (token.Valid != false)
            {
                mainVM.MyForum.TokenUser = token;
                mainVM.MyForum.User = mainVM.MyForum.User.GetInfoUser(token.IdUser);
                if (mainVM.MyForum.User != null)
                {
                    mainVM.MyRegistered = mainVM.MyForum.User;
                    mainVM.IsLogged = true;
                    Frame.Navigate(typeof(MainPage), DataContext);
                }
                else
                {
                    mainVM.MessagePopup = "Problème de connexion.";
                    ModalPopupError.IsOpen = true;
                    //MessageDialog essai = new MessageDialog("Problème de connexion");
                    //essai.ShowAsync();
                }
            }
            else
            {
                mainVM.MyForum.TokenUser = null;
                mainVM.IsLogged = false;
                mainVM.MessagePopup = "Login ou mot de passe incorrect.";
                ModalPopupError.IsOpen = true;
                //MessageDialog essai = new MessageDialog("Login ou mot de passe incorrect");
                //essai.ShowAsync();
            }

        }

        private void cmdClosePopup_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MessagePopup = string.Empty;
            ModalPopupError.IsOpen = false;
        }
    }
}
