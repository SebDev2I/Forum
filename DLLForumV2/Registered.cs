using Common;
using DALClientWS;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe pour l'utilisateur authentifié du forum
    /// </summary>
    public class Registered : ForumBase
    {
        /// <summary>
        /// Id de l'utilisateur
        /// </summary>
        public int IdUser { get; set; }
        /// <summary>
        /// Status de l'utilisateur
        /// </summary>
        public Status ObjStatus { get; set; }
        /// <summary>
        /// Formation de l'utilisateur
        /// </summary>
        public Training ObjTraining { get; set; }
        /// <summary>
        /// Le nom de famille de l'utilisateur
        /// </summary>
        public string NameUser { get; set; }
        /// <summary>
        /// Le prénom de l'utilisateur
        /// </summary>
        public string FirstnameUser { get; set; }
        /// <summary>
        /// L'email
        /// </summary>
        public string EmailUser { get; set; }
        /// <summary>
        /// L'identifiant
        /// </summary>
        public string LoginUser { get; set; }
        /// <summary>
        /// Le mot de passe
        /// </summary>
        public string PwdUser { get; set; }
        /// <summary>
        /// Le mot-clé
        /// </summary>
        public string KeywordUser { get; set; }
        /// <summary>
        /// Utilisateur sous forme de dto
        /// </summary>
        public RegisteredDTO DTO { get; set; }
        /// <summary>
        /// Liste des utilisateurs ayant un compte
        /// </summary>
        public List<Registered> ListRegistered { get; set; }
        /// <summary>
        /// Permet l'accès aux ressources du web service
        /// </summary>
        private DALClient dal { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Registered()
        {
            dal = new DALClient();
            ListRegistered = new List<Registered>();
            IdUser = Int_NullValue;
            ObjStatus = null;
            NameUser = String_NullValue;
            ObjTraining = null;
            FirstnameUser = String_NullValue;
            EmailUser = String_NullValue;
            LoginUser = String_NullValue;
            PwdUser = String_NullValue;
            KeywordUser = String_NullValue;
            DTO = new RegisteredDTO();
        }

        /// <summary>
        /// Constructeur pour mapper dto en Registered
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="objstatus"></param>
        /// <param name="objtraining"></param>
        public Registered(RegisteredDTO dto, Status objstatus, Training objtraining) : this()
        {
            IdUser = dto.IdUser;
            ObjStatus = objstatus;
            ObjTraining = objtraining;
            NameUser = dto.NameUser;
            FirstnameUser = dto.FirstnameUser;
            EmailUser = dto.EmailUser;
            LoginUser = dto.LoginUser;
            PwdUser = TokenManager.GetPwd(Encoding.UTF8.GetString(Convert.FromBase64String(dto.PwdUser), 0, Convert.FromBase64String(dto.PwdUser).Length));
            KeywordUser = dto.KeywordUser;
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="iduser"></param>
        /// <param name="objstatus"></param>
        /// <param name="objtraining"></param>
        /// <param name="nameuser"></param>
        /// <param name="firstnameuser"></param>
        /// <param name="emailuser"></param>
        /// <param name="loginuser"></param>
        /// <param name="pwduser"></param>
        /// <param name="keyworduser"></param>
        public Registered(int iduser, Status objstatus, Training objtraining, string nameuser, string firstnameuser, 
            string emailuser, string loginuser, string pwduser, string keyworduser) : this()
        {
            IdUser = iduser;
            ObjStatus = objstatus;
            NameUser = nameuser;
            FirstnameUser = firstnameuser;
            EmailUser = emailuser;
            LoginUser = loginuser;
            PwdUser = pwduser;
            KeywordUser = keyworduser;
            DTO = new RegisteredDTO();
            DTO.IdUser = iduser;
            DTO.StatusUser = objstatus.IdStatus;
            DTO.TrainingUser = objtraining.IdTraining;
            DTO.NameUser = nameuser;
            DTO.FirstnameUser = firstnameuser;
            DTO.EmailUser = emailuser;
            DTO.LoginUser = loginuser;
            DTO.PwdUser = TokenManager.HashPwd(LoginUser, PwdUser);
            DTO.KeywordUser = keyworduser;
        }

        /// <summary>
        /// Méthode pour avoir les infos d'un utilisateur ayant un compte
        /// </summary>
        /// <param name="iduser"></param>
        /// <returns></returns>
        public Registered GetInfoUser(int iduser)
        {
            DALWSR_Result r1 = dal.GetUserByIdAsync(iduser, CancellationToken.None);
            RegisteredDTO regDto = (RegisteredDTO)r1.Data;
            if(regDto != null)
            {
                return new Registered(regDto, GetStatus(regDto.StatusUser), GetTraining(regDto.TrainingUser));
            }
            return null;
        }

        /// <summary>
        /// Méthode permettant de sauvegarder un utilisateur, create ou update
        /// </summary>
        /// <param name="registered"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool SaveUser(Registered registered, Token token)
        {
            RegisteredDTO e = registered.DTO;
            DALWSR_Result r1 = dal.SaveUser(registered.DTO, token, CancellationToken.None);
            return r1.IsSuccess;
        }

        /// <summary>
        /// Méthode permettant d'avoir la liste des utilisateurs ayant un compte
        /// </summary>
        /// <returns></returns>
        public List<Registered> GetListUsers()
        {
            DALWSR_Result r1 = dal.GetUsers(CancellationToken.None);
            foreach (RegisteredDTO item in (List<RegisteredDTO>)r1.Data)
            {
                ListRegistered.Add(new Registered(item, GetStatus(item.StatusUser), GetTraining(item.TrainingUser)));
            }
            return ListRegistered;
        }

        /// <summary>
        /// Méthode permettant d'obtenir la formation
        /// </summary>
        /// <param name="idtraining"></param>
        /// <returns></returns>
        public Training GetTraining(int idtraining)
        {
            DALWSR_Result r3 = dal.GetTrainingByIdAsync(idtraining, CancellationToken.None);
            TrainingDTO trainingDto = (TrainingDTO)r3.Data;
            return new Training(trainingDto);
        }

        /// <summary>
        /// Méthode permettant d'obtenir le statut
        /// </summary>
        /// <param name="idstatus"></param>
        /// <returns></returns>
        public Status GetStatus(int idstatus)
        {
            DALWSR_Result r1 = dal.GetStatusByIdAsync(idstatus, CancellationToken.None);
            StatusDTO statusDto = (StatusDTO)r1.Data;
            return new Status(statusDto);
        }

        /// <summary>
        /// Méthode permettant de sauvegarder un sujet, create ou update
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool SaveTopic(Topic topic, Token token)
        {
            DALWSR_Result r1 = dal.SaveTopic(topic.DTO, token, CancellationToken.None);
            return r1.IsSuccess;
        }

        /// <summary>
        /// Méthode permettant de supprimer un sujet et ses messages
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool DeleteTopic(Topic topic, Token token)
        {
            DALWSR_Result r1 = dal.DeleteTopic(topic.IdTopic, token, CancellationToken.None);
            DALWSR_Result r2 = dal.GetMessagesByTopicAsync(topic.IdTopic, CancellationToken.None);
            bool result = true;
            if (r1.Data != null)
            {
                if(r2.Data != null)
                {
                    foreach (MessageDTO item in (List<MessageDTO>)r2.Data)
                    {
                        DALWSR_Result r3 = dal.DeleteMessage(item.IdMessage, token, CancellationToken.None);
                        if (r3.IsSuccess == false)
                        {
                            result = false;
                        }
                    }
                }
                
            }
            if(r1.IsSuccess == false)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Methode permettant de sauvegarder un message, create ou update
        /// </summary>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool SaveMessage(Message message, Token token)
        {
            DALWSR_Result r1 = dal.SaveMessage(message.DTO, token, CancellationToken.None);
            return r1.IsSuccess;
        }

        /// <summary>
        /// Méthode permettant de supprimer un message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool DeleteMessage(Message message, Token token)
        {
            DALWSR_Result r1 = dal.DeleteMessage(message.IdMessage, token, CancellationToken.None);
            return r1.IsSuccess;
        }

        public override string ToString()
        {
            return "Id : " + IdUser 
                + " Statut : " + ObjStatus 
                + " Training : " + ObjTraining 
                + " Nom : " + NameUser 
                + " Prénom : " + FirstnameUser 
                + " Email : " + EmailUser
                + " Login : " + LoginUser 
                + " Pwd : " + PwdUser 
                + " Mot-clé : " + KeywordUser;
        }

        /// <summary>
        /// Validation des propriétés de l'utilisateur
        /// </summary>
        /// <returns></returns>
        public override List<ValidationError> Validate()
        {
            Val_Name();
            Val_Email();
            return this.ValidationErrors;
        }

        /// <summary>
        /// Méthode permettant de valider les chaînes de caractères, 
        /// valeur null, longueur maxi, alphaonly
        /// </summary>
        /// <returns></returns>
        private bool Val_Name()
        {
            int i = 0;
            if (NameUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "Le nom est requis"));
                i++;
            }
            else
            {
                if (NameUser.Length > 50)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "Le nom doit contenir 50 caractères au maximum"));
                    i++;
                }
                if (!AuditTool.IsAlpha(NameUser))
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "Le nom ne peut contenir de chiffres"));
                    i++;
                }
            }
            
            
            if (FirstnameUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "Le prénom est requis"));
                i++;
            }
            else
            {
                if (FirstnameUser.Length > 50)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "Le prénom doit contenir 50 caractères au maximum"));
                    i++;
                }
                if (!AuditTool.IsAlpha(FirstnameUser))
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "Le prénom ne peut contenir de chiffres"));
                    i++;
                }
            }
            

            if (LoginUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.LoginUser", "L'identifiant est requis"));
                i++;
            }
            else
            {
                if (LoginUser.Length > 50)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.LoginUser", "L'identifiant doit contenir 50 caractères au maximum"));
                    i++;
                }
            }
            if (PwdUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.PwdUser", "Le mot de passe est requis"));
                i++;
            }
            else
            {
                if (PwdUser.Length > 50)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.PwdUser", "Le mot de passe doit contenir 50 caractères au maximum"));
                    i++;
                }
            }
            if (KeywordUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.KeywordUser", "Le mot-clé est requis"));
                i++;
            }
            else
            {
                if (KeywordUser.Length > 50)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.KeywordUser", "Le mot-clé doit contenir 50 caractères au maximum"));
                    i++;
                }
            }
            if (i > 0)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Méthode permettant de vérifier le format email
        /// </summary>
        /// <returns></returns>
        private bool Val_Email()
        {
            int i = 0;
            if (EmailUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "L'email est requis"));
                i++;
            }
            else
            {
                if (!AuditTool.IsEmail(EmailUser))
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "L'email n'est pas valide"));
                    i++;
                }
                if (EmailUser.Length > 100)
                {
                    this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "L'email doit contenir 100 caractères au maximum"));
                    i++;
                }
            }
                
            if (i > 0)
            {
                return false;
            }
            else return true;
        }
    }

}
