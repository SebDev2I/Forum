using Common;
using ConsumeWSRest;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DALClientWS
{
    public class DALClient
    {
        private const string ADRSERVER = @"http://localhost:5000";
        //private const string ADRSERVER = @"http://user16.2isa.org";
        private const string SERVICENAME = "ServiceForum.svc";
        private const string ADR_LOGIN = "Login";
        private const string ADR_GETUSERS = "Users";
        private const string ADR_GETUSERBYID = "Users/";                        //{iduser}
        private const string ADR_SAVEUSER = "Users";
        private const string ADR_DELETEUSER = "Users/";                         //{iduser}
        private const string ADR_GETRUBRICS = "Rubrics";
        private const string ADR_GETRUBRICBYID = "Rubrics/";                    //{idrubric}
        private const string ADR_SAVERUBRIC = "Rubrics";
        private const string ADR_DELETERUBRIC = "Rubrics/";                     //{idrubric}
        private const string ADR_GETSTATUS = "Status";
        private const string ADR_GETSTATUSBYID = "Status/";                     //{idstatus}
        private const string ADR_SAVESTATUS = "Status";
        private const string ADR_DELETESTATUS = "Status/";                      //{idstatus}
        private const string ADR_GETTRAININGS = "Trainings";
        private const string ADR_GETTRAININGBYID = "Trainings/";                //{idtraining}
        private const string ADR_SAVETRAINING = "Trainings";
        private const string ADR_DELETETRAINING = "Trainings/";                 //{idtraining}
        private const string ADR_GETTOPICS = "Topics";
        private const string ADR_GETTOPICBYID = "Topics/";                      //{idtopic}
        private const string ADR_GETTOPICSBYRUBRIC = "Topics/Rubric=";          //{idrubric}
        private const string ADR_GETTOPICSBYUSER = "Topics/User=";              //{iduser}
        private const string ADR_SAVETOPIC = "Topics";
        private const string ADR_DELETETOPIC = "Topics/";                       //{idtopic}
        private const string ADR_GETMESSAGES = "Messages";
        private const string ADR_GETMESSAGEBYID = "Messages/";                  //{idmessage}
        private const string ADR_GETMESSAGESBYTOPIC = "Messages/Topic=";        //{idtopic}
        private const string ADR_GETMESSAGESBYUSER = "Messages/User=";          //{iduser}
        private const string ADR_SAVEMESSAGE = "Messages";
        private const string ADR_DELETEMESSAGE = "Messages/";                   //{idmessage}

        private string _CnxString;

        public string CnxString
        {
            get { return _CnxString; }
            set
            {
                value = string.Concat(ADRSERVER, '/', SERVICENAME, '/');
                _CnxString = value;
            }
        }


        //public DALClient() { }
        public DALClient()
        {
            _CnxString = string.Concat(ADRSERVER, '/', SERVICENAME, '/');
        }

        public async Task<DALWSR_Result> LoginAsync(Token tokenAsk, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_LOGIN);
            WSR_Param p = new WSR_Param();
            p.Add("token", tokenAsk);
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetUsers(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETUSERS);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetUserById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETUSERBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveUser(RegisteredDTO registered, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVEUSER);
            WSR_Param p = new WSR_Param() { { "save", registered }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteUser(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETEUSER, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetListRubrics(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETRUBRICS);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetRubricById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETRUBRICBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveRubric(RubricDTO rubric, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVERUBRIC);
            WSR_Param p = new WSR_Param() { { "save", rubric }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteRubric(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETERUBRIC, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetListStatus(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETSTATUS);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetStatusById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETSTATUSBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveStatus(StatusDTO status, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVESTATUS);
            WSR_Param p = new WSR_Param() { { "save", status }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteStatus(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETESTATUS, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetListTrainings(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTRAININGS);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetTrainingById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTRAININGBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveTraining(TrainingDTO training, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVETRAINING);
            WSR_Param p = new WSR_Param() { { "save", training }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteTraining(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETETRAINING, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetTopics(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTOPICS);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetTopicById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTOPICBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetTopicByRubric(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTOPICSBYRUBRIC, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetTopicByUser(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETTOPICSBYUSER, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveTopic(TopicDTO topic, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVETOPIC);
            WSR_Param p = new WSR_Param() { { "save", topic }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteTopic(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETETOPIC, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetListMessages(CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETMESSAGES);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetMessagesById(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETMESSAGEBYID, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetMessagesByTopic(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETMESSAGESBYTOPIC, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> GetMessagesByUser(int id, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_GETMESSAGESBYUSER, id);
            WSR_Result r = await ConsumeWSR.Call(str, "GET", null, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> SaveMessage(MessageDTO message, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_SAVEMESSAGE);
            WSR_Param p = new WSR_Param() { { "save", message }, { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "POST", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }

        public async Task<DALWSR_Result> DeleteMessage(int id, Token tokenSend, CancellationToken cancel)
        {
            string str = string.Concat(CnxString, ADR_DELETEMESSAGE, id);
            WSR_Param p = new WSR_Param() { { "token", tokenSend } };
            WSR_Result r = await ConsumeWSR.Call(str, "DELETE", p, TypeSerializer.Json, cancel);
            return new DALWSR_Result(r);
        }
    }
}
