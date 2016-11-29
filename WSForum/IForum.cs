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
        [WebInvoke(UriTemplate = "Users",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result SaveUser(WSR_Param param);

        [OperationContract]
        [WebGet(UriTemplate = "Users/{iduser}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetUserById(string iduser);

        [OperationContract]
        [WebInvoke(UriTemplate = "Users/{iduser}",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result UpdateUser(WSR_Param param, string iduser);
    }


    
}
