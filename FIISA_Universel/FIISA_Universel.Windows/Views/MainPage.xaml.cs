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
            DataContext = m;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*lstRubric.Items.Clear();
            List<Rubric> lst = new List<Rubric>();
            lst = await forum.GetListRubrics();
            foreach (Rubric item in lst)
            {
                lstRubric.Items.Add(item.NameRubric);
            }*/
            //MainViewModel m = new MainViewModel();


            /*foreach (Rubric item in m.MyForum.ListRubric)
            {
                lstRubric.Items.Add(item);
            }*/
        }
        private void cmdHome_Click(object sender, RoutedEventArgs e)
        {
            string id = lstRubric.SelectedItem.ToString();
            //id = lstRubric.SelectedValuePath
        }
    }
}

