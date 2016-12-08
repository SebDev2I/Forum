using DLLForumV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class MainPage : Page
    {
        private static MainViewModel m = new MainViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            lstMessage.Visibility = Visibility.Collapsed;
            DataContext = m;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
        private void cmdHome_Click(object sender, RoutedEventArgs e)
        {
            lstRubric.Visibility = Visibility.Visible;
            lstTopic.Visibility = Visibility.Visible;
            lstMessage.Visibility = Visibility.Collapsed;
            lstRubric.SelectionChanged -= lstRubric_SelectionChanged;
            lstTopic.SelectionChanged -= lstTopic_SelectionChanged;
            lstMessage.SelectionChanged -= lstMessage_SelectionChanged;
            m.InitializeList();
            lstRubric.SelectionChanged += lstRubric_SelectionChanged;
            lstRubric.SelectionChanged += lstTopic_SelectionChanged;
            lstMessage.SelectionChanged += lstMessage_SelectionChanged;

            Frame.Navigate(typeof(MessagePage));

        }

        private void lstRubric_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstTopic.SelectionChanged -= lstTopic_SelectionChanged;
            Rubric item = (Rubric)lstRubric.SelectedItems[0];
            m.Messages.Clear();
            m.UpdateListTopic(item.IdRubric);
            lstTopic.SelectionChanged += lstTopic_SelectionChanged;
        }

        private void lstTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstRubric.SelectionChanged -= lstRubric_SelectionChanged;
            Topic item = (Topic)lstTopic.SelectedItems[0];
            m.UpdateListMessage(item.IdTopic);
            lstRubric.Visibility = Visibility.Collapsed;
            lstTopic.Visibility = Visibility.Collapsed;
            lstMessage.Visibility = Visibility.Visible;
        }

        private void lstMessage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

