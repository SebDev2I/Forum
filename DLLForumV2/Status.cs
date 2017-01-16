using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe de statut de l'utilisateur
    /// </summary>
    public class Status : ForumBase
    {
        /// <summary>
        /// Id du statut
        /// </summary>
        public int IdStatus { get; set; }
        /// <summary>
        /// Nom du statut
        /// </summary>
        public string NameStatus { get; set; }
        /// <summary>
        /// Statut sous forme de dto
        /// </summary>
        public StatusDTO DTO { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Status()
        {
            IdStatus = Int_NullValue;
            NameStatus = String_NullValue;
            DTO = new StatusDTO();
        }

        /// <summary>
        /// Constructeur pour mapper dto en Status
        /// </summary>
        /// <param name="dto"></param>
        public Status(StatusDTO dto)
        {
            IdStatus = dto.IdStatus;
            NameStatus = dto.NameStatus;
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idstatus"></param>
        /// <param name="namestatus"></param>
        public Status(int idstatus, string namestatus)
        {
            IdStatus = idstatus;
            NameStatus = namestatus;
            DTO = new StatusDTO();
            DTO.IdStatus = idstatus;
            DTO.NameStatus = namestatus;
        }

        public override string ToString()
        {
            return "Id : " + IdStatus
                + " Name : " + NameStatus;
        }

        /// <summary>
        /// Validation des propriétés du statut
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
            if (NameStatus == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Status.NameStatus", "Le nom du statut est requis"));
                return false;
            }
            else if (NameStatus.Length > 10)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "Le nom du statut doit contenir 50 caractères au maximum"));
                return false;
            }
            return true;
        }
    }
}
