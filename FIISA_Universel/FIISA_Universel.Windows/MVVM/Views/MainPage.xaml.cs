using DALClientWS;
using DLLAuth;
using DLLForumV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class MainPage : Page
    {
        private string _WhatDelete;
        private MainViewModel mainVM;
        public MainPage()
        {
            this.InitializeComponent();
            Application.Current.DebugSettings.EnableFrameRateCounter = false;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainVM = (MainViewModel)e.Parameter;
            DataContext = mainVM;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }


        private void lstRubric_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainVM.MyTopic != null)
            {
                mainVM.MyTopic.IdTopic = 0;
                mainVM.InitializeListMessage();
            }
            lblNotMessage.Visibility = Visibility.Collapsed;
            cmdAddMessage.Visibility = Visibility.Collapsed;
            AddTopic.Visibility = Visibility.Collapsed;
            AddMessage.Visibility = Visibility.Collapsed;
            txtTitleTopic.Text = string.Empty;
            txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            txtContentMessage.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            EditTopic.Visibility = Visibility.Collapsed;
            txtTitleTopicEdit.Text = string.Empty;
            txtDescTopicEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            lstTopic.SelectionChanged -= lstTopic_SelectionChanged;
            prRubric.IsActive = true;
            prRubric.Visibility = Visibility.Visible;
            Rubric output = (Rubric)lstRubric.SelectedItem;
            mainVM.MyRubric = output;
            mainVM.InitializeListTopic();
            prRubric.Visibility = Visibility.Collapsed;
            prRubric.IsActive = false;
            if (mainVM.HasTopic)
            {
                lstTopic.Visibility = Visibility.Visible;
                lblNotTopic.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstTopic.Visibility = Visibility.Collapsed;
                lblNotTopic.Visibility = Visibility.Visible;
            }
            cmdAddTopic.Visibility = Visibility.Visible;

            lstTopic.SelectionChanged += lstTopic_SelectionChanged;
            if (mainVM.HasTopic)
            {
                lstTopic.SelectedIndex = 0;
            }
            ShowEditDelete(lstTopic);
        }
        private void lstTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddTopic.Visibility = Visibility.Collapsed;
            AddMessage.Visibility = Visibility.Collapsed;
            txtTitleTopic.Text = string.Empty;
            //txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            //txtContentMessage.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            //txtTitleTopic.Text = string.Empty;
            //txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            //prTopic.IsActive = true;
            //prTopic.Visibility = Visibility.Visible;
            Topic output = (Topic)lstTopic.SelectedItem;
            mainVM.MyTopic = output;
            mainVM.InitializeListMessage();
            //prTopic.Visibility = Visibility.Collapsed;
            //prTopic.IsActive = false;
            if (mainVM.HasMessage)
            {
                lstMessage.Visibility = Visibility.Visible;
                lblNotMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstMessage.Visibility = Visibility.Collapsed;
                lblNotMessage.Visibility = Visibility.Visible;
            }
            //TODO binding topic (ne fonctionne pas, je suis obligé d'affecter les variables aux composants
            if (mainVM.MyTopic != null)
            {
                txtTitleTopicEdit.Text = mainVM.MyTopic.TitleTopic;
                txtDescTopicEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, mainVM.MyTopic.DescTopic);
            }

            if (EditTopic.Visibility == Visibility.Visible)
            {
                cmdAddMessage.Visibility = Visibility.Collapsed;
            }
            else cmdAddMessage.Visibility = Visibility.Visible;

            ShowEditDelete(lstTopic);
        }
        private void lstMessage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddTopic.Visibility = Visibility.Collapsed;
            AddMessage.Visibility = Visibility.Collapsed;
            txtContentMessage.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            Message output = (Message)lstMessage.SelectedItem;
            mainVM.MyMessage = output;
            /*if (mainVM.HasMessage)
            {
                lstMessage.Visibility = Visibility.Visible;
                lblNotMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstMessage.Visibility = Visibility.Collapsed;
                lblNotMessage.Visibility = Visibility.Visible;
            }*/
            if (mainVM.MyMessage != null)
            {
                txtContentMessageEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, mainVM.MyMessage.ContentMessage);
            }

            if (EditMessage.Visibility == Visibility.Visible)
            {
                cmdAddMessage.Visibility = Visibility.Collapsed;
            }
            else cmdAddMessage.Visibility = Visibility.Visible;

            ShowEditDelete(lstMessage);
        }

        private void cmdAddTopic_Click(object sender, RoutedEventArgs e)
        {
            AddTopic.Visibility = Visibility.Visible;
            cmdAddTopic.Visibility = Visibility.Collapsed;
            cmdAddMessage.Visibility = Visibility.Collapsed; 
        }

        private void cmdAddMessage_Click(object sender, RoutedEventArgs e)
        {
            AddMessage.Visibility = Visibility.Visible;
            cmdAddMessage.Visibility = Visibility.Collapsed;
            cmdAddTopic.Visibility = Visibility.Collapsed;
        }

        private void cmdValidTopic_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            txtDescTopic.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            //str = RtfToString(str);
            mainVM.MyTopic = new Topic(int.MinValue, mainVM.MyForum.User, mainVM.MyRubric, DateTime.Now, txtTitleTopic.Text, str);

            if (mainVM.MyForum.User.SaveTopic(mainVM.MyTopic, mainVM.MyForum.TokenUser))
            {
                AddTopic.Visibility = Visibility.Collapsed;
                txtTitleTopic.Text = string.Empty;
                txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
                mainVM.InitializeListTopic();
                lstTopic.SelectedIndex = 0;
                lblNotTopic.Visibility = Visibility.Collapsed;
                lstTopic.Visibility = Visibility.Visible;
                ShowEditDelete(lstTopic);
                mainVM.MessagePopup = "Le sujet a bien été créé.";
                ModalPopupError.IsOpen = true;
            }
            if (lstTopic.Visibility == Visibility.Collapsed && lblNotMessage.Visibility == Visibility.Collapsed)
            {
                cmdAddMessage.Visibility = Visibility.Visible;
            }

            cmdAddTopic.Visibility = Visibility.Visible;
        }

        private void cmdCancelTopic_Click(object sender, RoutedEventArgs e)
        {
            AddTopic.Visibility = Visibility.Collapsed;
            if (mainVM.HasTopic)
            {
                cmdAddTopic.Visibility = Visibility.Visible;
            }
            cmdAddMessage.Visibility = Visibility.Visible;
            
            txtTitleTopic.Text = string.Empty;
            txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
        }

        private void cmdValidMessage_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            txtContentMessage.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            //str = RtfToString(str);
            mainVM.MyMessage = new Message(int.MinValue, mainVM.MyTopic.IdTopic, mainVM.MyForum.User, DateTime.Now, str);

            if (mainVM.MyForum.User.SaveMessage(mainVM.MyMessage, mainVM.MyForum.TokenUser))
            {
                AddMessage.Visibility = Visibility.Collapsed;
                txtContentMessage.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
                mainVM.InitializeListMessage();
                lstMessage.Visibility = Visibility.Visible;
                lblNotMessage.Visibility = Visibility.Collapsed;
                mainVM.MessagePopup = "Le message a bien été créé.";
                ModalPopupError.IsOpen = true;
            }
            cmdAddTopic.Visibility = Visibility.Visible;
            cmdAddMessage.Visibility = Visibility.Visible;
        }

        private void cmdCancelMessage_Click(object sender, RoutedEventArgs e)
        {
            AddMessage.Visibility = Visibility.Collapsed;
            cmdAddMessage.Visibility = Visibility.Visible;
            txtContentMessage.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
            cmdAddTopic.Visibility = Visibility.Visible;
        }

        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            if (mainVM.MyForum.TokenUser == null)
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
                        if (mainVM.MyRegistered.ObjStatus.NameStatus != "Stagiaire")
                        {
                            ShowEditDelete(lstMessage);
                            ShowEditDelete(lstTopic);
                        }
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
            else
            {
                mainVM.MyForum.TokenUser = null;
                txtLogin.Text = string.Empty;
                txtPwd.Password = string.Empty;
                //mainVM.MyForum.User = null;
                mainVM.MyRegistered = null;
                mainVM.IsLogged = false;
                mainVM.InfoUser = false;
                ShowEditDelete(lstMessage);
                ShowEditDelete(lstTopic);
            }

        }

        private void cmdUser_Click(object sender, RoutedEventArgs e)
        {
            cmbStatus.SelectedIndex = mainVM.MyRegistered.ObjStatus.IdStatus - 1;
            cmbTraining.SelectedIndex = mainVM.MyRegistered.ObjTraining.IdTraining - 1;
            if (mainVM.InfoUser == true)
            {
                mainVM.MyRegistered = mainVM.MyForum.User;
                mainVM.InfoUser = false;
            }
            else
            {
                int i = -1;
                foreach (Status item in cmbStatus.Items)
                {
                    i = i + 1;
                    if (item.IdStatus == mainVM.MyRegistered.ObjStatus.IdStatus)
                    {
                        mainVM.IndexStatus = i;
                    }
                }

                i = -1;
                foreach (Training item in cmbTraining.Items)
                {
                    i = i + 1;
                    if (item.IdTraining == mainVM.MyRegistered.ObjTraining.IdTraining)
                    {
                        mainVM.IndexTraining = i;
                    }
                }
                mainVM.InfoUser = true;
            }
        }
        private void cmdSaveUser_Click(object sender, RoutedEventArgs e)
        {
            string name;
            if (txtName.Text == "")
            {
                name = null;
            }
            else name = txtName.Text;

            string firstname;
            if (txtFirstname.Text == "")
            {
                firstname = null;
            }
            else firstname = txtFirstname.Text;

            string email;
            if (txtEmail.Text == "")
            {
                email = null;
            }
            else email = txtEmail.Text;

            string login;
            if (txtLoginUser.Text == "")
            {
                login = null;
            }
            else login = txtLoginUser.Text;

            string pwd;
            if (txtPwdUser.Text == "")
            {
                pwd = null;
            }
            else pwd = txtPwdUser.Text;

            string keyword;
            if (txtKeyword.Text == "")
            {
                keyword = null;
            }
            else keyword = txtKeyword.Text;

            mainVM.MyRegistered = new Registered(mainVM.MyForum.User.IdUser, (Status)cmbStatus.SelectedItem, (Training)cmbTraining.SelectedItem, name,
                firstname, email, login, pwd, keyword);

            List<ValidationError> lstErreur = mainVM.MyRegistered.Validate();
            if (lstErreur.Count < 1)
            {
                if (mainVM.MyRegistered.SaveUser(mainVM.MyRegistered, mainVM.MyForum.TokenUser))
                {
                    mainVM.MyForum.TokenUser = null;
                    Token token = new Token(0, login, pwd, 0);

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
                            mainVM.InfoUser = false;
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
                        mainVM.MessagePopup = "Problème d'authentification, veuillez contacter l'administrateur.";
                        ModalPopupError.IsOpen = true;
                        //MessageDialog essai = new MessageDialog("Problème d'authentification, veuillez contacter l'administrateur");
                        //essai.ShowAsync();
                    }
                }

            }
            else
            {
                string str = string.Empty;
                foreach (var item in lstErreur)
                {
                    str = str + item.Information + Environment.NewLine;
                }
                mainVM.MessagePopup = str;
                ModalPopupError.IsOpen = true;
                //MessageDialog errorRegister = new MessageDialog(str);
                //errorRegister.ShowAsync();
            }
        }

        private void cmdCancelUser_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MyRegistered = mainVM.MyForum.User;
            cmbStatus.SelectedIndex = mainVM.MyRegistered.ObjStatus.IdStatus - 1;
            cmbTraining.SelectedIndex = mainVM.MyRegistered.ObjTraining.IdTraining - 1;
            mainVM.InfoUser = false;
        }

        private void cmdEditTopic_Click(object sender, RoutedEventArgs e)
        {
            int i = -1;
            int index = -1;
            foreach (Rubric item in cmbRubric.Items)
            {
                i = i + 1;
                if (item == mainVM.MyRubric)
                {
                    index = i;
                }
            }
            cmbRubric.SelectedIndex = index;
            cmdAddMessage.Visibility = Visibility.Collapsed;
            cmdAddTopic.Visibility = Visibility.Collapsed;
            EditTopic.Visibility = Visibility.Visible;

        }

        private void cmdDeleteTopic_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MessagePopup = "Veuillez confirmer la suppression de ce sujet et de ses messages.";
            ModalPopupConfirm.IsOpen = true;
            _WhatDelete = "Topic";
        }


        private void cmdValidTopicEdit_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            txtDescTopicEdit.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            mainVM.MyTopic = new Topic(mainVM.MyTopic.IdTopic, mainVM.MyTopic.ObjUser, (Rubric)cmbRubric.SelectedItem, mainVM.MyTopic.DateTopic, txtTitleTopicEdit.Text, str);
            if (mainVM.MyForum.User.SaveTopic(mainVM.MyTopic, mainVM.MyForum.TokenUser))
            {
                EditTopic.Visibility = Visibility.Collapsed;
                txtTitleTopicEdit.Text = string.Empty;
                txtDescTopicEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
                mainVM.InitializeListTopic();
                mainVM.MessagePopup = "Le sujet a bien été modifié.";
                ModalPopupError.IsOpen = true;
            }
            cmdAddMessage.Visibility = Visibility.Visible;
            cmdAddTopic.Visibility = Visibility.Visible;
        }

        private void cmdCancelTopicEdit_Click(object sender, RoutedEventArgs e)
        {
            EditTopic.Visibility = Visibility.Collapsed;
            if (mainVM.HasTopic)
            {
                cmdAddTopic.Visibility = Visibility.Visible;
            }
            cmdAddMessage.Visibility = Visibility.Visible;

            //txtTitleTopicEdit.Text = string.Empty;
            //txtDescTopicEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
        }

        private void cmdEditMessage_Click(object sender, RoutedEventArgs e)
        {
            cmdAddMessage.Visibility = Visibility.Collapsed;
            cmdAddTopic.Visibility = Visibility.Collapsed;
            EditMessage.Visibility = Visibility.Visible;
        }

        private void cmdDeleteMessage_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MessagePopup = "Veuillez confirmer la suppression de ce message.";
            ModalPopupConfirm.IsOpen = true;
            _WhatDelete = "Message";
        }

        private void cmdUnlock_Click(object sender, RoutedEventArgs e)
        {
        }

        private void cmdLock_Click(object sender, RoutedEventArgs e)
        {
        }

        private void cmbRubric_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainVM.MyTopic.ObjRubric = (Rubric)cmbRubric.SelectedItem;
        }

        private void cmdValidMessageEdit_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            txtContentMessageEdit.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            mainVM.MyMessage = new Message(mainVM.MyMessage.IdMessage, mainVM.MyTopic.IdTopic, mainVM.MyMessage.ObjUser, mainVM.MyMessage.DateMessage, str);
            if (mainVM.MyForum.User.SaveMessage(mainVM.MyMessage, mainVM.MyForum.TokenUser))
            {
                EditMessage.Visibility = Visibility.Collapsed;
                txtContentMessageEdit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
                mainVM.InitializeListMessage();
                mainVM.MessagePopup = "Le message a bien été modifié.";
                ModalPopupError.IsOpen = true;
            }
            cmdAddMessage.Visibility = Visibility.Visible;
            cmdAddTopic.Visibility = Visibility.Visible;
        }

        private void cmdCancelMessageEdit_Click(object sender, RoutedEventArgs e)
        {
            EditMessage.Visibility = Visibility.Collapsed;
            if (mainVM.HasMessage)
            {
                cmdAddMessage.Visibility = Visibility.Visible;
            }
            cmdAddTopic.Visibility = Visibility.Visible;
        }

        private void ShowEditDelete(ListView lst)
        {
            if (mainVM.IsLogged && mainVM.MyRegistered.ObjStatus.NameStatus != "Stagiaire")
            {
                if (lst.SelectedItem == null)
                    return;
                foreach (var item in lst.Items)
                {
                    foreach (var stackpanel in FindVisualChildren<StackPanel>(lst))
                    {
                        if (stackpanel.Name == "EditDelete")
                        {
                            stackpanel.Visibility = Visibility.Collapsed;
                        }
                    }
                }
                var _Container = lst.ItemContainerGenerator.ContainerFromItem(lst.SelectedItem);
                foreach (var stackpanel in FindVisualChildren<StackPanel>(_Container))
                {
                    if (stackpanel.Name == "EditDelete")
                    {
                        if (stackpanel.Visibility == Visibility.Collapsed)
                        {
                            stackpanel.Visibility = Visibility.Visible;
                        }
                        else stackpanel.Visibility = Visibility.Collapsed;

                    }
                }
            }
            else
            {
                foreach (var item in lst.Items)
                {
                    foreach (var stackpanel in FindVisualChildren<StackPanel>(lst))
                    {
                        if (stackpanel.Name == "EditDelete")
                        {
                            stackpanel.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }
        /*private void ShowEditDeleteMessage(string ctrlname)
        {
            if (mainVM.IsLogged && mainVM.MyRegistered.ObjStatus.NameStatus != "Stagiaire")
            {
                foreach (var stackpanel in FindVisualChildren<StackPanel>(lstMessage))
                {
                    if (stackpanel.Name == ctrlname)
                    {
                        stackpanel.Visibility = Visibility.Visible;
                    }
                }
            }
        }*/
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void cmdClosePopup_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MessagePopup = string.Empty;
            ModalPopupError.IsOpen = false;
        }

        private void cmdDeletePopup_Click(object sender, RoutedEventArgs e)
        {
            ModalPopupConfirm.IsOpen = false;
            if(_WhatDelete == "Topic")
            {
                if (mainVM.MyForum.User.DeleteTopic((Topic)lstTopic.SelectedItem, mainVM.MyForum.TokenUser))
                {
                    mainVM.MessagePopup = "Le sujet a bien été supprimé.";
                    ModalPopupError.IsOpen = true;
                    mainVM.InitializeListTopic();
                    lstTopic.SelectedIndex = 0;
                    cmdAddTopic.Visibility = Visibility.Visible;
                    cmdAddMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    mainVM.MessagePopup = "Une erreur s'est produite lors de la suppression";
                    ModalPopupError.IsOpen = true;
                }
            }
            

            if(_WhatDelete == "Message")
            {
                if (mainVM.MyForum.User.DeleteMessage((Message)lstMessage.SelectedItem, mainVM.MyForum.TokenUser))
                {
                    mainVM.MessagePopup = "Le message a bien été supprimé.";
                    ModalPopupError.IsOpen = true;
                    mainVM.InitializeListMessage();
                    cmdAddMessage.Visibility = Visibility.Visible;
                    if (!mainVM.HasMessage)
                    {
                        lblNotMessage.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    mainVM.MessagePopup = "Une erreur s'est produite lors de la suppression";
                    ModalPopupError.IsOpen = true;
                }
            }
                
        }

        private void cmdCancelPopup_Click(object sender, RoutedEventArgs e)
        {
            mainVM.MessagePopup = string.Empty;
            ModalPopupConfirm.IsOpen = false;
        }
    }
}
