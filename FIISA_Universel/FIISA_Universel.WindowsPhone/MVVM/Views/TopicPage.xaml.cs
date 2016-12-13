using DLLForumV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class TopicPage : Page
    {
        private TopicViewModel topicVM;
        public TopicPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            topicVM = (TopicViewModel)e.Parameter;
            DataContext = (TopicViewModel)e.Parameter;
            if (topicVM.HasTopic)
            {
                lstTopic.Visibility = Visibility.Visible;
                lblNotTopic.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstTopic.Visibility = Visibility.Collapsed;
                lblNotTopic.Visibility = Visibility.Visible;
            }
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        private void lstTopic_ItemClick(object sender, ItemClickEventArgs e)
        {
            //prTopic.IsActive = true;
            prTopic.Visibility = Visibility.Visible;
            Topic output = e.ClickedItem as Topic;
            MessageViewModel messageVM = new MessageViewModel(output);
            Frame.Navigate(typeof(MessagePage), messageVM);
        }
    }
}
