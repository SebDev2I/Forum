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
            ListTopic = new List<Topic>();
        }

        public async Task<List<Rubric>> GetListRubrics()
        {
            DALWSR_Result r1 = await dal.GetListRubrics(CancellationToken.None);
            foreach (RubricDTO item in (List<RubricDTO>)r1.Data)
            {
                ListRubric.Add(new Rubric(item));
            }
            return ListRubric;
        }

        public async Task<List<Topic>> GetListTopics()
        {
            DALWSR_Result r1 = await dal.GetTopics(CancellationToken.None);
            Registered reg;
            foreach (TopicDTO item in (List<TopicDTO>)r1.Data)
            {
                DALWSR_Result r2 = await dal.GetRubricById(item.IdRubric, CancellationToken.None);
                RubricDTO rubric = (RubricDTO)r2.Data;
                DALWSR_Result r3 = await dal.GetUserById(item.IdUser, CancellationToken.None);
                RegisteredDTO regDto = (RegisteredDTO)r3.Data;
                reg = new Registered();
                reg.ObjStatus = await reg.GetStatus(regDto.StatusUser);
                reg.ObjTraining = await reg.GetTraining(regDto.TrainingUser);
                ListTopic.Add(new Topic(item, new Registered(regDto, reg.ObjStatus, reg.ObjTraining), new Rubric(rubric)));
            }
            return ListTopic;
        }

        

    }
}
