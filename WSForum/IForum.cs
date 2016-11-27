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
        [WebInvoke(UriTemplate = "Messages",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        WSR_Result GetMessages(WSR_Param param);

        [OperationContract]
        [WebInvoke(UriTemplate = "Essai",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        WSR_Result GetEssai(WSR_Param param);
    }


    
}
