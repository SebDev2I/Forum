﻿using Common;
using DALClientWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Registered : ForumBase
    {
        public int IdUser { get; set; }
        //public int StatusUser { get; set; }
        public Status ObjStatus { get; set; }
        //public int TrainingUser { get; set; }
        public Training ObjTraining { get; set; }
        public string NameUser { get; set; }
        public string FirstnameUser { get; set; }
        public string EmailUser { get; set; }
        public string LoginUser { get; set; }
        public string PwdUser { get; set; }
        public string KeywordUser { get; set; }
        public RegisteredDTO DTO { get; set; }
        public List<Registered> ListRegistered { get; set; }
        private DALClient dal { get; set; }

        public Registered()
        {
            dal = new DALClient();
            ListRegistered = new List<Registered>();
            IdUser = Int_NullValue;
            //StatusUser = Int_NullValue;
            ObjStatus = null;
            //TrainingUser = Int_NullValue;
            NameUser = String_NullValue;
            ObjTraining = null;
            FirstnameUser = String_NullValue;
            EmailUser = String_NullValue;
            LoginUser = String_NullValue;
            PwdUser = String_NullValue;
            KeywordUser = String_NullValue;
            DTO = new RegisteredDTO();
        }

        /*public Registered(int iduser, int statususer, int traininguser, string nameuser, string firstnameuser, string emailuser)
        {
            IdUser = iduser;
            StatusUser = statususer;
            TrainingUser = traininguser;
            NameUser = nameuser;
            FirstnameUser = firstnameuser;
            EmailUser = emailuser;
        }*/

        /*public Registered(RegisteredDTO dto)
        {
            IdUser = dto.IdUser;
            //StatusUser = dto.StatusUser;
            //TrainingUser = dto.TrainingUser;
            NameUser = dto.NameUser;
            FirstnameUser = dto.FirstnameUser;
            EmailUser = dto.EmailUser;
            LoginUser = dto.LoginUser;
            PwdUser = dto.PwdUser;
            KeywordUser = dto.KeywordUser;
            DTO = dto;
        }*/

        public Registered(RegisteredDTO dto, Status objstatus, Training objtraining) : this()
        {
            IdUser = dto.IdUser;
            ObjStatus = objstatus;
            ObjTraining = objtraining;
            NameUser = dto.NameUser;
            FirstnameUser = dto.FirstnameUser;
            EmailUser = dto.EmailUser;
            LoginUser = dto.LoginUser;
            //PwdUser = dto.PwdUser;
            //KeywordUser = dto.KeywordUser;
            DTO = dto;
        }

        public Registered(int iduser, Status objstatus, Training objtraining, string nameuser, string firstnameuser, 
            string emailuser, string loginuser, string pwduser, string keyworduser) : this()
        {
            IdUser = iduser;
            //StatusUser = idstatus;
            ObjStatus = objstatus;
            //TrainingUser = idtraining;
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
            DTO.PwdUser = pwduser;
            DTO.KeywordUser = keyworduser;
        }

        public async Task<Registered> GetInfoUser(int iduser)
        {
            DALWSR_Result r1 = await dal.GetUserById(iduser, CancellationToken.None);
            RegisteredDTO regDto = (RegisteredDTO)r1.Data;
            return new Registered(regDto, await GetStatus(regDto.StatusUser), await GetTraining(regDto.TrainingUser));
        }

        public async Task<List<Registered>> GetListUsers()
        {
            DALWSR_Result r1 = await dal.GetUsers(CancellationToken.None);
            foreach (RegisteredDTO item in (List<RegisteredDTO>)r1.Data)
            {
                ListRegistered.Add(new Registered(item, await GetStatus(item.StatusUser), await GetTraining(item.TrainingUser)));
            }
            return ListRegistered;
        }

        public async Task<Training> GetTraining(int idtraining)
        {
            DALWSR_Result r3 = await dal.GetTrainingById(idtraining, CancellationToken.None);
            TrainingDTO trainingDto = (TrainingDTO)r3.Data;
            return new Training(trainingDto);
        }
        public async Task<Status> GetStatus(int idstatus)
        {
            DALWSR_Result r1 = await dal.GetStatusById(idstatus, CancellationToken.None);
            StatusDTO statusDto = (StatusDTO)r1.Data;
            return new Status(statusDto);
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

        public override List<ValidationError> Validate()
        {
            Val_Name();
            Val_Email();
            //Val_Login();
            //Val_Pwd();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            int i = 0;
            if (NameUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> est requis"));
                i++;
            }
            if (NameUser.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> doit contenir 50 caractères au maximum"));
                i++;
            }
            if (!AuditTool.IsAlpha(NameUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> ne peut contenir de chiffres"));
                i++;
            }
            if (FirstnameUser == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> est requis"));
                i++;
            }
            if (FirstnameUser.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> doit contenir 50 caractères au maximum"));
                i++;
            }
            if (!AuditTool.IsAlpha(FirstnameUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> ne peut contenir de chiffres"));
                i++;
            }
            if (LoginUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.LoginUser", "<LOGIN> est requis"));
                i++;
            }
            if (PwdUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.PwdUser", "<PASSWORD> est requis"));
                i++;
            }
            if (KeywordUser == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.KeywordUser", "<KEYWORD> est requis"));
                i++;
            }
            if (i > 0)
            {
                return false;
            }
            else return true;
        }

        private bool Val_Email()
        {
            if (!AuditTool.IsEmail(EmailUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "<EMAIL> ne correspond pas au format email"));
                return false;
            }
            else if (EmailUser.Length > 100)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "<EMAIL> doit contenir 100 caractères au maximum"));
                return false;
            }
            else return true;
        }

        /*private bool Val_Login()
        {

        }*/

        /*private bool Val_Pwd()
        {

        }*/
    }

}
