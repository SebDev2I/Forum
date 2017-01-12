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
        private int _IndexStatus;

        public int IndexStatus
        {
            get { return _IndexStatus; }
            set
            {
                _IndexStatus = value;
                RaisePropertyChanged();
            }
        }

        private int _IndexTraining;

        public int IndexTraining
        {
            get { return _IndexTraining; }
            set
            {
                _IndexTraining = value;
                RaisePropertyChanged();
            }
        }


        private bool _InfoUser;

        public bool InfoUser
        {
            get { return _InfoUser; }
            set
            {
                _InfoUser = value;
                RaisePropertyChanged();
            }
        }

        public Forum MyForum { get; set; }
        private Rubric _MyRubric;
        public Rubric MyRubric
        {
            get { return _MyRubric; }
            set
            {
                if (_MyRubric != value)
                {
                    _MyRubric = value;
                }
                RaisePropertyChanged();
            }
        }
        private Topic _MyTopic;
        public Topic MyTopic
        {
            get { return _MyTopic; }
            set
            {
                if (_MyTopic != value)
                {
                    _MyTopic = value;
                }
                RaisePropertyChanged();
            }
        }
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

        private ObservableCollection<Training> _Trainings;
        public ObservableCollection<Training> Trainings
        {
            get { return _Trainings; }
            set { _Trainings = value; }
        }

        private ObservableCollection<Status> _Status;
        public ObservableCollection<Status> Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public MainViewModel()
        {
            MyForum = new Forum();
            _Rubrics = new ObservableCollection<Rubric>();
            _Topics = new ObservableCollection<Topic>();
            _Messages = new ObservableCollection<Message>();
            _Trainings = new ObservableCollection<Training>();
            _Status = new ObservableCollection<Status>();
            InitializeListRubric();
            InitializeListStatus();
            InitializeListTraining();
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
        public ReadOnlyObservableCollection<Training> ListeTrainings
        {
            get { return new ReadOnlyObservableCollection<Training>(_Trainings); }
        }
        public ReadOnlyObservableCollection<Status> ListeStatus
        {
            get { return new ReadOnlyObservableCollection<Status>(_Status); }
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
            if(MyRubric != null)
            {
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
        public void InitializeListMessage()
        {
            _Messages.Clear();
            if(MyTopic != null)
            {
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
        public void InitializeListStatus()
        {
            _Status.Clear();
            foreach (Status item in MyForum.ListStatus)
            {
                _Status.Add(item);
            }
        }
        public void InitializeListTraining()
        {
            _Trainings.Clear();
            foreach (Training item in MyForum.ListTraining)
            {
                _Trainings.Add(item);
            }
        }
    }
}

