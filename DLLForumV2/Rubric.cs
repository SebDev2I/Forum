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
    /// Classe pour les rubriques du forum
    /// </summary>
    public class Rubric : ForumBase
    {
        /// <summary>
        /// Id de la rubrique
        /// </summary>
        public int IdRubric { get; set; }
        /// <summary>
        /// Nom de la rubrique
        /// </summary>
        public string NameRubric { get; set; }
        /// <summary>
        /// Rubrique sous forme de dto
        /// </summary>
        public RubricDTO DTO { get; set; }
        /// <summary>
        /// Liste des sujets d'une rubrique
        /// </summary>
        public List<Topic> ListTopicsByRubric { get; set; }
        /// <summary>
        /// Permet l'accès aux ressources du web service
        /// </summary>
        private DALClient dal { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Rubric()
        {
            dal = new DALClient();
            ListTopicsByRubric = new List<Topic>();
            IdRubric = Int_NullValue;
            NameRubric = String_NullValue;
            DTO = new RubricDTO();
        }

        /// <summary>
        /// Constructeur pour mapper dto en Rubric
        /// </summary>
        /// <param name="dto"></param>
        public Rubric(RubricDTO dto) : this()
        {
            IdRubric = dto.IdRubric;
            NameRubric = dto.NameRubric;
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idrubric"></param>
        /// <param name="namerubric"></param>
        public Rubric(int idrubric, string namerubric) : this()
        {
            IdRubric = idrubric;
            NameRubric = namerubric;
            DTO = new RubricDTO();
            DTO.IdRubric = idrubric;
            DTO.NameRubric = namerubric;
        }

        /// <summary>
        /// Méthode permettant d'obtenir la liste des sujets par rubrique
        /// </summary>
        public void GetListTopicsByRubric()
        {
            ListTopicsByRubric.Clear();
            DALWSR_Result r1 = dal.GetTopicByRubricAsync(IdRubric, CancellationToken.None);
            if (r1.Data != null)
            {
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
                    ListTopicsByRubric.Add(new Topic(item, new Registered(regDto, reg.ObjStatus, reg.ObjTraining), new Rubric(rubric)));
                }
            }
            
        }

        /// <summary>
        /// Validation des propriétés de la rubrique
        /// </summary>
        /// <returns></returns>
        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }
        public override string ToString()
        {
            return "Id : " + IdRubric 
                + " Nom : " + NameRubric;
        }

        
        /// <summary>
        /// Méthode permettant de valider les chaînes de caractère,
        /// valeur null, longueur maxi, alphaonly
        /// </summary>
        /// <returns></returns>
        private bool Val_Name()
        {
            int i = 0;
            if (NameRubric == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "Le nom de la rubrique est requis"));
                i++;
            }
            if (NameRubric.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "Le nom de la rubrique doit contenir 50 caractères au maximum"));
                i++;
            }
            if (!AuditTool.IsAlpha(NameRubric))
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "Le nom de la rubrique ne peut contenir de chiffres"));
                i++;
            }
            if (i > 0)
            {
                return false;
            }
            else return true;
        }
    }
}
