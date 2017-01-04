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
        public Rubric MyRubric { get; set; }
        public Topic MyTopic { get; set; }
        public Message MyMessage { get; set; }

        private Registered _MyRegistered;
        public Registered MyRegistered
        {
            get { return _MyRegistered; }
            set
            {
                if(_MyRegistered != value)
                {
                    _MyRegistered = value;
                }
                RaisePropertyChanged();
            }
        }

        private bool _IsLogged;
        public bool IsLogged
        {
            get { return _IsLogged; }
            set
            {
                if(_IsLogged != value)
                {
                    _IsLogged = value;
                }
                RaisePropertyChanged();
            }
        }

        public bool HasTopic { get; set; }
        public bool HasMessage { get; set; }
        

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
        public ReadOnlyObservableCollection<Message> ListeMessages
        {
            get { return new ReadOnlyObservableCollection<Message>(_Messages); }
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
        public void InitializeListMessage()
        {
            _Messages.Clear();
            MyTopic.GetListMessagesByTopic();
            if (MyTopic.ListMessagesByTopic.Count == 0)
            {
                HasMessage = false;
            }
            else HasMessage = true;
            foreach (Message item in MyTopic.ListMessagesByTopic)
            {
                _Messages.Add(item);
            }
        }
    }
}

