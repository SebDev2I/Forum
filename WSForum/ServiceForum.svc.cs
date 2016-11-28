﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWSRest;
using DALForum;
using Common;

namespace WSForum
{
    public class ServiceForum : IForum
    {
        // PLAGE DES CODES ERREUR POUR LE WebService ---> [1 - 200]
        public const int CodeRet_Ok = 0;
        public const int CodeRet_PseudoUtilise = 1;
        public const int CodeRet_PseudoObligatoire = 2;
        public const int CodeRet_PseudoDownloadObligatoire = 3;
        public const int CodeRet_Logout = 4;
        public const int CodeRet_PasswordObligatoire = 5;
        public const int CodeRet_PasswordIncorrect = 6;
        public const int CodeRet_PseudoDownloadLogout = 7;
        public const int CodeRet_ParamKeyInconnu = 10;
        public const int CodeRet_ParamTypeInvalid = 11;
        public const int CodeRet_ErreurInterneService = 100;
        public WSR_Result GetUserById(string iduser)
        {
            //string login = null;
            object data = null;
            WSR_Result result = null;

            //result = VerifParamType(param, "login", out login);
            if (result == null)
            {
                RegisteredDb db = new RegisteredDb();
                data = db.GetUserById(Convert.ToInt32(iduser));
                return new WSR_Result(data, true);
            }
            else return result;
        }

        public WSR_Result GetUsers()
        {
            //string login = null;
            object data = null;
            WSR_Result result = null;

            //result = VerifParamType(param, "login", out login);
            if (result == null)
            {
                RegisteredDb db = new RegisteredDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }

        public WSR_Result CreateUser(WSR_Param param)
        {
            string save = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out save);
            if (result == null)
            {
                RegisteredDb db = new RegisteredDb();
                data = db.save();
                return new WSR_Result(data, true);
            }
            else return result;
        }

        public WSR_Result UpdateUser(WSR_Param param, string iduser)
        {
            throw new NotImplementedException();
        }

        #region Fonctions perso

        /// <summary>
        /// Vérification de l'existance du parametre définit par sa clé dans l'objet de la classe WSR_Params
        /// </summary>
        /// <param name="p">Objet de type WSR_Params</param>
        /// <param name="key">Chaine de caractère définissant la clé du paramètre.</param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static WSR_Result VerifParamExist(WSR_Param p, string key, out object data)
        {
            data = null;

            if (!p.ContainsKey(key))
                return new WSR_Result(CodeRet_ParamKeyInconnu, String.Format(Properties.Resources.PARAMKEYINCONNU, key));

            data = p.GetValueSerialized(key);

            return null;
        }

        protected static WSR_Result VerifParamType<T>(WSR_Param p, string key, out T value) where T : class
        {
            object data = null;
            value = null;

            WSR_Result ret = VerifParamExist(p, key, out data);
            if (ret != null)
                return ret;

            if (p[key] != null)
            {
                try
                {
                    value = p[key] as T; // Permet de vérifier le type
                }
                catch (Exception) { } // Il peut y avoir exception si le type est inconnu (type personnalisé qui n'est pas dans les références)

                if (value == null)
                    return new WSR_Result(CodeRet_ParamTypeInvalid, String.Format(Properties.Resources.PARAMTYPEINVALID, key));
            }

            return null;
        }

        

        #endregion Fonctions perso
    }
}

    
