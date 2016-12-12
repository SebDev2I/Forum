using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FIISA_Universel
{
    class TopicViewModel : ViewModelBase
    {
        public Rubric MyRubric { get; set; }
        private ObservableCollection<Topic> _Topics;
        public bool HasTopic { get; set; }
        public ObservableCollection<Topic> Topics
        {
            get { return _Topics; }
            set { _Topics = value; }
        }

        public TopicViewModel(Rubric rubric)
        {
            MyRubric = rubric;
            MyRubric.GetListTopicsByRubric();
            _Topics = new ObservableCollection<Topic>();
            InitializeList();
        }

        public ReadOnlyObservableCollection<Topic> ListeTopics
        {
            get { return new ReadOnlyObservableCollection<Topic>(_Topics); }
        }

        public void InitializeList()
        {
            _Topics.Clear();
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
