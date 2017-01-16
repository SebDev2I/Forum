using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe de la formation de l'utilisateur
    /// </summary>
    public class Training : ForumBase
    {
        /// <summary>
        /// Id de la formation
        /// </summary>
        public int IdTraining { get; set; }
        /// <summary>
        /// Nom de la formation
        /// </summary>
        public string NameTraining { get; set; }
        /// <summary>
        /// Formation sous forme de dto
        /// </summary>
        public TrainingDTO DTO { get; set; }


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Training()
        {
            IdTraining = Int_NullValue;
            NameTraining = String_NullValue;
            DTO = new TrainingDTO();
        }

        /// <summary>
        /// Constructeur pour mapper dto en Training
        /// </summary>
        /// <param name="dto"></param>
        public Training(TrainingDTO dto)
        {
            IdTraining = dto.IdTraining;
            NameTraining = dto.NameTraining;
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idtraining"></param>
        /// <param name="nametraining"></param>
        public Training(int idtraining, string nametraining)
        {
            IdTraining = idtraining;
            NameTraining = nametraining;
            DTO = new TrainingDTO();
            DTO.IdTraining = idtraining;
            DTO.NameTraining = nametraining;
        }
        public override string ToString()
        {
            return "Id : " + IdTraining 
                + " Name : " + NameTraining;
        }

        /// <summary>
        /// Validation des propriétés de la formation
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
        public bool Val_Name()
        {
            if(NameTraining == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "Le nom de la formation est requis"));
                return false;
            }
            else if (NameTraining.Length > 10)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "Le nom de la formation doit contenir 10 caractères au maximum"));
                return false;
            }
            return true;
        }
    }
}
