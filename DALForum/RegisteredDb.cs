using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALForum
{
    public class RegisteredDb : DALBase
    {
        public RegisteredDTO GetUserById(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETUSERSBYID");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetSingleDTO<RegisteredDTO>(ref command);
        }

        public List<RegisteredDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLUSERS");
            return GetDTOList<RegisteredDTO>(ref cmd);
        }

        public void CreateUser(ref RegisteredDTO registered)
        {// La sproc gérera l'insertion et la mise à jour.
         // Nous avons juste besoin de retourner l'id approprié de la personne.
         // S'il s'agit d'une nouvelle personne, alors nous retournons le NewPerson.
         // S'il s'agit d'une mise à jour, nous renvoyons juste l'id.
            bool isNewRecord = false;
            if (registered.IdUser.Equals(Common.DTOBase.Int_NullValue)) { isNewRecord = true; }

            // Crée la commande et les paramètres.
            // Lors de la création des paramètres nous n'avons pas besoin de vérifier les valeurs null.
            // La méthode CreateParameter va gérer cela pour nous et créer les paramètres null pour tous 
            // les membres DTO qui correspondent à DTOBase.NullValue dans le type de données du membre.
            SqlCommand command = GetDbSprocCommand("INSERTUSERS");
            //command.Parameters.Add(CreateParameter("@IDUSER", registered.IdUser));
            command.Parameters.Add(CreateParameter("@IDSTATUS", registered.StatusUser));
            command.Parameters.Add(CreateParameter("@IDTRAINING", registered.TrainingUser));
            command.Parameters.Add(CreateParameter("@NAME", registered.NameUser, 50));
            command.Parameters.Add(CreateParameter("@FIRSTNAME", registered.FirstnameUser, 50));
            command.Parameters.Add(CreateParameter("@EMAIL", registered.EmailUser, 50));
            command.Parameters.Add(CreateParameter("@LOGIN", registered.LoginUser, 50));
            command.Parameters.Add(CreateParameter("@PASSWORD", registered.PwdUser, 1024));
            command.Parameters.Add(CreateParameter("@KEYWORD", registered.KeywordUser, 50));
            
            SqlParameter paramNewUserId = CreateOutputParameter("@NEWUSERID", SqlDbType.Int);
            command.Parameters.Add(paramNewUserId);
            // Exécute la commande.
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            // S'il s'agit d'un nouvel enregistrement, attribut un nouvel id à l'objet.
            if (isNewRecord) { registered.IdUser = (int)paramNewUserId.Value; }
        }
    }
}
