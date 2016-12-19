using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIISA_Universel
{
    public class MainViewModel : ViewModelBase
    {
        public Forum MyForum { get; set; }
        public Registered MyRegistered { get; set; }
        private ObservableCollection<Rubric> _Rubrics;
        public ObservableCollection<Rubric> Rubrics
        {
            get { return _Rubrics; }
            set { _Rubrics = value; }
        }


        public MainViewModel()
        {
            MyForum = new Forum();
            _Rubrics = new ObservableCollection<Rubric>();
            InitializeList();
        }

        public ReadOnlyObservableCollection<Rubric> ListeRubrics
        {
            get { return new ReadOnlyObservableCollection<Rubric>(_Rubrics); }
        }


        public void InitializeList()
        {
            _Rubrics.Clear();
            foreach (Rubric item in MyForum.ListRubric)
            {
                _Rubrics.Add(item);
            }
        }
    }
}

