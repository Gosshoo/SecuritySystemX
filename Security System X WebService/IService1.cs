using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Security_System_X_WebService.Model;

namespace Security_System_X_WebService
{
	[ServiceContract]
	public interface IService1
	{
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "data/")]
        //string GetData();

        //MOTION
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "motions/")]
        IList<Motion> GetMotions();

        [OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "motionslast/")]
		Motion GetMotion();

		[OperationContract]
		[WebInvoke(Method = "POST",
			RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "motions/")]
		int InsertMotion(Motion motion);

        //Noise
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "noises/")]
        IList<Noise> GetNoises();

        [OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "noiseslast/")]
		Noise GetNoise();

		[OperationContract]
		[WebInvoke(Method = "POST",
			RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "noises/")]
		int InsertNoise(Noise noise);

	    [OperationContract]
	    [WebInvoke(Method = "DELETE",
	        RequestFormat = WebMessageFormat.Json,
	        ResponseFormat = WebMessageFormat.Json,
	        UriTemplate = "noises/{id}")]
	    int DeleteNoise(string id);

	    //[OperationContract]
	    //[WebInvoke(Method = "DELETE",
	    //	RequestFormat = WebMessageFormat.Json,
	    //	ResponseFormat = WebMessageFormat.Json,
	    //	BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "motions/{id}")]
	    //Motion DeleteMotion(string id);



	    //[OperationContract]
	    //[WebInvoke(Method = "PUT",
	    //	RequestFormat = WebMessageFormat.Json,
	    //	ResponseFormat = WebMessageFormat.Json,
	    //	BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "motions/{id}")]
	    //Motion UpdateMotion(Motion motion, string id);

	}
}
