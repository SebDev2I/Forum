using Common;
using DALClientWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Forum
    {
        public Registered User { get; set; }
        public List<Rubric> ListRubric { get; set; }
        public List<Topic> ListTopic { get; set; }
        public DALClient dal { get; set; }

        public Forum()
        {
            dal = new DALClient();
            User = new Registered();
            ListRubric = new List<Rubric>();
            GetListRubrics();
            ListTopic = new List<Topic>();
            GetListTopics();
        }

        public void GetListRubrics()
        {
            DALWSR_Result r1 = dal.GetListRubricsAsync(CancellationToken.None);
            foreach (RubricDTO item in (List<RubricDTO>)r1.Data)
            {
                ListRubric.Add(new Rubric(item));
            }
        }

        public void GetListTopics()
        {
            DALWSR_Result r1 = dal.GetTopicsAsync(CancellationToken.None);
            Registered reg;
            foreach (TopicDTO item in (List<TopicDTO>)r1.Data)
            {
                DALWSR_Result r2 = dal.GetRubricByIdAsync(item.IdRubric, CancellationToken.None);
                RubricDTO rubric = (RubricDTO)r2.Data;
                DALWSR_Result r3 = dal.GetUserByIdAsync(item.IdUser, CancellationToken.None);
                RegisteredDTO regDto = (RegisteredDTO)r3.Data;
                reg = new Registered();
                reg.ObjStatus = reg.GetStatus(regDto.StatusUser);
                reg.ObjTraining = reg.GetTraining(regDto.TrainingUser);
                ListTopic.Add(new Topic(item, new Registered(regDto, reg.ObjStatus, reg.ObjTraining), new Rubric(rubric)));
            }
            //return ListTopic;
        }

        

    }
}
