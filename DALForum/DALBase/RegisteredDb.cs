﻿using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALForum
{
    /// <summary>
    /// Classe contenant les méthodes crud de la table REGISTERED
    /// </summary>
    public class RegisteredDb : DALBase
    {
        /// <summary>
        /// Méthode pour ramener un user par son id
        /// </summary>
        /// <param name="iduser"></param>
        /// <returns></returns>
        public RegisteredDTO GetUserById(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETUSERSBYID");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetSingleDTO<RegisteredDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener la liste de tous les users
        /// </summary>
        /// <returns></returns>
        public List<RegisteredDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLUSERS");
            return GetDTOList<RegisteredDTO>(ref cmd);
        }

        /// <summary>
        /// Méthode pour sauvegarder un utilisateur (save et update)
        /// </summary>
        /// <param name="registered"></param>
        public void SaveUser(ref RegisteredDTO registered)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewUserId = new SqlParameter();
            bool isNewRecord = false;
            if (registered.IdUser.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTUSER");
                paramNewUserId = CreateOutputParameter("@NEWUSERID", SqlDbType.Int);
                command.Parameters.Add(paramNewUserId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATEUSERS");
                command.Parameters.Add(CreateParameter("@ID", registered.IdUser));
            }
            
            command.Parameters.Add(CreateParameter("@IDSTATUS", registered.StatusUser));
            command.Parameters.Add(CreateParameter("@IDTRAINING", registered.TrainingUser));
            command.Parameters.Add(CreateParameter("@NAME", registered.NameUser, 50));
            command.Parameters.Add(CreateParameter("@FIRSTNAME", registered.FirstnameUser, 50));
            command.Parameters.Add(CreateParameter("@EMAIL", registered.EmailUser, 100));
            command.Parameters.Add(CreateParameter("@LOGIN", registered.LoginUser, 50));
            command.Parameters.Add(CreateParameter("@PASSWORD", registered.PwdUser, 1024));
            command.Parameters.Add(CreateParameter("@KEYWORD", registered.KeywordUser, 50));
            
            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if(nb == 1)
            {
                if (isNewRecord && nb == 1) { registered.IdUser = (int)paramNewUserId.Value; }
                //TODO return sur l'exécution des requetes insert et update
            }
            // S'il s'agit d'un nouvel enregistrement, attribut un nouvel id à l'objet.
            
        }

        /// <summary>
        /// Méthode pour supprimer un utilisateur
        /// </summary>
        /// <param name="iduser"></param>
        /// <returns></returns>
        public bool DeleteUser(int iduser)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETEUSERS");
            command.Parameters.Add(CreateParameter("@ID", iduser));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if(nb == 1){ isDeleted = true; }
            return isDeleted;
        }
    }
}
