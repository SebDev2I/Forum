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
    public class Topic : ForumBase
    {
        public int IdTopic { get; set; }
        public Registered ObjUser { get; set; }
        public Rubric ObjRubric { get; set; }
        public DateTime DateTopic { get; set; }
        public string TitleTopic { get; set; }
        public string DescTopic { get; set; }
        public TopicDTO DTO { get; set; }
        public List<Message> ListMessagesByTopic { get; set; }
        private DALClient dal { get; set; }
        public Topic()
        {
            dal = new DALClient();
            ListMessagesByTopic = new List<Message>();
            IdTopic = Int_NullValue;
            ObjUser = new Registered();
            ObjRubric = new Rubric();
            DateTopic = DateTime_NullValue;
            TitleTopic = String_NullValue;
            DescTopic = String_NullValue;
            DTO = new TopicDTO(); 
        }

        

        public Topic(TopicDTO dto, Registered objuser, Rubric objrubric) : this()
        {
            IdTopic = dto.IdTopic;
            ObjUser = objuser;
            ObjRubric = objrubric;
            DateTopic = dto.DateTopic;
            TitleTopic = dto.TitleTopic;
            DescTopic = dto.DescTopic;
            DTO = dto;
        }

        public Topic(int idtopic, Registered objuser, Rubric objrubric, DateTime datetopic, string titletopic, string desctopic) : this()
        {
            IdTopic = idtopic;
            ObjUser = objuser;
            ObjRubric = objrubric;
            DateTopic = datetopic;
            TitleTopic = titletopic;
            DescTopic = desctopic;
            DTO = new TopicDTO();
            DTO.IdTopic = idtopic;
            DTO.IdUser = objuser.IdUser;
            DTO.IdRubric = objrubric.IdRubric;
            DTO.DateTopic = datetopic;
            DTO.TitleTopic = titletopic;
            DTO.DescTopic = desctopic;
        }

        public void GetListMessagesByTopic()
        {
            ListMessagesByTopic.Clear();
            DALWSR_Result r1 = dal.GetMessagesByTopicAsync(IdTopic, CancellationToken.None);
            Registered reg;
            if(r1.Data != null)
            {
                foreach (MessageDTO item in (List<MessageDTO>)r1.Data)
                {
                    DALWSR_Result r2 = dal.GetTopicByIdAsync(item.IdTopic, CancellationToken.None);
                    TopicDTO topicDto = (TopicDTO)r2.Data;
                    DALWSR_Result r3 = dal.GetUserByIdAsync(item.IdUser, CancellationToken.None);
                    RegisteredDTO regDto = (RegisteredDTO)r3.Data;
                    reg = new Registered();
                    reg.ObjStatus = reg.GetStatus(regDto.StatusUser);
                    reg.ObjTraining = reg.GetTraining(regDto.TrainingUser);
                    ListMessagesByTopic.Add(new Message(item, new Registered(regDto, reg.ObjStatus, reg.ObjTraining)));
                }
            }
            
        }
        public override string ToString()
        {
            return " Id : " + IdTopic
                + " User = " + ObjUser
                + " Rubric = " + ObjRubric
                + " Date : " + DateTopic
                + " Titre : " + TitleTopic
                + " Description : " + DescTopic;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            int i = 0;
            if (TitleTopic == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.TitleTopic", "<TITLE_TOPIC> est requis"));
                i++;
            }
            if (TitleTopic.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.TitleTopic", "<TITLE_TOPIC> doit contenir 50 caractères au maximum"));
                i++;
            }
            if (DescTopic == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.DescTopic", "<DESC_TOPIC> est requis"));
                i++;
            }
            if (TitleTopic.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.DescTopic", "<DESC_TOPIC> doit contenir 1024 caractères au maximum"));
                i++;
            }
            if ( i== 0)
            {
                return true;
            }
            else return false;
        }

       
    }
}
