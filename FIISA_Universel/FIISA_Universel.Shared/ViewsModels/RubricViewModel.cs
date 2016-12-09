using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FIISA_Universel
{
    public class RubricViewModel : ViewModelBase
    {
        public Forum MyForum { get; set; }
        private ObservableCollection<Rubric> _Rubrics;
        public ObservableCollection<Rubric> Rubrics
        {
            get { return _Rubrics; }
            set { _Rubrics = value; }
        }
        
        public RubricViewModel()
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

