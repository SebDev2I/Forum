using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Topic : ForumBase
    {
        public int IdTopic { get; set; }
        public int IdUser { get; set; }
        public int IdRubric { get; set; }
        public DateTime DateTopic { get; set; }
        public string TitleTopic { get; set; }
        public string DescTopic { get; set; }
        public TopicDTO DTO { get; set; }
        public Topic()
        {
            IdTopic = Int_NullValue;
            IdUser = Int_NullValue;
            IdRubric = Int_NullValue;
            DateTopic = DateTime_NullValue;
            TitleTopic = String_NullValue;
            DescTopic = String_NullValue;
            DTO = new TopicDTO(); 
        }

        public Topic(TopicDTO dto)
        {
            IdTopic = dto.IdTopic;
            IdUser = dto.IdUser;
            IdRubric = dto.IdRubric;
            DateTopic = dto.DateTopic;
            TitleTopic = dto.TitleTopic;
            DescTopic = dto.DescTopic;
        }

        public Topic(int idtopic, int iduser, int idrubric, DateTime datetopic, string titletopic, string desctopic)
        {
            IdTopic = idtopic;
            IdUser = iduser;
            IdRubric = idrubric;
            DateTopic = datetopic;
            TitleTopic = titletopic;
            DescTopic = desctopic;
            DTO = new TopicDTO();
            DTO.IdTopic = idtopic;
            DTO.IdUser = iduser;
            DTO.IdRubric = idrubric;
            DTO.DateTopic = datetopic;
            DTO.TitleTopic = titletopic;
            DTO.DescTopic = desctopic;
        }

        public override string ToString()
        {
            return " Id : " + IdTopic
                + " IdUser = " + IdUser
                + " IdRubric = " + IdRubric
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
