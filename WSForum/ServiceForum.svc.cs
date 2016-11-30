using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWSRest;
using DALForum;
using Common;
using DLLAuth;

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

        public WSR_Result GetAuthentication(WSR_Param param)
        {
            Token token = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "token", out token);

            if (result == null)
            {
                token = (Token)param["token"];
                TokenDb db = new TokenDb();
                token = db.GetAuh(token);
                data = token;
                return new WSR_Result(data, true);
            }
            return result;
        }
        public WSR_Result GetUserById(string iduser)
        {
            object data = null;
            WSR_Result result = null;

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
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                RegisteredDb db = new RegisteredDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveUser(WSR_Param param)
        {
            RegisteredDTO registered = null;
            object data = null;
            WSR_Result result = null;

            Token token = null;
            result = VerifParamType(param, "token", out token);
            if (result == null)
            {
                token = (Token)param["token"];
                TokenDb dbToken = new TokenDb();
                RegisteredDTO regToken = dbToken.GetInfoAuth(token);

                if (TokenManager.IsTokenValid(token, regToken))
                {
                    result = VerifParamType(param, "save", out registered);

                    if (result == null)
                    {
                        registered = (RegisteredDTO)param["save"];
                        RegisteredDb db = new RegisteredDb();
                        db.SaveUser(ref registered);
                        data = registered;
                        return new WSR_Result(data, true);
                    }
                    else return result;
                }
                else return result;
            }
            else return result;
        }
        public WSR_Result DeleteUser(string iduser)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                RegisteredDb db = new RegisteredDb();
                data = db.DeleteUser(Convert.ToInt32(iduser));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetRubrics()
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                RubricDb db = new RubricDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetRubricById(string idrubric)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                RubricDb db = new RubricDb();
                data = db.GetRubricById(Convert.ToInt32(idrubric));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveRubric(WSR_Param param)
        {
            RubricDTO rubric = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out rubric);

            if (result == null)
            {
                rubric = (RubricDTO)param["save"];
                RubricDb db = new RubricDb();
                db.SaveRubric(ref rubric);
                data = rubric;
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result DeleteRubric(string idrubric)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                RubricDb db = new RubricDb();
                data = db.DeleteRubric(Convert.ToInt32(idrubric));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetStatus()
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                StatusDb db = new StatusDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetStatusById(string idstatus)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                StatusDb db = new StatusDb();
                data = db.GetStatusById(Convert.ToInt32(idstatus));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveStatus(WSR_Param param)
        {
            StatusDTO status = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out status);

            if (result == null)
            {
                status = (StatusDTO)param["save"];
                StatusDb db = new StatusDb();
                db.SaveStatus(ref status);
                data = status;
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result DeleteStatus(string idstatus)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                StatusDb db = new StatusDb();
                data = db.DeleteStatus(Convert.ToInt32(idstatus));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTrainings()
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TrainingDb db = new TrainingDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTrainingById(string idtraining)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TrainingDb db = new TrainingDb();
                data = db.GetTrainingById(Convert.ToInt32(idtraining));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveTraining(WSR_Param param)
        {
            TrainingDTO training = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out training);

            if (result == null)
            {
                training = (TrainingDTO)param["save"];
                TrainingDb db = new TrainingDb();
                db.SaveTraining(ref training);
                data = training;
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result DeleteTraining(string idstatus)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TrainingDb db = new TrainingDb();
                data = db.DeleteTraining(Convert.ToInt32(idstatus));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTopics()
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TopicDb db = new TopicDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTopicById(string idtopic)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TopicDb db = new TopicDb();
                data = db.GetTopicById(Convert.ToInt32(idtopic));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTopicsByRubric(string idrubric)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TopicDb db = new TopicDb();
                data = db.GetTopicByRubric(Convert.ToInt32(idrubric));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetTopicsByUser(string iduser)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TopicDb db = new TopicDb();
                data = db.GetTopicByUser(Convert.ToInt32(iduser));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveTopic(WSR_Param param)
        {
            TopicDTO topic = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out topic);

            if (result == null)
            {
                topic = (TopicDTO)param["save"];
                TopicDb db = new TopicDb();
                db.SaveTopic(ref topic);
                data = topic;
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result DeleteTopic(string idtopic)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                TopicDb db = new TopicDb();
                data = db.DeleteTopic(Convert.ToInt32(idtopic));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetMessages()
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                MessageDb db = new MessageDb();
                data = db.GetAll();
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetMessageById(string idmessage)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                MessageDb db = new MessageDb();
                data = db.GetMessageById(Convert.ToInt32(idmessage));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetMessagesByTopic(string idtopic)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                MessageDb db = new MessageDb();
                data = db.GetMessageByTopic(Convert.ToInt32(idtopic));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result GetMessagesByUser(string iduser)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                MessageDb db = new MessageDb();
                data = db.GetMessageByUser(Convert.ToInt32(iduser));
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result SaveMessage(WSR_Param param)
        {
            MessageDTO message = null;
            object data = null;
            WSR_Result result = null;

            result = VerifParamType(param, "save", out message);

            if (result == null)
            {
                message = (MessageDTO)param["save"];
                MessageDb db = new MessageDb();
                db.SaveMessage(ref message);
                data = message;
                return new WSR_Result(data, true);
            }
            else return result;
        }
        public WSR_Result DeleteMessage(string idmessage)
        {
            object data = null;
            WSR_Result result = null;

            if (result == null)
            {
                MessageDb db = new MessageDb();
                data = db.DeleteMessage(Convert.ToInt32(idmessage));
                return new WSR_Result(data, true);
            }
            else return result;
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

    
