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
        public Rubric MyRubric { get; set; }
        public bool HasTopic { get; set; }
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
        public RubricViewModel()
        {
            MyForum = new Forum();
            _Rubrics = new ObservableCollection<Rubric>();
            _Topics = new ObservableCollection<Topic>();
            InitializeListRubric();
        }

        public ReadOnlyObservableCollection<Rubric> ListeRubrics
        {
            get { return new ReadOnlyObservableCollection<Rubric>(_Rubrics); }
        }
        public ReadOnlyObservableCollection<Topic> ListeTopics
        {
            get { return new ReadOnlyObservableCollection<Topic>(_Topics); }
        }

        public void InitializeListRubric()
        {
            _Rubrics.Clear();
            foreach (Rubric item in MyForum.ListRubric)
            {
                _Rubrics.Add(item);
            }
        }

        public void InitializeListTopic()
        {
            _Topics.Clear();
            MyRubric.GetListTopicsByRubric();
            if (MyRubric.ListTopicsByRubric.Count == 0)
            {
                HasTopic = false;
            }
            else HasTopic = true;
            foreach (Topic item in MyRubric.ListTopicsByRubric)
            {
                _Topics.Add(item);
            }
        }
    }
}

