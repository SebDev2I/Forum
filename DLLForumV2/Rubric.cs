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
        public List<Topic> ListTopicsByRubric { get; set; }
        private DALClient dal { get; set; }
        public Rubric()
        {
            dal = new DALClient();
            ListTopicsByRubric = new List<Topic>();
            IdRubric = Int_NullValue;
            NameRubric = String_NullValue;
            DTO = new RubricDTO();
        }

        public Rubric(RubricDTO dto) : this()
        {
            IdRubric = dto.IdRubric;
            NameRubric = dto.NameRubric;
            DTO = dto;
        }

        public Rubric(int idrubric, string namerubric) : this()
        {
            IdRubric = idrubric;
            NameRubric = namerubric;
            DTO = new RubricDTO();
            DTO.IdRubric = idrubric;
            DTO.NameRubric = namerubric;
        }

        public async Task<List<Topic>> GetListTopicsByRubric(int idrubric)
        {
            DALWSR_Result r1 = await dal.GetTopicByRubric(idrubric, CancellationToken.None);
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
                ListTopicsByRubric.Add(new Topic(item, new Registered(regDto, reg.ObjStatus, reg.ObjTraining), new Rubric(rubric)));
            }
            return ListTopicsByRubric;
        }
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
