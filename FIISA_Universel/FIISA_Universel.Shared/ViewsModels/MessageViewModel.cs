using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIISA_Universel
{
    public class MessageViewModel : ViewModelBase
    {
        
        public Topic MyTopic { get; set; }
        private ObservableCollection<Message> _Messages;
        public ObservableCollection<Message> Messages
        {
            get { return _Messages; }
            set { _Messages = value; }
        }

        public MessageViewModel(Topic topic)
        {
            MyTopic = topic;
            MyTopic.GetListMessagesByTopic();
            _Messages = new ObservableCollection<Message>();
            InitializeList();
        }

        public ReadOnlyObservableCollection<Message> ListeMessages
        {
            get { return new ReadOnlyObservableCollection<Message>(_Messages); }
        }

        public void InitializeList()
        {
            _Messages.Clear();
            foreach (Message item in MyTopic.ListMessagesByTopic)
            {
                _Messages.Add(item);
            }
        }
    }
}
    
