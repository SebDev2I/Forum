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
    public class Rubric : ForumBase
    {
        public int IdRubric { get; set; }
        public string NameRubric { get; set; }
        public RubricDTO DTO { get; set; }
        public Rubric()
        {
            IdRubric = Int_NullValue;
            NameRubric = String_NullValue;
            DTO = new RubricDTO();
        }

        public Rubric(RubricDTO dto)
        {
            IdRubric = dto.IdRubric;
            NameRubric = dto.NameRubric;
            DTO = dto;
        }

        public Rubric(int idrubric, string namerubric)
        {
            IdRubric = idrubric;
            NameRubric = namerubric;
            DTO = new RubricDTO();
            DTO.IdRubric = idrubric;
            DTO.NameRubric = namerubric;
        }

        /*public async Task<List<Topic>> GetListTopicsByRubric()
        {
            DALClient dal = new DALClient();
            DALWSR_Result r = await dal.GetListTopicByRubric(IdRubric, CancellationToken.None);
            List<TopicDTO> lst = (List<TopicDTO>)r.Data;
            List<Topic> lsttopic = new List<Topic>();
            foreach (TopicDTO item in lst)
            {
                lsttopic.Add(new Topic(item));
            }
            return lsttopic;
        }*/
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

        

        private bool Val_Name()
        {
            int i = 0;
            if (NameRubric == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> est requis"));
                i++;
            }
            if (NameRubric.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> doit contenir 50 caractères au maximum"));
                i++;
            }
            if (!AuditTool.IsAlpha(NameRubric))
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> ne peut contenir de chiffres"));
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
