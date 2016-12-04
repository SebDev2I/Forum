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
        public DALClient dal { get; set; }
        public Topic()
        {
            IdTopic = Int_NullValue;
            ObjUser = new Registered();
            ObjRubric = new Rubric();
            DateTopic = DateTime_NullValue;
            TitleTopic = String_NullValue;
            DescTopic = String_NullValue;
            DTO = new TopicDTO(); 
        }

        public Topic(TopicDTO dto, Registered objuser, Rubric objrubric)
        {
            IdTopic = dto.IdTopic;
            ObjUser = objuser;
            ObjRubric = objrubric;
            DateTopic = dto.DateTopic;
            TitleTopic = dto.TitleTopic;
            DescTopic = dto.DescTopic;
            DTO = dto;
        }

        public Topic(int idtopic, Registered objuser, Rubric objrubric, DateTime datetopic, string titletopic, string desctopic)
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

        /*private async void GetRubric(int idrubric)
        {
            dal = new DALClient();
            DALWSR_Result r1 = await dal.GetRubricById(idrubric, CancellationToken.None);
            RubricDTO t = (RubricDTO)r1.Data;
            ObjRubric = new Rubric(t);
        }*/
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
