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
    /// <summary>
    /// Classe pour les sujets du forum
    /// </summary>
    public class Topic : ForumBase
    {
        /// <summary>
        /// Id du sujet
        /// </summary>
        public int IdTopic { get; set; }
        /// <summary>
        /// Utilisateur ayant créé le sujet
        /// </summary>
        public Registered ObjUser { get; set; }
        /// <summary>
        /// Rubrique du sujet
        /// </summary>
        public Rubric ObjRubric { get; set; }
        /// <summary>
        /// Date de création du sujet
        /// </summary>
        public DateTime DateTopic { get; set; }
        /// <summary>
        /// Titre du sujet
        /// </summary>
        public string TitleTopic { get; set; }
        /// <summary>
        /// Description du sujet
        /// </summary>
        public string DescTopic { get; set; }
        /// <summary>
        /// Sujet sous forme de dto
        /// </summary>
        public TopicDTO DTO { get; set; }
        /// <summary>
        /// Liste des messages d'un sujet
        /// </summary>
        public List<Message> ListMessagesByTopic { get; set; }
        /// <summary>
        /// Permet l'accès aux ressources du web service
        /// </summary>
        private DALClient dal { get; set; }


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
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

        
        /// <summary>
        /// Constructeur pour mapper dto en Topic
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="objuser"></param>
        /// <param name="objrubric"></param>
        public Topic(TopicDTO dto, Registered objuser, Rubric objrubric) : this()
        {
            IdTopic = dto.IdTopic;
            ObjUser = objuser;
            ObjRubric = objrubric;
            DateTopic = dto.DateTopic;
            TitleTopic = dto.TitleTopic;
            DescTopic = AuditTool.StringToRtf(dto.DescTopic);
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idtopic"></param>
        /// <param name="objuser"></param>
        /// <param name="objrubric"></param>
        /// <param name="datetopic"></param>
        /// <param name="titletopic"></param>
        /// <param name="desctopic"></param>
        public Topic(int idtopic, Registered objuser, Rubric objrubric, DateTime datetopic, string titletopic, string desctopic) : this()
        {
            IdTopic = idtopic;
            ObjUser = objuser;
            ObjRubric = objrubric;
            DateTopic = datetopic;
            TitleTopic = titletopic;
            DescTopic = AuditTool.RtfToString(desctopic);
            DTO = new TopicDTO();
            DTO.IdTopic = idtopic;
            DTO.IdUser = objuser.IdUser;
            DTO.IdRubric = objrubric.IdRubric;
            DTO.DateTopic = datetopic;
            DTO.TitleTopic = titletopic;
            DTO.DescTopic = DescTopic;
        }

        /// <summary>
        /// Méthode permettant d'obtenir la liste de messages par sujet
        /// </summary>
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

        /// <summary>
        /// Validation des propriétés du sujet
        /// </summary>
        /// <returns></returns>
        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        /// <summary>
        /// Méthode permettant de valider les chaînes de caractères,
        /// valeur null, longueur maxi
        /// </summary>
        /// <returns></returns>
        private bool Val_Name()
        {
            int i = 0;
            if (TitleTopic == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.TitleTopic", "Le titre du sujet est requis"));
                i++;
            }
            if (TitleTopic.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.TitleTopic", "Le titre du sujet doit contenir 50 caractères au maximum"));
                i++;
            }
            if (DescTopic == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Topic.DescTopic", "Le champ description du sujet est requis"));
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
