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
    public sealed partial class RubricPage : Page
    {
        private RubricViewModel rubricVM;
        public RubricPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rubricVM = (RubricViewModel)e.Parameter;
            DataContext = rubricVM;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }
        private void lstRubric_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            Rubric output = e.ClickedItem as Rubric;
            rubricVM.MyRubric = output;
            rubricVM.InitializeListTopic();
            if (rubricVM.HasTopic)
            {
                lstTopic.Visibility = Visibility.Visible;
                lblNotTopic.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstTopic.Visibility = Visibility.Collapsed;
                lblNotTopic.Visibility = Visibility.Visible;
            }
            //Frame.Navigate(typeof(TopicPage), topicVM);
            //Rubric item = (Rubric)lstRubric.SelectedItems[0];
        }

        private void lstTopic_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        
    }
}
