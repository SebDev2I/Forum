using DLLForumV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
    public sealed partial class MainPage : Page
    {
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
        private void lstRubric_ItemClick(object sender, ItemClickEventArgs e)
        {
            Rubric output = e.ClickedItem as Rubric;
            mainVM.MyRubric = output;
            mainVM.InitializeListTopic();
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
        }

        private void lstRubric_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(mainVM.MyTopic != null)
            {
                mainVM.MyTopic.IdTopic = 0;
                mainVM.InitializeListMessage();
            }
            lblNotMessage.Visibility = Visibility.Collapsed;
            cmdAddMessage.Visibility = Visibility.Collapsed;
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
        }

        private void lstTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prTopic.IsActive = true;
            prTopic.Visibility = Visibility.Visible;
            Topic output = (Topic)lstTopic.SelectedItem;
            mainVM.MyTopic = output;
            mainVM.InitializeListMessage();
            prTopic.Visibility = Visibility.Collapsed;
            prTopic.IsActive = false;
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
            cmdAddMessage.Visibility = Visibility.Visible;
        }

        private void cmdAddTopic_Click(object sender, RoutedEventArgs e)
        {
            AddTopic.Visibility = Visibility.Visible;
            cmdAddTopic.Visibility = Visibility.Collapsed;
            cmdAddMessage.Visibility = Visibility.Collapsed;
        }

        private void cmdAddMessage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmdValidTopic_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            txtDescTopic.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            str = RtfToString(str);
            mainVM.MyTopic = new Topic(int.MinValue, mainVM.MyForum.User, mainVM.MyRubric, DateTime.Now, txtTitleTopic.Text, str);
            
            if(mainVM.MyForum.User.SaveTopic(mainVM.MyTopic, mainVM.MyForum.TokenUser))
            {
                AddTopic.Visibility = Visibility.Collapsed;
                txtTitleTopic.Text = string.Empty;
                txtDescTopic.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, string.Empty);
                MessageDialog essai = new MessageDialog("Le sujet a bien été créé!");
                essai.ShowAsync();
            }
        }

        private void cmdCancelTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void essai_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            reb.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out str);
            /*Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we
                // finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                reb.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

                // Let Windows know that we're finished changing the file so the
                // other app can update the remote version of the file.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }*/
           
        }
        private string RtfToString(string rtf)
        {
            if (rtf != null)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(rtf));
            }
            return null;
        }
    }
}
