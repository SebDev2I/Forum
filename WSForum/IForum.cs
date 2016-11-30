using Common;
using ConsumeWSRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSForum
{
    [ServiceContract]
    public interface IForum
    {
        [OperationContract]
        [WebGet(UriTemplate = "Users",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetUsers();

        [OperationContract]
        [WebGet(UriTemplate = "Users/{iduser}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetUserById(string iduser);

        [OperationContract]
        [WebInvoke(UriTemplate = "Users",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result SaveUser(WSR_Param param);
        
        [OperationContract]
        [WebInvoke(UriTemplate = "Users/{iduser}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result DeleteUser(string iduser);

        [OperationContract]
        [WebGet(UriTemplate = "Rubrics",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetRubrics();

        [OperationContract]
        [WebGet(UriTemplate = "Rubrics/{idrubric}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetRubricById(string idrubric);

        [OperationContract]
        [WebInvoke(UriTemplate = "Rubrics",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result SaveRubric(WSR_Param param);

        [OperationContract]
        [WebInvoke(UriTemplate = "Rubrics/{idrubric}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result DeleteRubric(string idrubric);

        [OperationContract]
        [WebGet(UriTemplate = "Status",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetStatus();

        [OperationContract]
        [WebGet(UriTemplate = "Status/{idstatus}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetStatusById(string idstatus);

        [OperationContract]
        [WebInvoke(UriTemplate = "Status",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result SaveStatus(WSR_Param param);

        [OperationContract]
        [WebInvoke(UriTemplate = "Status/{idstatus}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result DeleteStatus(string idstatus);

        [OperationContract]
        [WebGet(UriTemplate = "Trainings",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetTrainings();

        [OperationContract]
        [WebGet(UriTemplate = "Trainings/{idtraining}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetTrainingById(string idtraining);

        [OperationContract]
        [WebInvoke(UriTemplate = "Trainings",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result SaveTraining(WSR_Param param);

        [OperationContract]
        [WebInvoke(UriTemplate = "Trainings/{idtraining}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result DeleteTraining(string idtraining);
    }


    
}
