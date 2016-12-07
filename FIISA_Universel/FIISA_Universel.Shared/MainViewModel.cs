using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FIISA_Universel
{
    public class MainViewModel : ViewModelBase
    {
        public Forum MyForum { get; set; }

        

        private ObservableCollection<Rubric> _Rubrics;
        public ObservableCollection<Rubric> Rubrics
        {
            get { return _Rubrics; }
            set { _Rubrics = value; }
        }

        private ObservableCollection<Topic> _Topics;

        public ObservableCollection<Topic> Topics
        {
            get { return _Topics; }
            set { _Topics = value; }
        }


        public MainViewModel()
        {
            MyForum = new Forum();
            _Rubrics = new ObservableCollection<Rubric>();
            _Topics = new ObservableCollection<Topic>();
            InitializeList();
        }

        public ReadOnlyObservableCollection<Rubric> ListeRubrics
        {
            get { return new ReadOnlyObservableCollection<Rubric>(_Rubrics); }
        }

        public ReadOnlyObservableCollection<Topic> ListeTopics
        {
            get { return new ReadOnlyObservableCollection<Topic>(_Topics); }
        }

        public void InitializeList()
        {
            foreach (Rubric item in MyForum.ListRubric)
            {
                _Rubrics.Add(item);
            }
            foreach (Topic item in MyForum.ListTopic)
            {
                _Topics.Add(item);
            }

        }
    }
}
		
