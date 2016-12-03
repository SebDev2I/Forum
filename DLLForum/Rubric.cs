using DLLForumV2;
using DALClientWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLLForum
{
    /// <summary>
    /// Les rubriques du forum
    /// </summary>
    public class Rubric : ForumBase
    {
        public RubricDTO Data { get; set; }
        public Rubric()
        {
            this.Data = new RubricDTO();
        }
        public Rubric(RubricDTO dto)
        {
            this.Data = dto;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        public async Task<List<Training>> GetListTrainings()
        {
            DALClient dal = new DALClient();
            DALWSR_Result r = await dal.GetListTrainings(CancellationToken.None);
            List<TrainingDTO> listDTO = (List<TrainingDTO>)r.Data;
            List<Training> list = new List<Training>();
            foreach (TrainingDTO item in listDTO)
            {
                list.Add(new Training(item));
            }
            return list;
        }
        public static TOut Convert<TOut, TIn>(TIn fromRecord) where TOut : new()
        {
            var toRecord = new TOut();
            PropertyInfo[] fromFields = null;
            PropertyInfo[] toFields = null;

            fromFields = typeof(TIn).GetProperties();
            toFields = typeof(TOut).GetProperties();

            foreach (var fromField in fromFields)
            {
                foreach (var toField in toFields)
                {
                    if (fromField.Name == toField.Name)
                    {
                        toField.SetValue(toRecord, fromField.GetValue(fromRecord, null), null);
                        break;
                    }
                }

            }
            return toRecord;
        }

        public static List<TOut> Convert<TOut, TIn>(List<TIn> fromRecordList) where TOut : new()
        {
            return fromRecordList.Count == 0 ? null : fromRecordList.Select(Convert<TOut, TIn>).ToList();
        }
        private bool Val_Name()
        {
            if (Data.NameRubric == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> est requis"));
                return false;
            }
            else if (Data.NameRubric.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> doit contenir 50 caractères au maximum"));
                return false;
            }
            else if (!AuditTool.IsAlpha(Data.NameRubric))
            {
                this.ValidationErrors.Add(new ValidationError("Rubric.NameRubric", "<NAME_RUBRIC> ne peut contenir de chiffres"));
                return false;
            }
            else return true;
        }
        /*#region Attributs et propriétés
        private int _IdRubric;
        [DataMember(Order = 1)]
        public int IdRubric
        {
            get { return _IdRubric; }
            set { _IdRubric = value; }
        }

        private string _NameRubric;
        [DataMember(Order = 2)]
        public string NameRubric
        {
            get { return _NameRubric; }
            set { _NameRubric = value; }
        }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Rubric()
        {
            _IdRubric = 0;
            _NameRubric = "EssaiRubric";
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idrubric"></param>
        /// <param name="namerubric"></param>
        public Rubric(int idrubric, string namerubric)
        {
            _IdRubric = idrubric;
            _NameRubric = namerubric;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode affichant les topics par rubrique
        /// </summary>
        public List<Topic> ShowTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            return listTopics;
        }
        #endregion*/

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return "Id : " + Data.IdRubric 
                + " Nom : " + Data.NameRubric;
        }
        #endregion
    }
}

