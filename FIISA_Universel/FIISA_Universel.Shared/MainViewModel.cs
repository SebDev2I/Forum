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
        private bool _IsTopicByRubric;

        public bool IsTopicByRubric
        {
            get { return _IsTopicByRubric; }
            set { _IsTopicByRubric = value; }
        }



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

        private ObservableCollection<Message> _Messages;
        public ObservableCollection<Message> Messages
        {
            get { return _Messages; }
            set { _Messages = value; }
        }
        public MainViewModel()
        {
            MyForum = new Forum();
            _Rubrics = new ObservableCollection<Rubric>();
            _Topics = new ObservableCollection<Topic>();
            _Messages = new ObservableCollection<Message>();
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

        public ReadOnlyObservableCollection<Message> ListeMessages
        {
            get { return new ReadOnlyObservableCollection<Message>(_Messages); }
        }
        public void InitializeList()
        {
            _Rubrics.Clear();
            _Topics.Clear();
            _Messages.Clear();
            foreach (Rubric item in MyForum.ListRubric)
            {
                _Rubrics.Add(item);
            }
            foreach (Topic item in MyForum.ListTopic)
            {
                _Topics.Add(item);
            }
        }

        public void UpdateListTopic(int idrubric)
        {
            Rubric rubric = new Rubric();
            //MyForum.ListTopic.Clear();
            rubric.GetListTopicsByRubric(idrubric);
            //MyForum.ListTopic = rubric
            _Topics.Clear();
            foreach (Topic item in rubric.ListTopicsByRubric)
            {
                _Topics.Add(item);
            }
        }

        public void UpdateListMessage(int idtopic)
        {
            Topic topic = new Topic();
            topic.GetListMessagesByTopic(idtopic);
            _Messages.Clear();
            foreach (Message item in topic.ListMessagesByTopic)
            {
                _Messages.Add(item);
            }
        }
    }
}
		
